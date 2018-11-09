import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { NgProgress, NgProgressRef } from '@ngx-progressbar/core';
import 'rxjs/add/operator/do';
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { finalize } from "rxjs/operators";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    progressBar: NgProgressRef;
    private _inProgressCount = 0;
    constructor(
        private ngProgress: NgProgress,
        private router: Router
    ) {
        this.progressBar = this.ngProgress.ref();
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this._inProgressCount++;
        if (!this.progressBar.isStarted) {
            this.progressBar.start();
        }
        if (localStorage.getItem('userToken') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))
            });
            return next.handle(clonedreq)
                .do(
                    succ => { },
                    err => {
                        if (err.status === 401)
                            this.router.navigateByUrl('/login');
                        else (err.status === 403)
                        this.router.navigateByUrl('/forbidden');
                    }
                )
                .pipe(
                    finalize(() => {
                        this._inProgressCount--;
                        if (this._inProgressCount === 0) {
                            this.progressBar.complete();
                        }
                    })
                );
        }
        else {
            return next.handle(req.clone())
            .pipe(
                finalize(() => {
                    this._inProgressCount--;
                    if (this._inProgressCount === 0) {
                        this.progressBar.complete();
                    }
                })
            );
        }
    }
}
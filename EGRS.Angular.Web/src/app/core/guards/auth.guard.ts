import { Injectable, OnDestroy } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';
import { PermissionsEnum } from '../../shared/config';
import { Helper } from '../helper/helper';

@Injectable()
export class AuthGuard implements CanActivate, OnDestroy {
  checkAuthenticationSubscriber: Subscription;

  constructor(private authService: AuthService, private route:Router) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    let accessAllowed: boolean = true;
    debugger;
    this.checkAuthenticationSubscriber = this.authService.isCurrentlyAuthentic.subscribe(
       (isActive) => {
         if(!isActive) {
          this.authService.returnUrl = next.url.toString();
          this.route.navigateByUrl('/login?returnUrl='+ next.url);
         }
       }
     );

     if(next.data.roles) {
       debugger;
      accessAllowed = next.data.roles.some((permission) => this.authService.authData.Roles[permission.toString()]);
     }

     return Helper.booleanObservable(accessAllowed);
  }

  ngOnDestroy() {
    this.checkAuthenticationSubscriber.unsubscribe();
  }
}
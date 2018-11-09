import { Injectable } from '@angular/core';
import { AuthDataModel } from '../models/auth-data.models';
import { LoginModel } from '../models/login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import * as jwt_decode from "jwt-decode";
import { appConstants, PermissionsEnum } from '../shared/config';
import { IAuthData } from '../interfaces/auth-data.interface';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
  public authData: IAuthData = new AuthDataModel();
  public returnUrl: string;

  private _isAuthenticated = new BehaviorSubject(false);
  get isAuthenticated():boolean {
    let isValid;
    this._isAuthenticated.asObservable().subscribe(
      (result) => {
        isValid = result;
      }
    );

    return isValid;
  }

  get isCurrentlyAuthentic(): Observable<boolean> {
    return this._isAuthenticated.asObservable();
  }

  constructor(private http: HttpClient,
    private router: Router) {
    try {
      if (localStorage.getItem('userToken')) {
        this.authData = JSON.parse(jwt_decode(localStorage.getItem('userToken')).UserAuthData);
        if (this.authData.Id > 0) {
          this._isAuthenticated.next(true);
        }
      }
    }
    catch (e) {
      this.resetAuthenticatedData();
    }
  }

  resetAuthenticatedData(): void {
    this.authData = new AuthDataModel();
  }

  login(loginModel: LoginModel) {
    this.resetAuthenticatedData();
    return this.http.post(appConstants.urls.loginUrl, loginModel)
      .pipe(
        tap(res => {
          Object.assign(this.authData, JSON.parse(jwt_decode(res).UserAuthData));
          if (this.authData.Id > 0) {

            this._isAuthenticated.next(true);
            localStorage.setItem("userToken", res.toString());
          }
        })
      )
  }

  logout(): void {
    this.resetAuthenticatedData();
    localStorage.removeItem("userToken");
    this._isAuthenticated.next(false);
  }

  checkAuthorization(roles: PermissionsEnum[]) {
    return roles.some((permission) => this.authData.Roles[permission.toString()]);
  }
}
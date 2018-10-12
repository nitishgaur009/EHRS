import { Injectable } from '@angular/core';
import { AuthenticatedDataModel } from '../models/auth-data.models';
import { LoginModel } from '../models/login.model';
import { LoginData } from '../mock-login-data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import * as jwt_decode from "jwt-decode";

@Injectable()
export class AuthService {
  public authenticatedData = new AuthenticatedDataModel();

  public returnUrl : string;
  private apiUrl:string =  "http://localhost:61642/api/";

  constructor(private http:HttpClient) {
    try{
     if(localStorage.getItem('userToken')){
        this.authenticatedData = jwt_decode(localStorage.getItem('userToken'));
        if(this.authenticatedData.userid > 0){
          this.authenticatedData.isauthenticated = true;
        }
     }
    }
    catch(e){
      this.resetAuthenticatedData();
    }     
   }

  resetAuthenticatedData():void{
     this.authenticatedData.username = '';
     this.authenticatedData.role = [];
     this.authenticatedData.isauthenticated = false;
     this.authenticatedData.userid = 0;
  }
  
  login(loginModel:LoginModel){
    this.resetAuthenticatedData();
    var data = "username=" + loginModel.username + "&password=" + loginModel.password;
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded','No-Auth':'True' });

   return this.http.post(this.apiUrl+ "token",data,{ headers: reqHeader })
    .pipe(
      tap(res => {
        Object.assign(this.authenticatedData, jwt_decode(res));
        debugger;
        if(this.authenticatedData.userid > 0){
          this.authenticatedData.isauthenticated = true;
          localStorage.setItem("userToken", res.toString());
        }
      })
    )
  }

  logout():void{
    this.resetAuthenticatedData();
    localStorage.removeItem("userToken");
  }
}

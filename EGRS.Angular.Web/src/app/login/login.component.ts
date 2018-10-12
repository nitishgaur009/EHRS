import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { NgForm } from '@angular/forms';
import { Router } from '../../../node_modules/@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginModel : LoginModel;

  constructor(private router:Router, private authService:AuthService) { }

  ngOnInit() {
    this.loginModel = new LoginModel();
    this.authService.logout();
  }

  onLoginFormSubmit(loginFormData:NgForm):void{
    
    if(!loginFormData.valid){
      alert('Please enter username and password');
    }
    else{
      
      this.authService.login(loginFormData.value)
      .subscribe(
        ()=>{
          if(this.authService.authenticatedData.isauthenticated){
            if(this.authService.returnUrl){
              this.router.navigateByUrl('/'+this.authService.returnUrl);
              this.authService.returnUrl = '';
            }
            else{
              this.router.navigateByUrl('/home');
            }        
          }
          else{
            alert('Invalid username or password!');
          } 
        },
        err=>{
          alert('Invalid username or password!');
        }
      )      
    }
  }
}

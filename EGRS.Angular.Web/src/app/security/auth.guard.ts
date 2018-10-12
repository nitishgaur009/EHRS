import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private route:Router){
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      
      if(!this.authService.authenticatedData.isauthenticated){
        this.authService.returnUrl = next.url.toString();
        this.route.navigateByUrl('/login?returnUrl='+ next.url);
      }
      
      return this.authService.authenticatedData.isauthenticated;
  }
}
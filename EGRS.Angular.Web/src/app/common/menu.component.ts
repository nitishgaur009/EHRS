import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { AuthenticatedDataModel } from '../models/auth-data.models';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  authenticatedData:AuthenticatedDataModel;

  constructor(private authService:AuthService, private router:Router) { 
    this.authenticatedData = authService.authenticatedData;
  }

  ngOnInit() {
  }

  logout():void{
    this.authService.logout();
  }
}

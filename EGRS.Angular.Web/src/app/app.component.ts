import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { AuthenticatedDataModel } from './models/auth-data.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  authenticatedData:AuthenticatedDataModel;

  constructor(private authService:AuthService){
    this.authenticatedData = this.authService.authenticatedData;
  }
}
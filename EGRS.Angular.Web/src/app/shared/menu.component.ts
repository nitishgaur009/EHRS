import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { PermissionsEnum } from './config';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  loggedUserName: string;
  permissionsType = PermissionsEnum;
  showManageUsersMenu: boolean;
  showManagePatientsMenu: boolean;

  constructor(private authService: AuthService) { 
  }

  ngOnInit() {
    this.loggedUserName = this.authService.authData.FirstName + ' ' + this.authService.authData.LastName;
    this.showManageUsersMenu = this.authService.checkAuthorization([PermissionsEnum.CanOperateAllUser]);
    this.showManagePatientsMenu = this.authService.checkAuthorization([PermissionsEnum.CanOperateAllUser, PermissionsEnum.CanManagePatients]);
  }

  logout():void{
    this.authService.logout();
  }
}
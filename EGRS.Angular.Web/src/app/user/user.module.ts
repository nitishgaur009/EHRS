import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './list/user-list.component';
import { UserComponent } from './user-form/user.component';
import { UserService } from '../services/user.service';
import { HelperService } from '../services/helper.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

const routes: Routes = [
  {
    path: 'list',
    component: UserListComponent
  },
  {
    path: 'user/:userId',
    component: UserComponent
  },
  {
    path: '',
    redirectTo: 'list'
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  declarations: [UserListComponent, UserComponent],
  providers: [UserService, HelperService]
})
export class UserModule { }

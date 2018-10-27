import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './list/user-list.component';
import { UserComponent } from './user-form/user.component';
import { UserService } from '../services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material';

const routes: Routes = [
  {
    path: 'list',
    component: UserListComponent
  },
  {
    path: 'user/:userId',
    component: UserComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule
  ],
  declarations: [UserListComponent, UserComponent],
  providers: [UserService]
})
export class UserModule { }

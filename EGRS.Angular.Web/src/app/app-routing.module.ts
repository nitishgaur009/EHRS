import { HomeComponent } from './home/home.component';
import { AuthGuard } from './core/guards/auth.guard';
import { Routes, RouterModule } from '@angular/router';
import { DoctorsListComponent } from './doctors/doctors-list.component';
import { AddDoctorComponent } from './doctors/add-doctor.component';
import { LoginComponent } from './login/login.component';

import { NgModule } from '@angular/core';
import { PermissionsEnum } from './shared/config';

export const AppRoutes: Routes = [
    {
        path:'home',
        component:HomeComponent,
        canActivate:[AuthGuard]
    },
    {
        path:'users',
        loadChildren: './user/user.module#UserModule',
        canActivate:[AuthGuard],
        data: {
            roles: [PermissionsEnum.CanOperateAllUser]
        }
    },
    {
        path:'doctors',
        component:DoctorsListComponent,
        canActivate:[AuthGuard]
    },
    {
        path:'doctors/add',
        component:AddDoctorComponent,
        canActivate:[AuthGuard]
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path:'',
        component:LoginComponent
    }
]

@NgModule({
    imports: [
        RouterModule.forRoot(AppRoutes)
      ],
      exports: [RouterModule]
})

export class AppRoutesModule { }
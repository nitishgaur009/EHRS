import { LoginComponent } from '../login/login.component';
import { HomeComponent } from '../home/home.component';
import { AuthGuard } from '../security/auth.guard';
import { Routes } from '@angular/router';
import { DoctorsListComponent } from '../doctors/doctors-list.component';
import { AddDoctorComponent } from '../doctors/add-doctor.component';

export const routes:Routes = [
    {
        path:'home',
        component:HomeComponent,
        canActivate:[AuthGuard]
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
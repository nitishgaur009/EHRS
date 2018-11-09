import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms'
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './core/guards/auth.guard';
import { MenuComponent } from './shared/menu.component';
import { DoctorsListComponent } from './doctors/doctors-list.component';
import { DoctorsService } from './services/doctors.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '../../node_modules/@angular/common/http';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { AddDoctorComponent } from './doctors/add-doctor.component';
import { AppRoutesModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgProgressModule } from '@ngx-progressbar/core'; /** module for incorporating loader / spinner */

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    MenuComponent,
    DoctorsListComponent,
    AddDoctorComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    AppRoutesModule,
    NgProgressModule.forRoot()
  ],
  providers: [AuthService, AuthGuard, DoctorsService,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }],
    exports: [
      NgProgressModule
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }

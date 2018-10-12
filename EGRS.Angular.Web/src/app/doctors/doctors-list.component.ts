import { Component, OnInit, HostListener } from '@angular/core';
import { DoctorsService } from '../services/doctors.service';
import { DoctorModel } from '../models/doctor.model';
import 'datatables.net';
import 'datatables.net-bs4';
import { Router } from '../../../node_modules/@angular/router';
import * as jwt_decode from "jwt-decode";
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent implements OnInit {
  doctorsData:DoctorModel[];
  start:number;
  end:number;
  showLoader:boolean;

  constructor(private doctorService:DoctorsService, private router:Router,
  private authservice: AuthService) { }

  ngOnInit() {
    this.start = 0;
    this.end = 10;
    this.showLoader = true;
    this.doctorService.getAllDoctors().subscribe(
      (data)=>
      { 
        this.doctorsData = data;
        this.showLoader = false;
      },
      (err) => console.log(err)
    )

    

    //let data  = jwt_decode(this.authservice.authenticatedData.token);
    
    //.getDoctorsOnDemard(this.start, this.end);
  }

  // @HostListener('window:scroll', ['$event']) onScrollEvent($event){
  //   this.end = this.end + 10;
  //   this.doctorsData = this.doctorService.getDoctorsOnDemard(this.start, this.end);
  // }

  addDoctorClick():void{
    this.router.navigateByUrl('/doctors/add');
  }
}

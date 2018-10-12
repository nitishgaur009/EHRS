import { Injectable } from '@angular/core';
import { DoctorModel } from '../models/doctor.model';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';


@Injectable()
export class DoctorsService {
    private apiUrl:string =  "http://localhost:61642/api/";

    constructor(private http:HttpClient) {
    }

    // getDoctorsOnDemard(start:number, end:number):DoctorModel[]{
    //     let doctors = this.getAllDoctors();

    //     return doctors.slice(start, end+1);
    // }

    getAllDoctors():Observable<DoctorModel[]> {
        return this.http.get<DoctorModel[]>(this.apiUrl+'doctors');
    }
}
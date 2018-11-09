import { Injectable } from '@angular/core';

@Injectable()
export class HelperService {

    constructor() {
    }

   handleError(error: any): void {
       alert('Something went wrong while executing the operation. Please contact your administrator');
   }
}
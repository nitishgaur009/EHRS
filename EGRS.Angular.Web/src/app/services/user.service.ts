import { Injectable } from "@angular/core";
import { IUser, IUserList } from "../interfaces/user.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
import { appConstants } from "../shared/config";
import { Observable } from "rxjs";


@Injectable()
export class UserService {
    constructor(private http: HttpClient) {
    }

    getAllUsers(): Observable<IUserList> {
        return this.http.get<IUserList>(appConstants.urls.getUsers);
    }

    getUser(userId: number): Observable<IUser> {
        const params: HttpParams = new HttpParams()
        .set('userId', userId.toString());
        
        return this.http.get<IUser>(appConstants.urls.getUser, { params });
    }
}
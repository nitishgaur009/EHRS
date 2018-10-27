import { IAuthData } from "../interfaces/auth-data.interface";
export class AuthDataModel implements IAuthData {
    Id = null;
    FirstName = '';
    LastName = '';
    Email = '';
    Roles = [];
}
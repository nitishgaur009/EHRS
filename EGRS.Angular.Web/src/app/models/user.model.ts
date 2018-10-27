import { IUser } from "../interfaces/user.interface";

export class User implements IUser {
    Id = 0;
    FirstName;
    LastName;
    Email;
    Address;
    BirthDate;
    MobileNumber;
    Roles;
}
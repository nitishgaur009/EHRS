export interface IUser {
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    MobileNumber: number;
    BirthDate: Date;
    Address: string;
    Roles: IUserRole[];
}

export interface IUserRole {
    Id: number;
    Name: string;
}

export interface IUserList {
    Users: IUser[]
}
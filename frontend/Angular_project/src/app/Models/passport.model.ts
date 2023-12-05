import { IUser } from "./user.model";

export interface IPassport{
    id: string;
    series: number;
    number: number;
    firstName: string;
    lastName: string;
    futherName: string;
    birthdayDate: Date;
    issuedDate: Date;


    user: IUser;
    userId: string; // Используйте string вместо Guid

}
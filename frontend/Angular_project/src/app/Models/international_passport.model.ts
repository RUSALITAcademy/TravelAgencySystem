import { IUser } from "./user.model";

export interface IInternationalPassport{
    id: string;
    series: number;
    number: number;
    firstName: string;
    lastName: string;
    futherName: string;
    birthdayDate: Date;
    issuedDate: Date;
    validUntilDate: Date;

    
    user: IUser;
    userId: string;
}
import { IInternationalPassport } from "./international_passport.model";
import { IPassport } from "./passport.model";

export interface IUser {
        id: string;
        name: string;
        email: string;
        password: string;
        imgUrl: string;

        passport: IPassport;
        internationalPassport: IInternationalPassport;
}
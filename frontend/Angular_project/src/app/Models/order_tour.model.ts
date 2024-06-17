import { ITour } from "./tour.model";
import { IUser } from "./user.model";

export interface IOrder {
  orderId?: string;
  user?: IUser;
  userId?: string;
  tour?: ITour;
  tourId?: string;
  registrationDate?: Date;
  status?: number;
}

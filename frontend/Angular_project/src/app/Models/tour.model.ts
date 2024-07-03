import { IImage } from "./image.mode";
import { IOrder } from "./order.model";

export interface ITour {
  tourId: string;
  name: string;
  description: string;
  country: string;
  region: string;
  startDate: Date;
  endDate: Date;
  price: number;
  quantity: number;
  images: IImage[];
  mainImageUrl: string;
  status: number;
  orders?: IOrder[];
}

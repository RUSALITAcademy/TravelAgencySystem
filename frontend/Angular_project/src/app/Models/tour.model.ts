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
    imgUrl: string;
}
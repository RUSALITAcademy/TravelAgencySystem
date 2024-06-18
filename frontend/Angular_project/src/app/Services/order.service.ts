import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IOrder } from '../Models/order.model';

@Injectable({
    providedIn: 'root'
})
export class OrderService {

    private apiUrl: string // Адрес API

    constructor(private http: HttpClient) { this.apiUrl = environment.apiUrl + "/api/Order" }

    ////
    GetAllOrders(body?: object): Observable<IOrder[]> {
        return this.http.post<IOrder[]>(this.apiUrl + "/GetAllOrders", body);
    }

    GetOrderById(id: string): Observable<IOrder | undefined> {
        const url = `${this.apiUrl}/GetOrder/${id}`;
        return this.http.get<IOrder>(url);
    }

    GetAllOrdersFromUser(): Observable<any> {
        return this.http.get<IOrder[]>(`${this.apiUrl}/GetAllOrdersFromUser`)
    }
    ////

    ////
    CreateOrder(order: IOrder): Observable<IOrder> {
        return this.http.post<IOrder>(this.apiUrl + "/CreateOrder", order);
    }
    ////

    ////
    UpdateOrder(order: IOrder): Observable<IOrder> {
        const url = `${this.apiUrl}/UpdateOrder/${order.orderId}`;
        return this.http.put<IOrder>(url, order);
    }
    ////

    ////
    DeleteOrder(id: string): Observable<void> {
        const url = `${this.apiUrl}/DeleteOrder/${id}`;
        return this.http.delete<void>(url);
    }
    ////
}

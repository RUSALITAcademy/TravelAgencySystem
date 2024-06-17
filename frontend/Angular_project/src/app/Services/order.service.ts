import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IOrder } from '../Models/order_tour.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl: string // Адрес API

  constructor(private http: HttpClient) { this.apiUrl = environment.apiUrl + "/api/Order/" }

  GetAllOrdersFromUser(): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.apiUrl + "GetAllOrdersFromUser");
  }
}

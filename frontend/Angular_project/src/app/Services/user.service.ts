import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUser } from '../Models/user.model';
import { Observable } from 'rxjs';
import { IOrder } from '../Models/order.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: string // Адрес API

  constructor(private http: HttpClient) { this.apiUrl = environment.apiUrl + "/api/User" }

  getUser(): Observable<IUser | undefined> {
    const url = `${this.apiUrl}/GetUser`;
    return this.http.get<IUser>(url);
  }
  ////

  ////
  updateUser(user: IUser): Observable<IUser> {
    const url = `${this.apiUrl}/UpdateUser`;
    return this.http.put<IUser>(url, user);
  }
  ////

  ////
  changePassword(password: IPassword): Observable<void> {
    const url = `${this.apiUrl}/UpdatePasswordUser`;
    return this.http.put<void>(url, password);
  }
  ////

  GetAllOrdersFromUser(): Observable<any> {
    // return this.http.get<IOrder[]>(this.apiUrl + "/GetAllOrdersFromUser");
    return this.http.get<any>("https://localhost:7271/api/Order/GetAllOrdersFromUser");
  }
}

interface IPassword {
  currentPassword: string,
  newPassword: string
}

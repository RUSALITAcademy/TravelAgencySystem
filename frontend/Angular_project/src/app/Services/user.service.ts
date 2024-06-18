import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUser } from '../Models/user.model';
import { Observable } from 'rxjs';

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
}

interface IPassword {
  currentPassword: string,
  newPassword: string
}

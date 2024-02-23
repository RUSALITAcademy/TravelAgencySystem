import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = "https://localhost:7271";
  userAuth: AuthResponse = {

  };
  constructor(private httpClient: HttpClient) { }

  login(name: string, password: string): boolean {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    this.httpClient.post<AuthResponse>(this.url + "/login", '{"email":"' + name + '","password":"' + password + '"}', httpOptions).subscribe(response => {
      this.userAuth.accessToken = response.accessToken;
      this.userAuth.refreshToken = response.refreshToken;

    }
    )
    return true
  }
}

interface AuthResponse {
  accessToken?: string,
  refreshToken?: string

}
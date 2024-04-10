import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { StorageService } from './storage.service';
import { Observable, delay, tap } from 'rxjs';
import { Router } from '@angular/router';

const USER_KEY = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl: string; // Адрес API

  constructor(
    private httpClient: HttpClient,
    private storageService: StorageService,
    private router: Router,
  ) {
    this.apiUrl = environment.apiUrl;
  }

  public login(login: string, password: string): Observable<AuthResponse> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    const bodyRequest = {
      email: login,
      password: password
    };
    return this.httpClient.post<AuthResponse>(this.apiUrl + "/login", bodyRequest, httpOptions)
  }

  //!
  public register(login: string, password: string): Observable<AuthResponse> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    const bodyRequest = {
      email: login,
      password: password
    };
    return this.httpClient.post<AuthResponse>(this.apiUrl + "/register", bodyRequest, httpOptions)
  }

  public refreshToken(): Observable<AuthResponse> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    const refreshToken = this.storageService.getRefreshToken();

    return this.httpClient.post<AuthResponse>(this.apiUrl + '/refresh', { refreshToken: refreshToken }, httpOptions).pipe(tap(responseData => {
      this.storageService.saveToken(responseData)
    }), delay(200));
  }

  public logout() {
    this.storageService.isLoggedOut();
    window.localStorage.removeItem(USER_KEY)
    this.router.navigate(['/auth']);
  }
}

type AuthResponse = {
  accessToken?: string,
  refreshToken?: string
}

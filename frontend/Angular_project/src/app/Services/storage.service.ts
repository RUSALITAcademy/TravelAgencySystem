import { Injectable } from '@angular/core';

const USER_KEY = 'token';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  clean(): void {
    window.localStorage.clear();
  }

  public saveToken(user: any): void {
    window.localStorage.removeItem(USER_KEY);
    window.localStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getToken(): any {
    const user = window.localStorage.getItem(USER_KEY);
    if (user) { return JSON.parse(user).accessToken; }
  }

  public getRefreshToken(): any {
    const user = window.localStorage.getItem(USER_KEY);
    if (user) { return JSON.parse(user).refreshToken; }
  }

  public isLoggedIn(): boolean {
    const user = window.localStorage.getItem(USER_KEY);
    if (user) {
      return true;
    }
    return false;
  }

  public isLoggedOut() {
    window.localStorage.removeItem(USER_KEY);
  }
}

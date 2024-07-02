import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITour } from '../Models/tour.model';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private apiUrl: string // Адрес API

  constructor(private http: HttpClient) { this.apiUrl = environment.apiUrl + "/api/Tour" }

  ////
  GetAllTours(body?: object): Observable<ITour[]> {
    return this.http.post<ITour[]>(this.apiUrl + "/GetAllTours", body);
  }

  GetTourById(id: string): Observable<ITour | undefined> {
    const url = `${this.apiUrl}/GetTour/${id}`;
    return this.http.get<ITour>(url);
  }

  GetUserTours(): Observable<any> {
    return this.http.get<ITour[]>(`${this.apiUrl}/GetUserTours`);
  }
  ////

  ////
  CreateTour(tour: ITour): Observable<ITour> {
    return this.http.post<ITour>(this.apiUrl + "/CreateTour", tour);
  }
  ////

  ////
  UpdateTour(tour: ITour): Observable<ITour> {
    const url = `${this.apiUrl}/UpdateTour/${tour.tourId}`;
    return this.http.put<ITour>(url, tour);
  }
  ////

  ////
  DeleteTour(id: string): Observable<void> {
    const url = `${this.apiUrl}/DeleteTour/${id}`;
    return this.http.delete<void>(url);
  }
  ////
}

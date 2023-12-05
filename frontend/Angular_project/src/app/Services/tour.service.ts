import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITour } from '../Models/tour.model';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private apiUrl = "https://localhost:7271/api/Tour";  // Адрес API

  constructor(private http: HttpClient) { }


  ////
  GetAllTours(): Observable<ITour[]> {
    return this.http.get<ITour[]>(this.apiUrl + "/GetAllTours");
  }


  GetTourById(id: string): Observable<ITour | undefined> {
    const url = `${this.apiUrl}/GetTour/${id}`;
    return this.http.get<ITour>(url);
  }
  ////



  ////
  CreateTour(tour: ITour): Observable<ITour> {
    console.log(tour)
    return this.http.post<ITour>(this.apiUrl + "/CreateTour", tour);
  }
  ////


  ////
  UpdateTour(tour: ITour): Observable<ITour> {
    const url = `${this.apiUrl}/UpdateTour/${tour.id}`;
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

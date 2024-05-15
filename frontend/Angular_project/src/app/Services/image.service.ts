import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private apiUrl: string // Адрес API

  constructor(private http: HttpClient) { this.apiUrl = environment.apiUrl + "/api/images" }

  ////
  GetImagesNames(tourId: string): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/tour_images/" + tourId);
  }

  GetImageByFileName(name: string): Observable<any> {
    const url = `${this.apiUrl}/${name}`;
    return this.http.get<any>(url);
  }
  ////

  ////
  CreateImage(file: File, tourId: number): Observable<any> {
    let body = { file, tourId }
    return this.http.post<any>(this.apiUrl + "/images", body);
  }
  ////
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  GetImage(tourId: string): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/tour_image/" + tourId);
  }

  GetImageByFileName(name: string): string {
    const url = `${this.apiUrl}/${name}`;
    return url;
  }
  ////

  ////
  CreateImage(file: FormData, tourId: string): Observable<any> {
    return this.http.post<any>(this.apiUrl + '/' + tourId, file);
  }
  ////
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GeonamesService {

  constructor(private http: HttpClient) { }


  getCities(options: { name: string }) {
    const apiUrl = `http://api.geonames.org/searchJSON?username=itproject&featureClass=P&maxRows=5&lang=ru&style=short&name_startsWith=${options.name}`;
    return this.http.get<any>(apiUrl)
  }
}

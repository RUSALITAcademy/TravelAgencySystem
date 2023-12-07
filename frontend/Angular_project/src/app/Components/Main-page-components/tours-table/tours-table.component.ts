import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { ITour } from 'src/app/Models/tour.model';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-tours-table',
  templateUrl: './tours-table.component.html',
  styleUrls: ['./tours-table.component.scss']
})
export class ToursTableComponent implements OnInit {
  //сделать контролы и отслеживание на изминение
  departureLocation = this.fb.control<string>('');
  destinationLocation = this.fb.control<string>('');
  departureDate: Date | null = null;
  returnDate: Date | null = null;
  showReturnDate: boolean = true;
  toursIsVisiable: boolean = false;
  passengerCount: number = 0;

  tours: ITour[] = [];


  departureLocations: string[] = ['Москва', 'Сочи', 'Красноярск', 'Санкт-Петербург', 'Новосибирск',];
  destinationLocations: string[] = ['Осло', 'Мадрид', 'Лондон', 'Париж', 'Маями',];



  search() {
    this.toursIsVisiable = true;
    // Реализация поиска с использованием выбранных значений фильтров

    this.tourService.GetAllTours().subscribe((tours: any) => {
      this.tours = tours['tours'];
      this.tours = this.tours.filter((tour: any) => {

        const tourStartDate = this.departureDate ? formatDate(this.departureDate) : null;
        const tourEndDate = this.returnDate ? formatDate(this.returnDate) : null;
        // Фильтрация по startDate и endDate и destinationLocation
        const filtered =
          (!tourStartDate || (formatDate(new Date(tour.startDate)) >= tourStartDate)) &&
          (!tourEndDate || (formatDate(new Date(tour.endDate)) <= tourEndDate)) &&
          (!this.destinationLocation.value || (tour.region == this.destinationLocation.value));

        return filtered;
      });
    });
  }

  constructor(private http: HttpClient,
    private fb: FormBuilder,
    private tourService: TourService) { }

  ngOnInit() {

    this.toursIsVisiable = false;

    this.departureLocation.valueChanges.subscribe(() => {
      console.log(this.departureLocation.value)
      if (this.departureLocation.value !== null) {

        this.getCities({ name: this.departureLocation.value.toLocaleLowerCase() })
          .subscribe((response) => {
            this.departureLocations = [];
            console.log(response);
            this.departureLocations = response.geonames.filter((city: City, index: number, self: Array<City>) =>
              index === self.findIndex((c) => c.name === city.name)
            )
              .map((city: City) => city.name);
          });
      }
    });

    this.destinationLocation.valueChanges.subscribe(() => {
      console.log(this.destinationLocation.value)
      if (this.destinationLocation.value !== null) {

        this.getCities({ name: this.destinationLocation.value.toLocaleLowerCase() })
          .subscribe((response) => {
            this.destinationLocations = [];
            console.log(response);
            this.destinationLocations = response.geonames.filter((city: City, index: number, self: Array<City>) =>
              index === self.findIndex((c) => c.name === city.name)
            )
              .map((city: City) => city.name);
          });
      }
    });
  }



  getCities(options: { name: string }) {
    const apiUrl = `http://api.geonames.org/searchJSON?username=itproject&featureClass=P&maxRows=5&lang=ru&style=short&name_startsWith=${options.name}`;
    return this.http.get<any>(apiUrl)
  }



}
function formatDate(date: Date | null): string {
  if (date instanceof Date) {
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();

    return `${day}.${month}.${year}`;
  }

  return ''; // или какое-то другое значение по умолчанию, в зависимости от ваших требований
}

interface City {
  name: string;
}

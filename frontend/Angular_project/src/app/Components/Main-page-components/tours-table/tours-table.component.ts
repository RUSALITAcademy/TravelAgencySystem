import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ITour } from 'src/app/Models/tour.model';
import { TourService } from 'src/app/Services/tour.service';
import { GeonamesService } from 'src/app/Services/geonames.service';

@Component({
  selector: 'app-tours-table',
  templateUrl: './tours-table.component.html',
  styleUrls: ['./tours-table.component.scss']
})
export class ToursTableComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private tourService: TourService,
    private geonamesService: GeonamesService,) { }

  //сделать контролы и отслеживание на изминение
  departureLocation = this.fb.control<string>('');
  destinationLocation = this.fb.control<string>('');

  departureDate: Date | null = null;
  returnDate: Date | null = null;
  showReturnDate: boolean = true;
  toursIsVisiable: boolean = false;
  passengerCount: number = 1;

  tours: ITour[] = [];


  departureLocations: string[] = ['Москва', 'Сочи', 'Красноярск', 'Санкт-Петербург', 'Новосибирск',];
  destinationLocations: string[] = ['Осло', 'Мадрид', 'Лондон', 'Париж', 'Маями',];

  ngOnInit() {

    this.toursIsVisiable = false;

    this.departureLocation.valueChanges.subscribe(() => {

      if (this.departureLocation.value !== null) {

        this.getFiltredCities(this.departureLocation.value, this.departureLocations)
      }
    });

    this.destinationLocation.valueChanges.subscribe(() => {

      if (this.destinationLocation.value !== null) {

        this.getFiltredCities(this.destinationLocation.value, this.destinationLocations)
      }
    });
  }

  search() {
    this.toursIsVisiable = true;
    // Реализация поиска с использованием выбранных значений фильтров

    this.tourService.GetAllTours().subscribe((tours: any) => {
      this.tours = tours['tours'];
      this.tours = this.tours.filter((tour: ITour) => {

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

  getFiltredCities(cityName: String, locations: Array<string>) {

    this.geonamesService.getCities({ name: cityName.toLocaleLowerCase() }).subscribe((response) => {

      locations = [];
      locations = response.geonames.filter((city: City, index: number, self: Array<City>) =>
        index === self.findIndex((c) => c.name === city.name)
      ).map((city: City) => city.name);
    });
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

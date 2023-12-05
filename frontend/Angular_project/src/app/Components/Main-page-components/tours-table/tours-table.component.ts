import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map, distinct } from 'rxjs/operators';
import { ITour } from 'src/app/Models/tour.model';

@Component({
  selector: 'app-tours-table',
  templateUrl: './tours-table.component.html',
  styleUrls: ['./tours-table.component.scss']
})
export class ToursTableComponent implements OnInit {
  //сделать контролы и отслеживание на изминение
  departureLocation = this.fb.control<string>('');
  destinationLocation= this.fb.control<string>('');
  departureDate: Date | null = null;
  returnDate: Date | null = null;
  showReturnDate: boolean = true;
  toursIsVisiable: boolean = false;
  passengerCount: number = 0;

  tours: ITour[] = [];
  imageUrl = 'https://thailand-good.ru/wp-content/uploads/a/f/e/afe71d653e8f8bd0f4eb10082eacc797.jpeg';


  departureLocations: string[] = ['Москва', 'Сочи', 'Красноярск', 'Санкт-Петербург', 'Новосибирск',];
  destinationLocations : string[] = ['Осло', 'Мадрид', 'Лондон', 'Париж', 'Маями',];


  
  search() {
    this.toursIsVisiable = true;
    // Реализация поиска с использованием выбранных значений фильтров
  }

  constructor(private http: HttpClient,
    private fb: FormBuilder) { }

  ngOnInit() {

    //! тест
    const newTour: ITour = {
      id: "id",
      name : "Париж",
      description: "Прекрасный тур в самую романтическую страну на свете, отведайте вкуснейших багетов и круасанов",
      country: "Франция",
      region: "Центр Парижа",
      startDate: new Date("2023-12-30"),
      endDate: new Date("2024-01-03"),
      price: 500000,
      quantity: 10,
      ImgUrl: this.imageUrl,
  };
    this.tours.push(newTour);

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

interface City {
  name: string;
}

import { Component } from '@angular/core';
import { ITour } from 'src/app/Models/tour.model';
import { MatDialog } from '@angular/material/dialog';
import { CreateTourModalComponent } from '../create-tour-modal/create-tour-modal.component';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.scss']
})
export class ToursComponent {

  constructor(private tourService: TourService,
    private dialog: MatDialog) { }

  openCreateTourModal(): void {
    const dialogRef = this.dialog.open(CreateTourModalComponent, {
      width: '60%',
      height: '80%',
      data: {} as ITour,
      backdropClass: 'custom-dialog-container',
    });

    // dialogRef.afterClosed().subscribe((newTour: ITour) => {
    //   if (newTour) {
    //     //this.tourService.
    //   }
    // });
  }


  tours: ITour[] = [{
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "2",
    name: "Горные вершины",
    description: "Вершины мира",
    country: "Непал",
    region: "Гималаи",
    startDate: new Date(2024, 3, 15),
    endDate: new Date(2024, 3, 25),
    price: 189999,
    quantity: 50,
    imgUrl: ["5678", "91011"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  {
    tourId: "1",
    name: "Бескрайние поля",
    description: "Самые бескрайние",
    country: "Россия",
    region: "Красноярск",
    startDate: new Date(2024, 1, 1),
    endDate: new Date(2024, 1, 12),
    price: 214321,
    quantity: 111,
    imgUrl: ["1234", "2134"],
  },
  ]
}

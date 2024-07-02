import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ITour } from 'src/app/Models/tour.model';
import { CreateTourDialogComponent } from '../../create-tour-dialog/create-tour-dialog.component';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.scss']
})
export class ToursComponent implements OnInit {
  constructor(public dialog: MatDialog,
    private tourService: TourService,
  ) {

  }

  tours: ITour[] = [];

  ngOnInit() {
    this.getToursByUser();
  }

  getToursByUser() {
    return this.tourService.GetUserTours().subscribe((list) => {
      this.tours = list.tours;
    });
  }

  deleteTour(id: string) {
    return this.tourService.DeleteTour(id).subscribe(() => {
      this.getToursByUser();
    });
  }

  changeTourStatus(tour: ITour) {
    if (tour.status == 0) {
      tour.status = 1;
    }
    else {
      tour.status = 0;
    }
    return this.tourService.UpdateTour(tour).subscribe(() => {
      this.getToursByUser();
    });
  }

  openCreateTourDialog() {
    const dialogRef = this.dialog.open(CreateTourDialogComponent, {
      width: '80%',
      height: '90%',
      backdropClass: 'dialog-backdrop'
    })

    dialogRef.afterClosed().subscribe(() => {
      this.getToursByUser();
    })

  }

}

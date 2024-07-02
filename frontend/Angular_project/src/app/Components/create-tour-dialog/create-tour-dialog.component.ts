import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-create-tour-dialog',
  templateUrl: './create-tour-dialog.component.html',
  styleUrls: ['./create-tour-dialog.component.scss'],
})
export class CreateTourDialogComponent {
  constructor(private fb: FormBuilder,
    private tourService: TourService,
  ) {
    this.tourForm = this.fb.group({
      name: [],
      description: [],
      country: [],
      region: [],
      startDate: [],
      endDate: [],
      quantity: [],
      price: [],
      status: [1],
    })
  }

  tourForm: FormGroup;

  createTour() {
    return this.tourService.CreateTour(this.tourForm.value).subscribe();
  }

}

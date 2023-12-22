import { Component, Input, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatStepperModule } from '@angular/material/stepper';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TourService } from 'src/app/Services/tour.service';
import { ActivatedRoute } from '@angular/router';
import { ITour } from 'src/app/Models/tour.model';



@Component({
  selector: 'app-order-stepper',
  templateUrl: './order-stepper.component.html',
  styleUrls: ['./order-stepper.component.scss'],
  standalone: true,
  imports: [
    MatButtonModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    CommonModule
  ],
})
export class OrderStepperComponent implements OnInit  { 
  tourId!:string;
  tour: ITour = {} as ITour;
  // FormGroup для первого шага (паспорт)
  firstFormGroup!: FormGroup;

  // FormGroup для второго шага (заграничный паспорт)
  secondFormGroup!: FormGroup;
  isLinear = true;

  constructor(private _formBuilder: FormBuilder, private route: ActivatedRoute, private tourService: TourService) {}
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.tourId = String(params['id']);
    });
    this.tourService.GetTourById(this.tourId).subscribe((tourData) => {
      this.tour = tourData || {} as ITour
    });
    // Инициализация FormGroup для первого шага
    this.firstFormGroup = this._formBuilder.group({
      series: ['', Validators.required],
      number: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      patronymic: ['', Validators.required]
    });

    // Инициализация FormGroup для второго шага
    this.secondFormGroup = this._formBuilder.group({
      passportSeries: ['', Validators.required],
      passportNumber: ['', Validators.required],
      passportFirstName: ['', Validators.required],
      passportLastName: ['', Validators.required],
      passportPatronymic: ['', Validators.required]
    });
  }
}

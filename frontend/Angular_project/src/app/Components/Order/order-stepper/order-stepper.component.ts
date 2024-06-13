import { Component, Input, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatError, MatFormFieldModule } from '@angular/material/form-field';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TourService } from 'src/app/Services/tour.service';
import { ActivatedRoute } from '@angular/router';
import { ITour } from 'src/app/Models/tour.model';
import { ImageService } from 'src/app/Services/image.service';
import { concatMap, from } from 'rxjs';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { OrderService } from 'src/app/Services/order.service';
import { IOrder } from 'src/app/Models/order.model';



@Component({
  selector: 'app-order-stepper',
  templateUrl: './order-stepper.component.html',
  styleUrls: ['./order-stepper.component.scss'],
  standalone: true,
  imports: [
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    CommonModule,
    NgxMaskDirective,
    MatCheckboxModule

  ],
  providers: [provideNgxMask()]
})
export class OrderStepperComponent implements OnInit {
  tourId!: string;
  tour: ITour = {} as ITour;
  isLinear = true;

  constructor(
    private route: ActivatedRoute,
    private tourService: TourService,
    private imageService: ImageService,
    private orderService: OrderService,
    private fb: FormBuilder
  ) {
    this.orderForm = this.fb.group({
      number_phone: ['', Validators.required],
      has_children: [null, Validators.required],
      number_of_people: [null, Validators.required],
    });
    this.userForm = this.fb.group({
      first_name: ['', Validators.required],
      last_name: ['', Validators.required],
      middle_name: [''],
    });
  }

  orderForm: FormGroup;
  userForm: FormGroup;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.tourId = String(params['id']);
    });
    this.tourService.GetTourById(this.tourId).subscribe((tourData) => {
      this.tour = tourData || {} as ITour

      this.imageService.GetImage(this.tour.tourId).subscribe((element) => {
        this.tour.mainImageUrl = this.imageService.GetImageByFileName(element.fileName);
      })
    });
  }

  createOrder() {
    const formValue = this.orderForm.getRawValue();
    const order: IOrder = {
      userId: '',
      tourId: this.tour.tourId,
      registrationStartDate: new Date(),
      registrationEndDate: undefined,
      numberPhone: formValue.number_phone,
      status: 0,
      hasChildren: formValue.has_children,
      numberOfPeople: formValue.number_of_people
    }
    return this.orderService.CreateOrder(order).subscribe(() => {

    })
  }

  validateNumberInput(event: any) {
    const input = event.target;
    if (input.value < 0) {
      input.value = '';
    }
  }

  preventNegativeInput(event: KeyboardEvent) {
    if (event.key === '-' || event.key === 'Minus') {
      event.preventDefault();
    }
  }
}

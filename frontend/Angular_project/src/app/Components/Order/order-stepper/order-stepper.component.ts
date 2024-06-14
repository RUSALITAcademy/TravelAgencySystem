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
import { UserService } from 'src/app/Services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { RouterDialogComponent } from '../../router-dialog/router-dialog.component';



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
    MatCheckboxModule,

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
    private userService: UserService,
    private fb: FormBuilder,
    private dialog: MatDialog,
  ) { }

  userForm: FormGroup = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    middleName: ['',],
    userName: ['',],
  });

  orderForm: FormGroup = this.fb.group({
    number_phone: ['', Validators.required],
    has_children: [false],
    number_of_people: [null, Validators.required],
  });

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.tourId = String(params['id']);
    });
    this.userService.getUser().subscribe((user) => {
      this.userForm.patchValue({
        firstName: user.firstName,
        lastName: user.lastName,
        middleName: user.middleName,
        userName: user.email,
      });
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
      tourId: this.tour.tourId,

      numberPhone: formValue.number_phone,
      hasChildren: formValue.has_children,
      numberOfPeople: formValue.number_of_people
    }
    console.log(order)
    return this.orderService.CreateOrder(order).subscribe(() => {
      this.updateUserName();
      const dialogRef = this.dialog.open(RouterDialogComponent, {
        height: '20%',
        width: '20%',
        disableClose: true,
        backdropClass: 'dialog-backdrop'
      })
    })
  }

  updateUserName() {
    return this.userService.updateUser(this.userForm.value).subscribe();
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

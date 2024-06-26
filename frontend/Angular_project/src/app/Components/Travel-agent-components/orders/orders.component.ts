import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order.model';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  // orders: IOrder[];
  orders: IOrder[] = [{
    orderId: '123',
    userId: '1',
    tourId: '1',
    registrationStartDate: new Date(),
    registrationEndDate: new Date(),
    status: 1,
    numberPhone: '1234567890',
    hasChildren: false,
    numberOfPeople: 2
  },
  {
    orderId: '123',
    userId: '1',
    tourId: '1',
    registrationStartDate: new Date(),
    registrationEndDate: new Date(),
    status: 1,
    numberPhone: '1234567890',
    hasChildren: false,
    numberOfPeople: 2
  }];

  constructor(
    private orderService: OrderService,
  ) { }

  ngOnInit(): void {
    this.orderService.GetAllOrders
  }


}

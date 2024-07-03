import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order.model';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  constructor(
    private orderService: OrderService,
  ) { }

  ngOnInit(): void {
    this.orderService.GetAllOrdersFromAgent().subscribe((orders => {
      this.orders = orders.orders;
    }));
  }


}

import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order.model';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-account-travel-history',
  templateUrl: './account-travel-history.component.html',
  styleUrls: ['./account-travel-history.component.scss']
})
export class AccountTravelHistoryComponent implements OnInit {
  constructor(
    private orderService: OrderService,
  ) {

  }

  orders: IOrder[] = [];


  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(id?: string) {
    return this.orderService.GetAllOrdersFromUser(id).subscribe((result) => {
      this.orders = result;
    })
  }

}

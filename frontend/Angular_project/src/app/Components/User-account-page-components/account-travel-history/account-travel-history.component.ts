import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order_tour.model';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-account-travel-history',
  templateUrl: './account-travel-history.component.html',
  styleUrls: ['./account-travel-history.component.scss']
})
export class AccountTravelHistoryComponent implements OnInit {
  orders?: IOrder[];

  constructor(
    private orderService: OrderService,
  ) {
  }

  ngOnInit() {

    this.orderService.GetAllOrdersFromUser().subscribe((orders) => {
      this.orders = orders;
    });
  }

}

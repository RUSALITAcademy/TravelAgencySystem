import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order.model';
import { UserService } from 'src/app/Services/user.service';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-account-travel-history',
  templateUrl: './account-travel-history.component.html',
  styleUrls: ['./account-travel-history.component.scss']
})
export class AccountTravelHistoryComponent implements OnInit {
  constructor(
    private orderService: OrderService,
    private userService: UserService,
  ) {

  }

  orders: IOrder[] = [];


  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    return this.orderService.GetAllOrdersFromUser().subscribe((result) => {
      this.orders = result?.orders;
    })
  }

  transform(value: number): string {
    switch (value) {
      case 0:
        return 'В ожидании ответа';
      case 1:
        return 'Подтвержден';
      case 2:
        return 'Завершен';
      case 3:
        return 'Отменен';
      default:
        return 'Неизвестный статус';
    }
  }

}

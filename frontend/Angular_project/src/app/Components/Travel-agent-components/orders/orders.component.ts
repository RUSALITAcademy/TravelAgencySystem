import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order.model';
import { OrderService } from 'src/app/Services/order.service';
import { SnackbarComponent } from '../../Common/snackbar/snackbar.component';
import { MatSnackBar } from '@angular/material/snack-bar';

const STATUSES: { [key: number]: string } = {
  0: "в ожидании",
  1: "Принят",
  2: "Выполнен",
  3: "Отклонён",
};

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  statuses = STATUSES;

  constructor(
    private orderService: OrderService,
    private snackBar: MatSnackBar,
  ) { }

  ngOnInit(): void {
    this.GetAllOrdersFromAgent();
  }

  GetAllOrdersFromAgent() {
    this.orderService.GetAllOrdersFromAgent().subscribe((orders => {
      this.orders = orders.orders;
    }));
  }


  onAcceptOrder(order: IOrder) {
    order.status = 1;
    order.registrationEndDate = new Date();
    delete order.tour

    this.orderService.UpdateOrder(order).subscribe({
      next: () => {
        this.openSnackBar('Заявка успешно принята')
        this.GetAllOrdersFromAgent();
      },
      error: (err) => {
        this.openSnackBar('Произошла ошибка при принятии, попробуйте ещё раз')
        console.error(err);
      },
    });
  }

  onRejectOrder(order: IOrder) {
    order.status = 3;
    order.registrationEndDate = new Date();

    this.orderService.UpdateOrder(order).subscribe({
      next: () => {
        this.openSnackBar('Заявка успешно отклонена')
        this.GetAllOrdersFromAgent();
      },
      error: (err) => {
        this.openSnackBar('Произошла ошибка при отклонении, попробуйте ещё раз')
        console.error(err);
      },
    });
  }

  openSnackBar(text: string) {
    this.snackBar.openFromComponent(SnackbarComponent, {
      data: text,
      duration: 3000
    });
  }
}

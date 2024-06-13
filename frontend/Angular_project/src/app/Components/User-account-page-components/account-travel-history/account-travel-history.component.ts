import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/Models/order_tour.model';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-account-travel-history',
  templateUrl: './account-travel-history.component.html',
  styleUrls: ['./account-travel-history.component.scss']
})
export class AccountTravelHistoryComponent implements OnInit {
  orders?: IOrder[];

  constructor(
    private userService: UserService,
  ) {
  }

  ngOnInit() {

    this.userService.GetAllTours().subscribe((orders) => {
      this.orders = orders;
    });
  }

}

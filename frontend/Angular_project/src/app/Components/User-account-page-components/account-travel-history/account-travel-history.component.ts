import { Component } from '@angular/core';
import { IOrder } from 'src/app/Models/order_tour.model';

@Component({
  selector: 'app-account-travel-history',
  templateUrl: './account-travel-history.component.html',
  styleUrls: ['./account-travel-history.component.scss']
})
export class AccountTravelHistoryComponent {
  orders?: IOrder[] = [{
    orderId: "1",
    tourId: "1",
    userId: "1",
    status: "Завершен",
    registrationDate: new Date(2024, 1, 1),
    tour: {
      tourId: "1",
      name: "Бархатные тяги",
      description: "Самые бархатные",
      country: "Россия",
      region: "Красноярск",
      startDate: new Date(2024, 1, 1),
      endDate: new Date(2024, 1, 12),
      price: 214321,
      quantity: 111,
      imgUrl: ["1234", "2134"],
    },
    user: {
      id: "1",
      name: "Nikita",
      email: "test@mail.ru",
      password: "test123",
      imgUrl: "12"
    }
  },
  {
    orderId: "2",
    tourId: "2",
    userId: "2",
    status: "Ожидание",
    registrationDate: new Date(2024, 3, 15),
    tour: {
      tourId: "2",
      name: "Горные вершины",
      description: "Вершины мира",
      country: "Непал",
      region: "Гималаи",
      startDate: new Date(2024, 3, 15),
      endDate: new Date(2024, 3, 25),
      price: 189999,
      quantity: 50,
      imgUrl: ["5678", "91011"],
    },
    user: {
      id: "2",
      name: "Александр",
      email: "alex@mail.ru",
      password: "alex123",
      imgUrl: "34"
    },

  },
  {
    orderId: "3",
    tourId: "3",
    userId: "3",
    status: "Активный",
    registrationDate: new Date(2024, 5, 20),
    tour: {
      tourId: "3",
      name: "Пляжный отдых",
      description: "Солнечные пляжи",
      country: "Таиланд",
      region: "Пхукет",
      startDate: new Date(2024, 5, 20),
      endDate: new Date(2024, 5, 30),
      price: 159999,
      quantity: 80,
      imgUrl: ["121314", "151617"],
    },
    user: {
      id: "3",
      name: "Екатерина",
      email: "katya@mail.ru",
      password: "katya123",
      imgUrl: "56"
    }
  }];




}

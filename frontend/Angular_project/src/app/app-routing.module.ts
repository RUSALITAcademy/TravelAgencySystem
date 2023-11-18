import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthPageComponent } from './Pages/Auth-page/auth-page.component';
import { MainPageComponent } from './Pages/Main-page/main-page.component';
import { TourPageComponent } from './Pages/Tour-page/tour-page.component';
import { UserAccountPageComponent } from './Pages/User-account-page/user-account-page.component';
import { PaymentPageComponent } from './Pages/Payment-page/payment-page.component';

const routes: Routes = [

  { path: "auth", component: AuthPageComponent },
  { path: "account", component: UserAccountPageComponent },
  { path: "main", component: MainPageComponent },
  { path: "tour", component: TourPageComponent },
  { path: "payment", component: PaymentPageComponent },
  { path: "**", redirectTo: 'auth', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

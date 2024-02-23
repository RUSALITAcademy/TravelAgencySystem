import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthPageComponent } from './Pages/Auth-page/auth-page.component';
import { MainPageComponent } from './Pages/Main-page/main-page.component';
import { TourPageComponent } from './Pages/Tour-page/tour-page.component';
import { PaymentPageComponent } from './Pages/Payment-page/payment-page.component';

//личный кабинет
import { UserAccountPageComponent } from './Pages/User-account-page/user-account-page.component';
import { AccountSettingsComponent } from './Components/User-account-page-components/account-settings/account-settings.component';
import { AccountTravelHistoryComponent } from './Components/User-account-page-components/account-travel-history/account-travel-history.component';
//личный кабинет

const routes: Routes = [

  { path: "auth", component: AuthPageComponent },
  {
    path: "account", component: UserAccountPageComponent,
    children: [
      { path: '', redirectTo: 'account', pathMatch: 'full' },
      { path: "settings", component: AccountSettingsComponent },
      { path: "history", component: AccountTravelHistoryComponent },
    ]
  },
  { path: "main", component: MainPageComponent },
  { path: "tour/:id", component: TourPageComponent },
  { path: "payment/:id", component: PaymentPageComponent },
  { path: "**", redirectTo: 'auth', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

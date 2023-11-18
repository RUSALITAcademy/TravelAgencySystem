import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/Common/navbar/navbar.component';
import { AuthPanelComponent } from './Components/Auth-page-components/auth-panel/auth-panel.component';

import { MainPageComponent } from './Pages/Main-page/main-page.component';
import { AuthPageComponent } from './Pages/Auth-page/auth-page.component';
import { PaymentPageComponent } from './Pages/Payment-page/payment-page.component';
import { UserAccountPageComponent } from './Pages/User-account-page/user-account-page.component';
import { TourPageComponent } from './Pages/Tour-page/tour-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthPanelComponent,
    //Страницы
    MainPageComponent,
    AuthPageComponent,
    PaymentPageComponent,
    UserAccountPageComponent,
    TourPageComponent,
    NavbarComponent,
    //Страницы


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

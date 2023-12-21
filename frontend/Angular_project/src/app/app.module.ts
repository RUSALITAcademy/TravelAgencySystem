import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/Common/navbar/navbar.component';
import { AuthPanelComponent } from './Components/Auth-page-components/auth-panel/auth-panel.component';

import { MainPageComponent } from './Pages/Main-page/main-page.component';
import { AuthPageComponent } from './Pages/Auth-page/auth-page.component';
import { PaymentPageComponent } from './Pages/Payment-page/payment-page.component';
import { UserAccountPageComponent } from './Pages/User-account-page/user-account-page.component';
import { TourPageComponent } from './Pages/Tour-page/tour-page.component';
import { ToursTableComponent } from './Components/Main-page-components/tours-table/tours-table.component';

import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

import { TourMainComponent } from './Components/Tour-page-components/tour-main/tour-main.component';
import { OrderStepperComponent } from "./Components/Order/order-stepper/order-stepper.component";

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
        ToursTableComponent,
        TourMainComponent,
        //Страницы
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        MatInputModule,
        MatAutocompleteModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatFormFieldModule,
        MatButtonModule,
        OrderStepperComponent
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

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
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';

import { TourMainComponent } from './Components/Tour-page-components/tour-main/tour-main.component';
import { OrderStepperComponent } from "./Components/Order/order-stepper/order-stepper.component";
import { AccountSettingsComponent } from './Components/User-account-page-components/account-settings/account-settings.component';
import { AccountTravelHistoryComponent } from './Components/User-account-page-components/account-travel-history/account-travel-history.component';
import { AuthService } from './Services/auth.service';
import { TokenInterceptorInterceptor } from './Services/token-interceptor.interceptor';
import { MatIconModule } from '@angular/material/icon';
import { ToursComponent } from './Components/Travel-agent-components/tours/tours.component';
import { TravelAgentPageComponent } from './Pages/Travel-agent-page/travel-agent-page.component';
import { NotFoundComponent } from './Pages/not-found/not-found.component';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { MatDividerModule } from '@angular/material/divider';
import { SnackbarComponent } from './Components/Common/snackbar/snackbar.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterDialogComponent } from './Components/router-dialog/router-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CabinetComponent } from './Components/Travel-agent-components/cabinet/cabinet.component';
import { OrdersComponent } from './Components/Travel-agent-components/orders/orders.component';

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
    AccountSettingsComponent,
    AccountTravelHistoryComponent,
    TravelAgentPageComponent,
    ToursComponent,
    NotFoundComponent,
    SnackbarComponent,
    CabinetComponent,
    OrdersComponent,
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
    OrderStepperComponent,
    MatIconModule,
    MatCheckboxModule,
    MatDividerModule,
    MatSnackBarModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatDialogModule,
    MatCardModule,
  ],
  providers: [AuthService, { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorInterceptor, multi: true },],
  bootstrap: [AppComponent]

})
export class AppModule { }

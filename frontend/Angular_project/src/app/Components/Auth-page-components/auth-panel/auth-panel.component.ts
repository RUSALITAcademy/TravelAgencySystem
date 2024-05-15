import { HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { StorageService } from 'src/app/Services/storage.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-auth-panel',
  templateUrl: './auth-panel.component.html',
  styleUrls: ['./auth-panel.component.scss']
})
export class AuthPanelComponent implements OnInit {

  constructor(
    private router: Router,
    private renderer: Renderer2,
    private el: ElementRef,
    private fb: FormBuilder,
    private authService: AuthService,
    private storageService: StorageService) { }

  isLoginFailed = false;
  isRegisterFailed = false;

  loginForm = this.fb.group({
    email: [""],
    password: [""],
  });

  registerForm = this.fb.group({
    name: [""],
    email: [""],
    password: [""],
    isTourAgency: [false],
  });

  ngOnInit(): void {
    const signUnButton = this.el.nativeElement.querySelector('#signUp');
    const signInButton = this.el.nativeElement.querySelector('#signIn');
    const container = this.el.nativeElement.querySelector('#container');

    signUnButton.addEventListener('click', () => {
      this.renderer.addClass(container, 'right-panel-active');
    });

    signInButton.addEventListener('click', () => {
      this.renderer.removeClass(container, 'right-panel-active');
    });
  }

  SignIn(loginForm: FormGroup) {

    const email = loginForm.value.email
    const password = loginForm.value.password

    this.authService.login(email, password).subscribe({
      next: data => {
        if (data && !environment.production) {
          this.storageService.saveToken(data);
        }

        this.authService.getUserInfo().subscribe({

          next: (user) => {
            if (user.roles?.includes('Admin')) {
              // this.router.navigate(['admin']);
            } else if (user.roles?.includes('TourAgency')) {
              this.router.navigate(['travelagent/tours']);
            } else if (user.roles?.includes('User')) {
              this.router.navigate(['main']);
            }
          },
          error: (err) => {
            console.log("Произошла ошибка - " + err)
          }

        });
      },
      error: (err) => {
        if (err instanceof HttpErrorResponse && err.status === 401) {
          this.isLoginFailed = true;
        }
      }
    });
  }

  SignUp(registerForm: FormGroup) {

    const name = registerForm.value.email;
    const password = registerForm.value.password;

    if (!registerForm.value.isTourAgency) {
      this.authService.userRegistration(name, password).subscribe({
        next: () => { },
        error: () => {
          this.isRegisterFailed = true;
        }
      });
    } else {
      this.authService.tourAgencyRegistration(name, password).subscribe({
        next: () => { },
        error: () => {
          this.isRegisterFailed = true;
        }
      });
    }
  }
}

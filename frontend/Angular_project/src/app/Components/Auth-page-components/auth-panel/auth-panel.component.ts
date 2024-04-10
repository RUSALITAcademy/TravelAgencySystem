import { HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { StorageService } from 'src/app/Services/storage.service';

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

  isLoginFailed: boolean = false;
  isRegisterFailed: boolean = false;

  loginForm = this.fb.group({
    email: [""],
    password: [""],
  });

  registerForm = this.fb.group({
    name: [""],
    email: [""],
    password: [""],
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

  //! Реализовать логику к html

  SignIn(loginForm: FormGroup) {
    let name = loginForm.value.email
    let password = loginForm.value.password

    this.authService.login(name, password).subscribe({
      next: data => {
        this.storageService.saveToken(data);

        this.router.navigate(['main']);
      },
      error: err => {
        if (err instanceof HttpErrorResponse && err.status === 401) {
          this.isLoginFailed = true;
        }
      }
    });
  }

  SignUp(registerForm: FormGroup) {

    let name = registerForm.value.email;
    let password = registerForm.value.password;

    this.authService.register(name, password).subscribe({
      next: data => {
        //ответ пустой
        // this.storageService.saveToken(data);

        this.router.navigate(['main']);
      },
      error: err => {
        // if (err instanceof HttpErrorResponse && err.status === 401) {
        this.isRegisterFailed = true;
        // }
      }
    });
  }
}

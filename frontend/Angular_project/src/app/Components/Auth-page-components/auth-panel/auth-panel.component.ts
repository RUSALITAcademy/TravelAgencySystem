import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-panel',
  templateUrl: './auth-panel.component.html',
  styleUrls: ['./auth-panel.component.scss']
})
export class AuthPanelComponent implements OnInit {

  constructor(
    private router: Router,
    private renderer: Renderer2,
    private el: ElementRef) { }

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

  SignIn() {
    this.router.navigate(['main']);
    console.log(this.router.url)
  }

  SignUp() {
    this.router.navigate(['main']);
  }
}

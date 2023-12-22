import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-account-settings',
  templateUrl: './account-settings.component.html',
  styleUrls: ['./account-settings.component.scss']
})
export class AccountSettingsComponent implements OnInit {

  infoForm: FormGroup;
  passwordForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.infoForm = this.fb.group({
      person_name: ['',],
      person_email: ['',],

    });
    this.passwordForm = this.fb.group({
      person_new_password: ['',],
      person_old_password: ['',],
    });
  }

  ngOnInit() {

  }
}

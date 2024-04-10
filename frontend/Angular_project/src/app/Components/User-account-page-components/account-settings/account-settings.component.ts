import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IUser } from 'src/app/Models/user.model';

@Component({
  selector: 'app-account-settings',
  templateUrl: './account-settings.component.html',
  styleUrls: ['./account-settings.component.scss']
})
export class AccountSettingsComponent implements OnInit {

  hidePass = true;
  hidePassRepeat = true;
  editMode: boolean = false;
  editModePass: boolean = false;

  originalUser: IUser | null = null;

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

  toggleEditMode(): void {
    if (this.editMode) {
      // Если режим редактирования был активен, восстанавливаем исходные значения
      //this.editedProduct = { ...this.originalProduct! };
    }
    this.editMode = !this.editMode;
  }

  toggleEditModePass(): void {
    if (this.editModePass) {
      // Если режим редактирования был активен, восстанавливаем исходные значения
      //this.editedProduct = { ...this.originalProduct! };
    }
    this.editModePass = !this.editModePass;
  }
}

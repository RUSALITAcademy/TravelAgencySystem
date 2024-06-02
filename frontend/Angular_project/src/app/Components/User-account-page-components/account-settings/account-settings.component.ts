import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IUser } from 'src/app/Models/user.model';
import { cloneDeep } from 'lodash';
import { UserService } from 'src/app/Services/user.service';

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

  infoForm: FormGroup = this.fb.group({
    firstName: ['',],
    lastName: ['',],
    middleName: ['',],
  });
  infoFormSaved: FormGroup;

  passwordForm: FormGroup = this.fb.group({
    currentPassword: ['',],
    newPassword: ['',],
    newPasswordRepeat: ['',],
  });
  passwordFormSaved: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
  ) {
  }

  ngOnInit() {
    this.userService.getUser().subscribe((user) => {
      this.infoForm.patchValue({
        firstName: user.firstName,
        lastName: user.lastName,
        middleName: user.middleName,
      });
    });
  }

  toggleEditMode(): void {
    console.log(this.editMode)
    if (this.editMode) {
      this.infoForm = cloneDeep(this.infoFormSaved);
    } else {
      this.infoFormSaved = cloneDeep(this.infoForm);
    }
    this.editMode = !this.editMode;
  }

  toggleEditModePass(): void {
    if (this.editModePass) {
      this.passwordForm = cloneDeep(this.passwordFormSaved);
    } else {
      this.passwordFormSaved = cloneDeep(this.passwordForm);
    }
    this.editModePass = !this.editModePass;
  }

  saveInfo() {
    this.userService.updateUser(this.infoForm.value).subscribe();
  }

  savePassword() {
    this.userService.changePassword(this.passwordForm.value).subscribe();
  }
}

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { cloneDeep } from 'lodash';
import { IUser } from 'src/app/Models/user.model';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-cabinet',
  templateUrl: './cabinet.component.html',
  styleUrls: ['./cabinet.component.scss']
})
export class CabinetComponent {

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
  ) {
  }

  hidePass = true;
  hidePassRepeat = true;
  editMode: boolean = false;
  editModePass: boolean = false;

  originalUser: IUser | null = null;

  infoForm: FormGroup = this.fb.group({
    firstName: ['',],
    lastName: ['',],
    middleName: ['',],
    userName: ['',],
  });
  infoFormSaved: FormGroup;

  passwordForm: FormGroup = this.fb.group({
    currentPassword: ['',],
    newPassword: ['',],
    newPasswordRepeat: ['',],
  });
  passwordFormSaved: FormGroup;

  ngOnInit() {
    this.infoForm.disable();
    this.passwordForm.disable();

    this.userService.getUser().subscribe((user) => {
      this.infoForm.patchValue({
        firstName: user.firstName,
        lastName: user.lastName,
        middleName: user.middleName,
        userName: user.email,
      });
    });
  }

  toggleEditMode(): void {
    if (this.editMode) {
      this.infoForm = cloneDeep(this.infoFormSaved);
      this.infoForm.disable();
    } else {
      this.infoForm.enable();
      this.infoFormSaved = cloneDeep(this.infoForm);
    }
    this.editMode = !this.editMode;
  }

  toggleEditModePass(): void {
    if (this.editModePass) {
      this.passwordForm.disable();
    } else {
      this.passwordForm.enable();
    }
    this.editModePass = !this.editModePass;
  }

  saveInfo() {
    this.userService.updateUser(this.infoForm.value).subscribe();
  }

  savePassword() {
    const value = this.passwordForm.value;
    delete value.newPasswordRepeat;
    this.userService.changePassword(this.passwordForm.value).subscribe();
  }
}

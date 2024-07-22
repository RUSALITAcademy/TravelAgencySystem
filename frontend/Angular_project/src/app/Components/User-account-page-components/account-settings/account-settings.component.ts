import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IUser } from 'src/app/Models/user.model';
import { cloneDeep } from 'lodash';
import { UserService } from 'src/app/Services/user.service';
import { SnackbarComponent } from '../../Common/snackbar/snackbar.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-account-settings',
  templateUrl: './account-settings.component.html',
  styleUrls: ['./account-settings.component.scss']
})
export class AccountSettingsComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) {
  }

  hidePass = true;
  hidePassRepeat = true;
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
    if (this.infoForm.disabled) {
      this.infoForm.enable();
      this.infoFormSaved = cloneDeep(this.infoForm);
    } else {
      this.infoForm = cloneDeep(this.infoFormSaved);
      this.infoForm.disable();
    }
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
    this.userService.updateUser(this.infoForm.value).subscribe({
      next: () => {
        this.infoForm.disable();
        this.openSnackBar('Данные сохранены');
      },
      error: (err) => {
        this.openSnackBar('Произошла ошибка при сохранении данных , попробуйте ещё раз');
        console.error(err);
      },
    });
  }

  savePassword() {
    const value = this.passwordForm.value;
    delete value.newPasswordRepeat;
    this.userService.changePassword(this.passwordForm.value).subscribe({
      next: () => {
        this.toggleEditModePass();
        this.openSnackBar('Пороль сохранён')
      },
      error: (err) => {
        this.openSnackBar('Произошла ошибка при сохранении пороля, попробуйте ещё раз')
        console.error(err);
      },
    });
  }

  openSnackBar(text: string) {
    this.snackBar.openFromComponent(SnackbarComponent, {
      data: text,
      duration: 3000
    });
  }
}

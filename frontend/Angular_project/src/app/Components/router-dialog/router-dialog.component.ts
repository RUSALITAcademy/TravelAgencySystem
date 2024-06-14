import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-router-dialog',
  templateUrl: './router-dialog.component.html',
  styleUrls: ['./router-dialog.component.scss'],
  standalone: true,
  imports: [
    MatButtonModule,
    RouterModule

  ]
})
export class RouterDialogComponent {
  constructor(
    private router: Router,
    private dialogRef: MatDialogRef<RouterDialogComponent>
  ) { }


  redirectToAccountSettings(): void {
    this.router.navigate(['/account/settings']);
    this.dialogRef.close();
  }

  redirectToMainPage(): void {
    this.router.navigate(['/main/']);
    this.dialogRef.close();
  }
}

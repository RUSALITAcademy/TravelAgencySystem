import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ImageService } from 'src/app/Services/image.service';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-create-tour-dialog',
  templateUrl: './create-tour-dialog.component.html',
  styleUrls: ['./create-tour-dialog.component.scss'],
})
export class CreateTourDialogComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private tourService: TourService,
    private imageService: ImageService,
    private dialogRef: MatDialogRef<CreateTourDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any,
  ) {
    this.tourForm = this.fb.group({
      tourId: [],
      name: [, [Validators.required]],
      description: [, [Validators.required]],
      country: [, [Validators.required]],
      region: [, [Validators.required]],
      startDate: [, [Validators.required]],
      endDate: [, [Validators.required]],
      quantity: [, [Validators.required]],
      price: [, [Validators.required]],
      status: [1, [Validators.required]],
    })
  }

  tourForm: FormGroup;

  mainImage: File | null = null;
  images: File[] = [];

  ngOnInit(): void {
    if (this.data?.tourId) {
      this.tourForm.patchValue({
        tourId: this.data.tourId,
        name: this.data.name,
        description: this.data.description,
        country: this.data.country,
        region: this.data.region,
        startDate: this.data.startDate,
        endDate: this.data.endDate,
        quantity: this.data.quantity,
        price: this.data.price,
        status: this.data.status,
      });
    }
  }

  onMainImageSelected(event: any) {
    this.mainImage = event.target.files[0];
  }

  onImagesSelected(event: any) {
    this.images = event.target.files;
  }

  createImage(tourId: string) {
    if (this.mainImage) {
      let formData: FormData = new FormData();
      formData.append('file', this.mainImage, this.mainImage.name);
      this.imageService.CreateImage(formData, tourId).subscribe();
    }
    for (let i = 0; i < this.images.length; i++) {
      let formData: FormData = new FormData();
      formData.append('file', this.images[i], this.images[i].name);
      this.imageService.CreateImage(formData, tourId).subscribe();
    }
  }

  onSave() {
    const tour = this.tourForm.value;
    if (tour.tourId) {
      return this.tourService.UpdateTour(this.tourForm.value).subscribe({
        next: () => {
          if (this.mainImage) {
            this.createImage(tour.tourId);
          }
          this.dialogRef.close();
        },
        error: (err) => {

        }
      });
    } else {
      delete tour.tourId;
      return this.tourService.CreateTour(this.tourForm.value).subscribe({
        next: (tourId) => {
          if (this.mainImage) {
            this.createImage(tourId);
          }
          this.dialogRef.close();
        },
        error: (err) => {

        }
      });
    }
  }
}

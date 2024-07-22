import { Component, Inject, Input, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Router, NavigationEnd } from '@angular/router';
import { concatMap, from } from 'rxjs';
import { ITour } from 'src/app/Models/tour.model';
import { ImageService } from 'src/app/Services/image.service';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-tour-main',
  templateUrl: './tour-main.component.html',
  styleUrls: ['./tour-main.component.scss']

})
export class TourMainComponent implements OnInit {
  @Input() tourId: string = "";
  @Input() tourTitle: string = '';
  @Input() tourDescription: string = '';
  @Input() smallDescription: string = '';
  @Input() tourCountry: string = '';
  @Input() tourCity: string = '';
  @Input() tourStartDate: string = '';
  @Input() tourEndDate: string = '';
  @Input() price!: number;
  @Input() quantity!: number;
  overlayColor: string = 'rgba(11, 8, 11, 0.681);'; // Прозрачность затемнения
  @Input() images: string[] = [];
  @Input() isPreview: boolean = false;

  currentIndex: number = 0;
  totalImages!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tourService: TourService,
    private imageService: ImageService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any, // Получение данных из диалога
    @Optional() private dialogRef: MatDialogRef<TourMainComponent>) {

  }

  ngOnInit(): void {
    if (this.data) {
      this.tourId = this.data.tourId;
      this.tourTitle = this.data.name;
      this.tourDescription = this.data.description;
      this.tourCountry = this.data.country;
      this.tourCity = this.data.region;
      this.tourStartDate = this.data.startDate;
      this.tourEndDate = this.data.endDate;
      this.price = this.data.price;
      this.quantity = this.data.quantity;
      this.images = this.data.imageUrls;
      this.isPreview = this.data.isPreview;

      const sentences = this.splitIntoSentences(this.tourDescription);
      const firstFourSentences = sentences?.slice(0, 4);
      this.smallDescription = firstFourSentences?.join(' ');
    }
    console.log(this.data?.imageUrls)
    if (!this.isPreview) {
      this.router.events.subscribe(event => {
        if (event instanceof NavigationEnd) {
          window.scrollTo(0, 0);
        }
      });

      this.route.params.subscribe(params => {
        this.tourId = String(params['id']);
        this.tourService.GetTourById(this.tourId).subscribe((tourData) => {
          if (tourData) {
            this.loadImages(tourData);

            this.tourTitle = tourData.name || this.tourTitle;
            this.tourDescription = tourData.description || this.tourDescription;
            this.tourCountry = tourData.country || this.tourCountry;
            this.tourCity = tourData.region || this.tourCity;
            this.tourStartDate = tourData.startDate?.toString() || this.tourStartDate;
            this.tourEndDate = tourData.endDate?.toString() || this.tourEndDate;
            this.price = tourData.price || this.price;
            this.quantity = tourData.quantity || this.quantity;

            const sentences = this.splitIntoSentences(this.tourDescription);
            const firstFourSentences = sentences.slice(0, 4);
            this.smallDescription = firstFourSentences.join(' ');
          }
        });
      });
    } else {
      this.totalImages = this.images?.length;
    }
  }

  loadImages(tour: ITour) {
    this.imageService.GetImagesNames(tour.tourId).subscribe((images: any) => {
      console.log(images)
      images.forEach((element: { fileName: string; }) => {
        this.images.push(this.imageService.GetImageByFileName(element.fileName));

      });
      this.totalImages = this.images?.length;
    });
  }

  prevSlide() {
    this.currentIndex = (this.currentIndex - 1 + this.totalImages) % this.totalImages;
    this.updateCarousel();
  }

  nextSlide() {
    this.currentIndex = (this.currentIndex + 1) % this.totalImages;
    this.updateCarousel();
  }

  updateCarousel() {
    const carousel = document.querySelector('.carousel') as HTMLElement | null;
    const prevButton = document.querySelector('.prev-button') as HTMLButtonElement | null;
    const nextButton = document.querySelector('.next-button') as HTMLButtonElement | null;

    if (carousel && prevButton && nextButton) {
      const maxIndex = this.totalImages - 1;
      const translateValue = -this.currentIndex * 33.33;

      carousel.style.transform = `translateX(${translateValue}%)`;

      // Disable/Enable buttons based on current index
      prevButton.disabled = this.currentIndex === 0;
      nextButton.disabled = this.currentIndex === maxIndex - 2;
    }
  }
  // redirectToOrderStepper() {
  //   this.router.navigate(['payment/']);
  // }
  splitIntoSentences(text: string): string[] {
    if (text) {
      return text?.split(/(?<=[.!?])\s+/);
    } else return null;
  }
}

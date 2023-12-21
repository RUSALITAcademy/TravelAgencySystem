import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { TourService } from 'src/app/Services/tour.service';

@Component({
  selector: 'app-tour-main',
  templateUrl: './tour-main.component.html',
  styleUrls: ['./tour-main.component.scss']
  
})
export class TourMainComponent implements OnInit {
  tourId: string = "";
  tourTitle: string = '';
  tourDescription: string = '';
  smallDescription: string = '';
  tourCountry: string = '';
  tourCity: string = '';
  tourStartDate: string = '';
  tourEndDate: string = '';
  price!: number;
  quantity!: number;
  overlayColor: string = 'rgba(0, 0, 0, 0.5)'; // Прозрачность затемнения
  images!: string[];

  currentIndex: number = 0;
  totalImages!: number;

  constructor(private route: ActivatedRoute, private router: Router, private tourService: TourService) {
  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.tourId = String(params['id']);
      this.tourService.GetTourById(this.tourId).subscribe((tourData) => {
        if (tourData) {
          // Обновите поля данными из ответа сервиса
          
          this.tourTitle = tourData.name || this.tourTitle;
          this.tourDescription = tourData.description || this.tourDescription;
          this.tourCountry = tourData.country || this.tourCountry;
          this.tourCity = tourData.region || this.tourCity;
          this.tourStartDate = tourData.startDate?.toString() || this.tourStartDate;
          this.tourEndDate = tourData.endDate?.toString() || this.tourEndDate;
          this.price = tourData.price || this.price;
          this.quantity = tourData.quantity || this.quantity;
          this.images = tourData.imgUrl || this.images;
          // Добавьте любые дополнительные поля, которые нужно обновить
          this.totalImages = this.images.length;
          
          const sentences = this.splitIntoSentences(this.tourDescription);
          const firstFourSentences = sentences.slice(0, 4);
          this.smallDescription = firstFourSentences.join(' ');
        }
      });
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
  redirectToOrderStepper() {
    this.router.navigate(['payment']);
  }
  splitIntoSentences(text: string): string[] {
    return text.split(/(?<=[.!?])\s+/);
  }
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-tour-main',
  templateUrl: './tour-main.component.html',
  styleUrls: ['./tour-main.component.scss']
})
export class TourMainComponent {
  tourImageUrl: string = 'https://anapacity.com/content/images/kavkazskie-gory-05.jpg';
  tourTitle: string = 'Grand Waterworld Makadi';
  overlayColor: string = 'rgba(0, 0, 0, 0.5)'; // Прозрачность затемнения
  images: string[] = ['https://www.ladya-kmv.ru/upload/medialibrary/5b6/5b641bfdaf9a9ce326272bc2655d2580.jpg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2021_22/content_hotel_60b8cb13a98796.36051676.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de717db31.14000303.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de74077f0.63113325.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de73d1d98.08373928.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de7553166.79085069.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de4e68293.28268951.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de4ef5208.22811444.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de51bac13.46719336.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de4ed63d3.80746049.jpeg',
  'https://edge.travelatacdn.ru/thumbs/940x705/upload/2023_43/content_hotel_65390de4ed0e67.57846335.jpeg',
  'https://www.ladya-kmv.ru/upload/medialibrary/5b6/5b641bfdaf9a9ce326272bc2655d2580.jpg',];

  currentIndex: number = 0;
  totalImages: number;

  constructor() {
    this.totalImages = this.images.length;
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
}

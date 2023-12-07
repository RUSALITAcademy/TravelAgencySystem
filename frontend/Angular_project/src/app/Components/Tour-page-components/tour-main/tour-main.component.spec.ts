import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourMainComponent } from './tour-main.component';

describe('TourMainComponent', () => {
  let component: TourMainComponent;
  let fixture: ComponentFixture<TourMainComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourMainComponent]
    });
    fixture = TestBed.createComponent(TourMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

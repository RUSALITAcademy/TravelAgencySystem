import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourAgentPageComponent } from './tour-agent-page.component';

describe('TourAgentPageComponent', () => {
  let component: TourAgentPageComponent;
  let fixture: ComponentFixture<TourAgentPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourAgentPageComponent]
    });
    fixture = TestBed.createComponent(TourAgentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

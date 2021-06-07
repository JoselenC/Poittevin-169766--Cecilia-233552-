import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PsychologyDetailComponent } from './psychology-detail.component';

describe('PsychologyDetailComponent', () => {
  let component: PsychologyDetailComponent;
  let fixture: ComponentFixture<PsychologyDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PsychologyDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PsychologyDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

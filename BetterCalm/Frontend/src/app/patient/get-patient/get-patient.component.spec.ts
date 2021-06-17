import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPatientComponent } from './get-patient.component';

describe('PatientComponent', () => {
  let component: GetPatientComponent;
  let fixture: ComponentFixture<GetPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPatientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

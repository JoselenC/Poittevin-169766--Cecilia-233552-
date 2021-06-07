import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPsychologyComponent } from './add-psychology.component';

describe('AddPsychologyComponent', () => {
  let component: AddPsychologyComponent;
  let fixture: ComponentFixture<AddPsychologyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPsychologyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPsychologyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

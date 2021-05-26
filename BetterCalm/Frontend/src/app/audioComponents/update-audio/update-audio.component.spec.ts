import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAudioComponent } from './update-audio.component';

describe('UpdateAudioComponent', () => {
  let component: UpdateAudioComponent;
  let fixture: ComponentFixture<UpdateAudioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateAudioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateAudioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

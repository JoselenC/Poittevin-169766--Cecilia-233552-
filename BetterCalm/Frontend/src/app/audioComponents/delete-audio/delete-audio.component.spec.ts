import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteAudioComponent } from './delete-audio.component';

describe('DeleteAudioComponent', () => {
  let component: DeleteAudioComponent;
  let fixture: ComponentFixture<DeleteAudioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteAudioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteAudioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

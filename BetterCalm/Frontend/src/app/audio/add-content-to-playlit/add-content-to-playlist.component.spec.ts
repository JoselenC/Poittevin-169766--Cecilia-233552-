import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddContentToPlaylistComponent } from './add-content-to-playlist.component';

describe('AddAudioComponent', () => {
  let component: AddContentToPlaylistComponent;
  let fixture: ComponentFixture<AddContentToPlaylistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddContentToPlaylistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddContentToPlaylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

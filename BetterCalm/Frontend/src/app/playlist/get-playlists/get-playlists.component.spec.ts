import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPlaylistsComponent } from './get-playlists.component';

describe('GetPlaylistsComponent', () => {
  let component: GetPlaylistsComponent;
  let fixture: ComponentFixture<GetPlaylistsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPlaylistsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPlaylistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

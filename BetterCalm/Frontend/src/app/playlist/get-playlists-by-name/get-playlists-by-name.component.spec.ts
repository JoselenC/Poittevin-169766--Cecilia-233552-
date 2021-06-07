import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPlaylistsByNameComponent } from './get-playlists-by-name.component';

describe('GetPlaylistsByNameComponent', () => {
  let component: GetPlaylistsByNameComponent;
  let fixture: ComponentFixture<GetPlaylistsByNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPlaylistsByNameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPlaylistsByNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

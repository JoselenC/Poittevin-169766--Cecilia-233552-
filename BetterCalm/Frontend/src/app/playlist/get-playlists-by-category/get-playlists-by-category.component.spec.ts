import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPlaylistsByCategoryComponent } from './get-playlists-by-category.component';

describe('GetPlaylistsByCategoryComponent', () => {
  let component: GetPlaylistsByCategoryComponent;
  let fixture: ComponentFixture<GetPlaylistsByCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPlaylistsByCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPlaylistsByCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

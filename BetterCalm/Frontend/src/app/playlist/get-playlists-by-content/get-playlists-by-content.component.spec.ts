import { ComponentFixture, TestBed } from '@angular/core/testing';
import {GetPlaylistsByContentComponent} from './get-playlists-by-name.component';

describe('GetPlaylistsByContentComponent', () => {
  let component: GetPlaylistsByContentComponent;
  let fixture: ComponentFixture<GetPlaylistsByContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPlaylistsByContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPlaylistsByContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAudiosComponent } from './get-audios.component';

describe('GetAudiosComponent', () => {
  let component: GetAudiosComponent;
  let fixture: ComponentFixture<GetAudiosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAudiosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetAudiosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetContentsComponent } from './get-contents.component';

describe('GetContentsComponent', () => {
  let component: GetContentsComponent;
  let fixture: ComponentFixture<GetContentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetContentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetContentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

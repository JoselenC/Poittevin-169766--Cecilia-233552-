import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetContentByAuthorComponent } from './get-content-by-author.component';

describe('GetContentByAuthorComponent', () => {
  let component: GetContentByAuthorComponent;
  let fixture: ComponentFixture<GetContentByAuthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetContentByAuthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetContentByAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

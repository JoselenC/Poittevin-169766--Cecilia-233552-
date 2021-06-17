import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetContentByCategoryComponent } from './get-content-by-category.component';

describe('GetContentByCategoryComponent', () => {
  let component: GetContentByCategoryComponent;
  let fixture: ComponentFixture<GetContentByCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetContentByCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetContentByCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

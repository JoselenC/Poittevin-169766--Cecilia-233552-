import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetContentByNameComponent } from './get-content-by-name.component';

describe('GetContentByNameComponent', () => {
  let component: GetContentByNameComponent;
  let fixture: ComponentFixture<GetContentByNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetContentByNameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetContentByNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

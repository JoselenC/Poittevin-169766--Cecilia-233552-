import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAdminComponent } from './get-admin.component';

describe('GetAdminComponent', () => {
  let component: GetAdminComponent;
  let fixture: ComponentFixture<GetAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

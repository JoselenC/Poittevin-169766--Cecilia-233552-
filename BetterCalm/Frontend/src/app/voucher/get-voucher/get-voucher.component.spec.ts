import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetVoucherComponent } from './get-voucher.component';

describe('GetVoucherComponent', () => {
  let component: GetVoucherComponent;
  let fixture: ComponentFixture<GetVoucherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetVoucherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

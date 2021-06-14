import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoucherSelectPercentageComponent } from './voucher-select-percentage.component';

describe('VoucherSelectPercetageComponent', () => {
  let component: VoucherSelectPercentageComponent;
  let fixture: ComponentFixture<VoucherSelectPercentageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VoucherSelectPercentageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VoucherSelectPercentageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

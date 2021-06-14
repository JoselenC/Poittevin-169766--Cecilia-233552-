import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {VoucherService} from '../../services/voucher/voucher.service';
import {Voucher} from '../../models/Voucher';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {VoucherSelectPercentageComponent} from '../voucher-select-percetage/voucher-select-percentage.component';

@Component({
  selector: 'app-get-voucher',
  templateUrl: './get-voucher.component.html',
  styleUrls: ['./get-voucher.component.css']
})
export class GetVoucherComponent implements OnInit {
  public vouchers: Voucher[] = [];

  constructor(
    private voucherService: VoucherService,
    private router: Router,
    public dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.getVouchers();
  }

  private getVouchers(): void {
    this.voucherService.getAll()
      .subscribe(
        ((data: Array<Voucher>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Voucher>): void {
    this.vouchers = data;
  }

  openDialog(): MatDialogRef<VoucherSelectPercentageComponent> {
    return this.dialog.open(VoucherSelectPercentageComponent, {
      width: '250px',
      data: 25,
    });
  }

  navigateTo(voucherId: number): void {
    this.router.navigate(['vouchers', voucherId]);
  }

  approve(voucher: Voucher): void {
    this.openDialog().afterClosed().subscribe(
      (discount: any) => {
        voucher.discount = discount;
        if (discount) {
          this.voucherService.approve(voucher).subscribe(
            (_: any) => {
              this.getVouchers();
            }
          );
        }
      }
    );
  }

  reject(voucher: Voucher): void {
    this.voucherService.reject(voucher).subscribe(
      (data: any) => {
        this.getVouchers();
      }
    );
  }
}

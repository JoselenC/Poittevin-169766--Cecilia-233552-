import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {VoucherService} from '../../services/voucher/voucher.service';
import {Voucher} from '../../models/Voucher';

@Component({
  selector: 'app-get-voucher',
  templateUrl: './get-voucher.component.html',
  styleUrls: ['./get-voucher.component.css']
})
export class GetVoucherComponent implements OnInit {
  public vouchers: Voucher[] = [];

  constructor(
    private voucherService: VoucherService,
    private router: Router
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
    console.log(this.vouchers);
  }

  navigateTo(voucherId: number): void {
    this.router.navigate(['vouchers', voucherId]);
  }

  approve(voucher: Voucher): void {
    this.voucherService.approve(voucher).subscribe(
      (data: any) => {
        this.getVouchers();
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

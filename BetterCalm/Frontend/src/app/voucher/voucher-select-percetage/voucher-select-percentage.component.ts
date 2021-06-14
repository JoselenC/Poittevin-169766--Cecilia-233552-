import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {MatSelectChange} from '@angular/material/select';


@Component({
  selector: 'app-voucher-select-percetage',
  templateUrl: './voucher-select-percentage.component.html',
  styleUrls: ['./voucher-select-percentage.component.css']
})
export class VoucherSelectPercentageComponent {
  discounts: Array<number> = [
    15,
    25,
    50
  ];
  formDiscount = new FormControl();
  discountGroup ?: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<VoucherSelectPercentageComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public discount: number
  ) {
  }

  initForm(): void {
    this.discountGroup = this.formBuilder.group({
        rateToString: this.discounts
      },
    );
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  changeDiscount(event: MatSelectChange): void {
    console.log(event);
    this.discount = event.value;
  }

}

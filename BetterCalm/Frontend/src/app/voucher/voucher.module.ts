import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {GetVoucherComponent} from './get-voucher/get-voucher.component';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {FlexModule} from '@angular/flex-layout';
import { VoucherSelectPercentageComponent } from './voucher-select-percetage/voucher-select-percentage.component';
import {MatDialogModule} from '@angular/material/dialog';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatOptionModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';


const routes: Routes = [
  {
    path: 'vouchers',
    component: LayoutComponent,
    children: [
      {path: '', component: GetVoucherComponent},
    ]
  },
];


@NgModule({
  declarations: [
    GetVoucherComponent,
    VoucherSelectPercentageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    FlexModule,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    ReactiveFormsModule,
    MatOptionModule,
    MatSelectModule,
  ],
  exports: [
    RouterModule
  ]
})

export class VoucherModule {
}

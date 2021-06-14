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
    GetVoucherComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    FlexModule,
  ],
  exports: [
    RouterModule
  ]
})

export class VoucherModule {
}

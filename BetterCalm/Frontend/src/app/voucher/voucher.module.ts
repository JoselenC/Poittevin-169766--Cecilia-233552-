import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {GetVoucherComponent} from './get-voucher/get-voucher.component';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';


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
  ],
  exports: [
    RouterModule
  ]
})

export class VoucherModule {
}

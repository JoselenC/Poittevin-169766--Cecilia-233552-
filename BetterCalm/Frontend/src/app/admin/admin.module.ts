import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {GetAdminComponent} from './get-admin/get-admin.component';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LayoutModule} from '../layout/layout.module';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import { DetailAdminComponent } from './detail-admin/detail-admin.component';
import { AddAdminComponent } from './add-admin/add-admin.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FlexModule} from '@angular/flex-layout';
import {MatInputModule} from '@angular/material/input';
import {FormsModule} from '@angular/forms';


const routes: Routes = [
  {
    path: 'admins',
    component: LayoutComponent,
    children: [
      {path: '', component: GetAdminComponent},
    ]
  },
  {
    path: 'admins/:adminId',
    component: LayoutComponent,
    children: [
      { path: '', component: DetailAdminComponent },
    ]
  },
  {
    path: 'add-admin',
    component: LayoutComponent,
    children: [
      { path: '', component: AddAdminComponent },
    ]
  },
];

@NgModule({
  declarations: [
    GetAdminComponent,
    DetailAdminComponent,
    AddAdminComponent,
  ],
  imports: [
    CommonModule,
    LayoutModule,
    RouterModule.forChild(routes),
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatFormFieldModule,
    FlexModule,
    MatInputModule,
    FormsModule
  ],
  exports: [
    RouterModule
  ]
})
export class AdminModule {
}

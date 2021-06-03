import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';

import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {PatientDetailComponent} from './patient-detail.component';
import {MatListModule} from '@angular/material/list';
import {MatSidenavModule} from '@angular/material/sidenav';

const routes: Routes = [
  {
    path: 'patients/:patientId',
    component: LayoutComponent,
    children: [
      { path: '', component: PatientDetailComponent },
    ]
  },
];


@NgModule({
  declarations: [ PatientDetailComponent ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatCardModule,
    MatListModule,
    MatSidenavModule
  ],
  exports: [
    RouterModule
  ]
})
export class PatientDetailModule { }

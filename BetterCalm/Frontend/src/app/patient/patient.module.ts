import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';

import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {PatientComponent} from './patient.component';
import {LayoutModule} from '../layout/layout.module';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';


const routes: Routes = [
  {
    path: 'patients',
    component: LayoutComponent,
    children: [
      { path: '', component: PatientComponent },
    ]
  },
];


@NgModule({
  declarations: [PatientComponent],
  imports: [
    CommonModule,
    LayoutModule,
    RouterModule.forChild(routes),
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule
  ],
  exports: [
    RouterModule
  ]
})
export class PatientModule { }

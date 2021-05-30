import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {PatientComponent} from './patient.component';
import {LayoutModule} from '../layout/layout.module';


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
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PatientModule { }

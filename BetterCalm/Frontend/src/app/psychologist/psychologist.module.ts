import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {PatientComponent} from '../patient/patient.component';
import {PsychologistComponent} from './psychologist.component';
import {LayoutModule} from '../layout/layout.module';

const routes: Routes = [
  {
    path: 'psychologits',
    component: LayoutComponent,
    children: [
      { path: '', component: PsychologistComponent },
    ]
  },
];


@NgModule({
  declarations: [PsychologistComponent],
  imports: [
    CommonModule,
    LayoutModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PsychologistModule { }

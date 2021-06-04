import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';

import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {PatientComponent} from './get-patient/patient.component';
import {LayoutModule} from '../layout/layout.module';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { AddPatientComponent } from './add-patient/add-patient.component';
import {PatientDetailComponent} from './patient-detail/patient-detail.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {FlexModule} from '@angular/flex-layout';


const routes: Routes = [
  {
    path: 'patients',
    component: LayoutComponent,
    children: [
      { path: '', component: PatientComponent },
    ]
  },
  {
    path: 'patients/:patientId',
    component: LayoutComponent,
    children: [
      { path: '', component: PatientDetailComponent },
    ]
  },
  {
    path: 'add-patient',
    component: LayoutComponent,
    children: [
      { path: '', component: AddPatientComponent },
    ]
  },
];

@NgModule({
  declarations: [
    PatientComponent,
    PatientDetailComponent,
    AddPatientComponent
  ],
  imports: [
    CommonModule,
    LayoutModule,
    MatNativeDateModule,
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    RouterModule.forChild(routes),
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    FlexModule,
    FormsModule,
  ],
  exports: [
    RouterModule
  ]
})
export class PatientModule { }

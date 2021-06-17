import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LayoutModule} from '../layout/layout.module';
import {PsychologyComponent} from './get-psychology/psychologist.component';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {PsychologyDetailComponent} from './psychology-detail/psychology-detail.component';
import {AddPsychologyComponent} from './add-psychology/add-psychology.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FlexModule} from '@angular/flex-layout';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSelectModule} from '@angular/material/select';

const routes: Routes = [
  {
    path: 'psychologits',
    component: LayoutComponent,
    children: [
      {path: '', component: PsychologyComponent},
    ]
  },
  {
    path: 'psychology/:psychologyId',
    component: LayoutComponent,
    children: [
      {path: '', component: PsychologyDetailComponent},
    ]
  },
  {
    path: 'add-psychology',
    component: LayoutComponent,
    children: [
      {path: '', component: AddPsychologyComponent},
    ]
  },
];


@NgModule({
  declarations: [
    PsychologyComponent,
    PsychologyDetailComponent,
    AddPsychologyComponent,
    AddPsychologyComponent
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
    FormsModule,
    MatInputModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    MatSelectModule
  ],
  exports: [
    RouterModule
  ]
})
export class PsychologistModule {
}

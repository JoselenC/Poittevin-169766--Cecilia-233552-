import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ImportContentComponent} from './import-content.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LayoutModule} from '../layout/layout.module';
import {HttpClientModule} from '@angular/common/http';
import {FlexModule} from '@angular/flex-layout';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MaterialComponentsModule} from '../material.module';

const routes: Routes = [
  {
    path: 'import-content',
    component: LayoutComponent,
    children: [
      { path: '', component: ImportContentComponent },
    ]
  },
  ];

@NgModule({
  declarations: [ImportContentComponent],
  imports: [
    LayoutModule,
    HttpClientModule,
    CommonModule,
    MatFormFieldModule,
    FormsModule,
    RouterModule.forChild(routes),
    FlexModule,
    MatInputModule,
    MatButtonModule,
    MaterialComponentsModule,
    ReactiveFormsModule,
  ],
  exports: [
    RouterModule
  ]
})
export class ImportContentModule { }

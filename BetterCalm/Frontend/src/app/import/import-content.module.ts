import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ImportContentComponent} from './import-content.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LayoutModule} from '../layout/layout.module';
import {HttpClientModule} from '@angular/common/http';

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
  ],
  exports: [
    RouterModule
  ]
})
export class ImportContentModule { }

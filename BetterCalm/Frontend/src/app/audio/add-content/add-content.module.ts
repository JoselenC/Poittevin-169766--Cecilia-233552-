import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {AddContentComponent} from './add-content.component';
import {MaterialComponentsModule} from '../../material.module';
import {FormsModule} from '@angular/forms';
import {MatOptionModule} from '@angular/material/core';
import {CategoryModule} from '../../category/category.module';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';

const routes: Routes = [
  {
    path: 'add-content',
    component: LayoutComponent,
    children: [
      { path: '', component: AddContentComponent },
    ]
  },
];


@NgModule({
  declarations: [AddContentComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    FormsModule,
    MatOptionModule,
    CategoryModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
})

export class AddAudioModule { }



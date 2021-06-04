import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {AddAudioComponent} from './add-audio.component';
import {MaterialComponentsModule} from '../../material.module';
import {FormsModule} from '@angular/forms';
import {MatOptionModule} from '@angular/material/core';
import {CategoryModule} from '../../categoryComponents/category.module';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';

const routes: Routes = [
  {
    path: 'add-audio',
    component: LayoutComponent,
    children: [
      { path: '', component: AddAudioComponent },
    ]
  },
];


@NgModule({
  declarations: [AddAudioComponent],
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



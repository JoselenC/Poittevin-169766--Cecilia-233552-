import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetAudiosComponent} from './get-audios.component';
import {HttpClientModule} from '@angular/common/http';
import {AudioService} from '../../services/Audio/audio.service';
import {MaterialComponentsModule} from '../../material.module';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';


const routes: Routes = [
  {
    path: 'audios',
    component: LayoutComponent,
    children: [
      { path: '', component: GetAudiosComponent },
    ]
  },
];

@NgModule({
  declarations: [GetAudiosComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    AudioService
  ],
  exports: [
    RouterModule,
    GetAudiosComponent
  ],
})
export class GetAudiosModule { }

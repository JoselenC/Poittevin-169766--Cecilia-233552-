import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetContentsComponent} from './get-contents.component';
import {HttpClientModule} from '@angular/common/http';
import {ContentService} from '../../services/content/content.service';
import {MaterialComponentsModule} from '../../material.module';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';


const routes: Routes = [
  {
    path: 'contents',
    component: LayoutComponent,
    children: [
      { path: '', component: GetContentsComponent },
    ]
  },
];

@NgModule({
  declarations: [GetContentsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    ContentService
  ],
  exports: [
    RouterModule,
    GetContentsComponent
  ],
})
export class GetContentsModule { }

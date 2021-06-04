import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AddPlaylistComponent} from './add-playlist.component';
import {HttpClientModule} from '@angular/common/http';
import {MaterialComponentsModule} from '../../material.module';
import {FormsModule} from '@angular/forms';
import {MatOptionModule} from '@angular/material/core';
import {CategoryModule} from '../../category/category.module';
import {GetContentsModule} from '../../audio/get-contents/get-contents.module';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';

const routes: Routes = [
  {
    path: 'add-playlist',
    component: LayoutComponent,
    children: [
      { path: '', component: AddPlaylistComponent },
    ]
  },
];

@NgModule({
  declarations: [AddPlaylistComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    FormsModule,
    MatOptionModule,
    CategoryModule,
    GetContentsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
})
export class AddPlaylistModule { }

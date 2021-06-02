import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetPlaylistsComponent} from './get-playlists.component';
import {HttpClientModule} from '@angular/common/http';
import {MaterialComponentsModule} from '../../material.module';
import {PlaylistService} from '../../services/Playlist/playlist.service';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../../layout/layout.component';



const routes: Routes = [
  {
    path: 'playlists',
    component: LayoutComponent,
    children: [
      { path: '', component: GetPlaylistsComponent },
    ]
  },
];

@NgModule({
  declarations: [GetPlaylistsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    RouterModule.forChild(routes)
  ],
  providers: [PlaylistService],
  exports: [
    RouterModule
  ]
})
export class GetPlaylistsModule { }

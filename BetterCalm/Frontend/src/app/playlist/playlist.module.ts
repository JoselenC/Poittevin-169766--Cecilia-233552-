import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';

import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {GetPlaylistsComponent} from './get-playlists/get-playlists.component';
import {LayoutModule} from '../layout/layout.module';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {AddPlaylistComponent } from './add-playlist/add-playlist.component';
import {PlaylistDetailComponent} from './playlist-detail/playlist-detail.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {FlexModule} from '@angular/flex-layout';
import {CategoryModule} from '../category/category.module';
import {MatTooltipModule} from '@angular/material/tooltip';
import {ContentModule} from '../content/content.module';
import {GetPlaylistsByNameComponent} from './get-playlists-by-name/get-playlists-by-name.component';
import {GetPlaylistsByContentComponent} from './get-playlists-by-content/get-playlists-by-name.component';
import {GetPlaylistsByCategoryComponent} from './get-playlists-by-category/get-playlists-by-category.component';
import {MatGridListModule} from '@angular/material/grid-list';

const routes: Routes = [
  {
    path: 'playlists',
    component: LayoutComponent,
    children: [
      { path: '', component: GetPlaylistsComponent },
    ]
  },
  {
    path: 'playlists/:playlistId',
    component: LayoutComponent,
    children: [
      { path: '', component: PlaylistDetailComponent },
    ]
  },
  {
    path: 'add-playlist',
    component: LayoutComponent,
    children: [
      { path: '', component: AddPlaylistComponent },
    ]
  },
  {
    path: 'get-playlists-by-name',
    component: LayoutComponent,
    children: [
      { path: '', component: GetPlaylistsByNameComponent },
    ]
  },
  {
    path: 'get-playlists-by-content',
    component: LayoutComponent,
    children: [
      { path: '', component: GetPlaylistsByContentComponent },
    ]
  },
  {
    path: 'get-playlists-by-category',
    component: LayoutComponent,
    children: [
      { path: '', component: GetPlaylistsByCategoryComponent },
    ]
  },
];

@NgModule({
  declarations: [
    GetPlaylistsComponent,
    PlaylistDetailComponent,
    AddPlaylistComponent,
    GetPlaylistsByNameComponent,
    GetPlaylistsByContentComponent,
    GetPlaylistsByCategoryComponent
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
        CategoryModule,
        MatTooltipModule,
        ContentModule,
        MatGridListModule,
    ],
  exports: [
    RouterModule
  ]
})
export class PlaylistModule { }


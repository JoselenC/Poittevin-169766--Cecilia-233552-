import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetContentsComponent} from './get-contents/get-contents.component';
import {HttpClientModule} from '@angular/common/http';
import {MaterialComponentsModule} from '../material.module';
import {ContentService} from '../services/content/content.service';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LayoutModule} from '../layout/layout.module';
import {MatNativeDateModule} from '@angular/material/core';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {FlexModule} from '@angular/flex-layout';
import {ContentDetailComponent} from './content-detail/content-detail.component';
import {MatTooltipModule} from '@angular/material/tooltip';
import {AddContentComponent} from './add-content/add-content.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {GetContentByNameComponent} from './get-content-by-name/get-content-by-name.component';
import {GetContentByCategoryComponent} from './get-content-by-category/get-content-by-category.component';
import {GetPlaylistsByCategoryComponent} from '../playlist/get-playlists-by-category/get-playlists-by-category.component';
import {GetContentByAuthorComponent} from './get-content-by-author/get-content-by-author.component';
import {AddContentToPlaylistComponent} from './add-content-to-playlit/add-content-to-playlist.component';
import {UpdateContentComponent} from './update-content/update-content.component';
import {MatGridListModule} from '@angular/material/grid-list';



const routes: Routes = [
  {
    path: 'contents',
    component: LayoutComponent,
    children: [
      { path: '', component: GetContentsComponent },
    ]
  },
  {
    path: 'contents/:contentId',
    component: LayoutComponent,
    children: [
      { path: '', component: ContentDetailComponent },
    ]
  },
  {
    path: 'add-content',
    component: LayoutComponent,
    children: [
      { path: '', component: AddContentComponent },
    ]
  },
  {
    path: 'update-content/:contentId',
    component: LayoutComponent,
    children: [
      { path: '', component: UpdateContentComponent },
    ]
  },
  {
    path: 'get-content-by-name',
    component: LayoutComponent,
    children: [
      { path: '', component: GetContentByNameComponent },
    ]
  },
  {
    path: 'get-content-by-category',
    component: LayoutComponent,
    children: [
      { path: '', component: GetContentByCategoryComponent },
    ]
  },
  {
    path: 'get-content-by-author',
    component: LayoutComponent,
    children: [
      { path: '', component: GetContentByAuthorComponent },
    ]
  },
  {
    path: 'add-content-to-playlist',
    component: LayoutComponent,
    children: [
      { path: '', component: AddContentToPlaylistComponent },
    ]
  },
];

@NgModule({
  declarations: [
    GetContentsComponent,
    ContentDetailComponent,
    AddContentComponent,
    GetContentByNameComponent,
    GetContentByCategoryComponent,
    GetContentByAuthorComponent,
    AddContentToPlaylistComponent,
    UpdateContentComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    RouterModule.forChild(routes),
    LayoutModule,
    MatNativeDateModule,
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    FlexModule,
    FormsModule,
    MatTooltipModule,
    MatSlideToggleModule,
    MatGridListModule,
  ],
  providers: [ContentService],
  exports: [
    RouterModule,
    AddContentComponent,
    AddContentToPlaylistComponent
  ]
})
export class ContentModule { }


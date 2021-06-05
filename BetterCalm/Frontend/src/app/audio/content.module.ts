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
import {AddPlaylistComponent} from '../playlist/add-playlist/add-playlist.component';
import {AddContentComponent} from './add-content/add-content.component';
import {UpdateContentComponent} from './update-content/update-content.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';



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
    path: 'update-content',
    component: LayoutComponent,
    children: [
      { path: '', component: UpdateContentComponent },
    ]
  },
];

@NgModule({
  declarations: [
    GetContentsComponent,
    ContentDetailComponent,
    UpdateContentComponent,
    AddContentComponent
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
    RouterModule.forChild(routes),
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    FlexModule,
    FormsModule,
    MatTooltipModule,
    MatSlideToggleModule,
  ],
  providers: [ContentService],
  exports: [
    RouterModule
  ]
})
export class ContentModule { }


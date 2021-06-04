import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import {MatSliderModule} from '@angular/material/slider';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormFieldAppearanceExample} from './material.component';

import {LayoutModule} from './layout/layout.module';
import { AppComponent } from './app.component';
import {CategoryModule} from './category/category.module';
import {AddAudioModule} from './audio/add-content/add-content.module';
import {GetContentsModule} from './audio/get-contents/get-contents.module';
import {DeleteContentModule} from './audio/delete-content/delete-content.module';
import {UpdateContentModule} from './audio/update-content/update-content.module';

import { PatientModule } from './patient/patient.module';
import {PsychologistModule} from './psychologist/psychologist.module';
import {GetPlaylistsModule} from './playlist/get-playlists/get-playlists.module';
import {AddPlaylistModule} from './playlist/add-playlist/add-playlist.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/playlists', // TODO: Redireccionar a playlist como pagina de inicio.
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    FormFieldAppearanceExample
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSliderModule,
    LayoutModule,
    // Patient
    PatientModule,
    // Psychologist
    PsychologistModule,
    // category
    CategoryModule,
    // content
    GetContentsModule,
    AddAudioModule,
    GetContentsModule,
    DeleteContentModule,
    UpdateContentModule,
    // playlist
    GetPlaylistsModule,
    AddPlaylistModule,
    // Router
    RouterModule.forRoot(routes),
  ],
  exports: [
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

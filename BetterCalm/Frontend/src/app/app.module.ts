import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import {MatSliderModule} from '@angular/material/slider';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormFieldAppearanceExample} from './material.component';

import {LayoutModule} from './layout/layout.module';
import { AppComponent } from './app.component';
import {CategoryModule} from './categoryComponents/category.module';
import {AddAudioModule} from './audioComponents/add-audio/add-audio.module';
import {GetAudiosModule} from './audioComponents/get-audios/get-audios.module';
import {DeleteAudioModule} from './audioComponents/delete-audio/delete-audio.module';
import {UpdateAudioModule} from './audioComponents/update-audio/update-audio.module';

import { PatientModule } from './patient/patient.module';
import {PsychologistModule} from './psychologist/psychologist.module';
import {GetPlaylistsModule} from './playlistComponents/get-playlists/get-playlists.module';
import {AddPlaylistModule} from './playlistComponents/add-playlist/add-playlist.module';

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
    // Category
    CategoryModule,
    // Audio
    GetAudiosModule,
    AddAudioModule,
    GetAudiosModule,
    DeleteAudioModule,
    UpdateAudioModule,
    // Playlist
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

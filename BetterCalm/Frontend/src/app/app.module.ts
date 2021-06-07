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
import {ContentModule} from './audio/content.module';

import { PatientModule } from './patient/patient.module';
import {PsychologistModule} from './psychologist/psychologist.module';
import {PlaylistModule} from './playlist/playlist.module';

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
    ContentModule,
    // playlist
    PlaylistModule,
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

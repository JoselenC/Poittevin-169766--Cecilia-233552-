import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CategoryModule} from "./categoryComponents/category.module";
import {HttpClientModule} from "@angular/common/http";
import {AddAudioModule} from "./audioComponents/add-audio/add-audio.module";
import {MatSliderModule} from "@angular/material/slider";
import {FormFieldAppearanceExample} from "./material.component";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {GetAudiosModule} from "./audioComponents/get-audios/get-audios.module";
import {DeleteAudioModule} from "./audioComponents/delete-audio/delete-audio.module";
import {UpdateAudioModule} from "./audioComponents/update-audio/update-audio.module";
import {LayoutModule} from './layout/layout.module';
import {RouterModule, Routes} from '@angular/router';

import { PatientModule } from './patient/patient.module';
import {PsychologistModule} from './psychologist/psychologist.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/patients', // TODO: Redireccionar a playlist como pagina de inicio.
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
    RouterModule.forRoot(routes),
    LayoutModule,
    PatientModule,
    PsychologistModule
    AppRoutingModule,
    CategoryModule,
    HttpClientModule,
    AddAudioModule,
    MatSliderModule,
    BrowserAnimationsModule,
    GetAudiosModule,
    DeleteAudioModule,
    UpdateAudioModule
  ],
  exports: [
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

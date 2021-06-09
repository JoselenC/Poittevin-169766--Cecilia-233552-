import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BrowserModule} from '@angular/platform-browser';
import {MatSliderModule} from '@angular/material/slider';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormFieldAppearanceExample} from './material.component';

import {LayoutModule} from './layout/layout.module';
import {AppComponent} from './app.component';
import {CategoryModule} from './category/category.module';
import {ContentModule} from './audio/content.module';

import {PatientModule} from './patient/patient.module';
import {PsychologistModule} from './psychologist/psychologist.module';
import {PlaylistModule} from './playlist/playlist.module';
import {LoginModule} from './login/login.module';
import {AuthInterceptor} from './interceptors/auth.interceptor';
import {ImportContentModule} from './import/import-content.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/playlists',
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
    PatientModule,
    PsychologistModule,
    CategoryModule,
    ContentModule,
    PlaylistModule,
    LoginModule,
    ImportContentModule,
    RouterModule.forRoot(routes),
  ],
  exports: [
    RouterModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

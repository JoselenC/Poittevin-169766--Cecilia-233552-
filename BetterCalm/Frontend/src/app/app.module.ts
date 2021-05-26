import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CategoryModule} from "./category/category.module";
import {HttpClientModule} from "@angular/common/http";
import {AddAudioModule} from "./audioComponents/add-audio/add-audio.module";
import {MatSliderModule} from "@angular/material/slider";
import {FormFieldAppearanceExample} from "./material.component";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {GetAudiosModule} from "./audioComponents/get-audios/get-audios.module";
import {DeleteAudioModule} from "./audioComponents/delete-audio/delete-audio.module";
import {UpdateAudioModule} from "./audioComponents/update-audio/update-audio.module";


@NgModule({
  declarations: [
    AppComponent,
    FormFieldAppearanceExample
  ],
  imports: [
    BrowserModule,
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
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {UpdateAudioComponent} from "./update-audio.component";
import {MaterialComponentsModule} from "../../material.module";
import {AudioService} from "../../services/Audio/audio.service";
import {AddAudioModule} from "../add-audio/add-audio.module";
import {FormsModule} from "@angular/forms";
import {CategoryModule} from "../../category/category.module";



@NgModule({
  declarations: [
    UpdateAudioComponent
  ],
  exports: [
    UpdateAudioComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    AddAudioModule,
    FormsModule,
    CategoryModule
  ],
  providers: [AudioService],
})
export class UpdateAudioModule { }

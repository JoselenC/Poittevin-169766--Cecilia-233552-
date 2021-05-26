import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MaterialComponentsModule} from "../../material.module";
import {HttpClientModule} from "@angular/common/http";
import {AudioService} from "../../services/Audio/audio.service";
import {DeleteAudioComponent} from "./delete-audio.component";



@NgModule({
  declarations: [DeleteAudioComponent],
  exports:[
    DeleteAudioComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule
  ],
  providers: [AudioService],
})
export class DeleteAudioModule { }

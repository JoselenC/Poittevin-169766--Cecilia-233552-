import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetAudiosComponent} from "./get-audios.component";
import {HttpClientModule} from "@angular/common/http";
import {AudioService} from "../../services/Audio/audio.service";
import {MaterialComponentsModule} from "../../material.module";


@NgModule({
  declarations: [GetAudiosComponent],
  exports:[
    GetAudiosComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule
  ],
  providers: [AudioService],
})
export class GetAudiosModule { }

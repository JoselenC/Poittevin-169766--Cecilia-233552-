import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {AddAudioComponent} from "./add-audio.component";
import {MaterialComponentsModule} from "../../material.module";
import {FormsModule} from "@angular/forms";
import {MatOptionModule} from "@angular/material/core";
import {CategoryModule} from "../../category/category.module";

@NgModule({
  declarations: [AddAudioComponent],
  exports: [
    AddAudioComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    FormsModule,
    MatOptionModule,
    CategoryModule
  ]
})
export class AddAudioModule { }



import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {AddSongComponent} from "./add-song.component";



@NgModule({
  declarations: [AddSongComponent],
  exports: [
    AddSongComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class AddSongModule { }

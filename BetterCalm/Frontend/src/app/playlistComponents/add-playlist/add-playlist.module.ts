import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AddPlaylistComponent} from "./add-playlist.component";
import {HttpClientModule} from "@angular/common/http";
import {MaterialComponentsModule} from "../../material.module";
import {FormsModule} from "@angular/forms";
import {MatOptionModule} from "@angular/material/core";
import {CategoryModule} from "../../categoryComponents/category.module";
import {GetAudiosModule} from "../../audioComponents/get-audios/get-audios.module";



@NgModule({
  declarations: [AddPlaylistComponent],
  exports:[AddPlaylistComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    FormsModule,
    MatOptionModule,
    CategoryModule,
    GetAudiosModule
  ]
})
export class AddPlaylistModule { }

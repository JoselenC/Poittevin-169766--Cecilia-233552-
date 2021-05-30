import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {UpdateAudioComponent} from "../../audioComponents/update-audio/update-audio.component";
import {HttpClientModule} from "@angular/common/http";
import {MaterialComponentsModule} from "../../material.module";
import {AddAudioModule} from "../../audioComponents/add-audio/add-audio.module";
import {FormsModule} from "@angular/forms";
import {CategoryModule} from "../../categoryComponents/category.module";
import {GetAudiosModule} from "../../audioComponents/get-audios/get-audios.module";
import {PlaylistService} from "../../services/Playlist/playlist.service";
import {UpdatePlaylistComponent} from "./update-playlist.component";



@NgModule({
  declarations: [UpdatePlaylistComponent],
  exports:[UpdatePlaylistComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    AddAudioModule,
    FormsModule,
    CategoryModule,
    GetAudiosModule
  ],
  providers:[PlaylistService]
})
export class UpdatePlaylistModule { }

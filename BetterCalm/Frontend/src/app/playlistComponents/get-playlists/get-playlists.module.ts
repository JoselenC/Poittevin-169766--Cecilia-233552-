import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GetPlaylistsComponent} from "./get-playlists.component";
import {HttpClientModule} from "@angular/common/http";
import {MaterialComponentsModule} from "../../material.module";
import {PlaylistService} from "../../services/Playlist/playlist.service";

@NgModule({
  declarations: [GetPlaylistsComponent],
  exports:[GetPlaylistsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule
  ],
  providers:[PlaylistService]
})
export class GetPlaylistsModule { }

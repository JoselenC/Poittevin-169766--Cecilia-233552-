import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DeletePlaylistComponent} from "./delete-playlist.component";
import {HttpClientModule} from "@angular/common/http";
import {MaterialComponentsModule} from "../../material.module";
import {PlaylistService} from "../../services/Playlist/playlist.service";



@NgModule({
  declarations: [DeletePlaylistComponent],
  exports:[DeletePlaylistComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule
  ],
  providers:[PlaylistService],
})
export class DeletePlaylistModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {MaterialComponentsModule} from '../../material.module';
import {AddAudioModule} from '../../audio/add-content/add-content.module';
import {FormsModule} from '@angular/forms';
import {CategoryModule} from '../../category/category.module';
import {GetContentsModule} from '../../audio/get-contents/get-contents.module';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {UpdatePlaylistComponent} from './update-playlist.component';



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
    GetContentsModule
  ],
  providers:[PlaylistService]
})
export class UpdatePlaylistModule { }

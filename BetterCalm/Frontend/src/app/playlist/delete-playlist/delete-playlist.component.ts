import { Component, OnInit } from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';


@Component({
  selector: 'app-delete-playlist',
  templateUrl: './delete-playlist.component.html',
  styleUrls: ['./delete-playlist.component.css']
})
export class DeletePlaylistComponent implements OnInit {

  public playlists: Playlist [] = [];

  constructor(private playlistService: PlaylistService) { }

  ngOnInit(): void {
    this.playlistService.getAll().
      subscribe(
      ((data: Array<Playlist>) => this.result(data)),
      ((error: any) => alert(error.message))
    );
  }
  private result(data: Array<Playlist>): void {
    this.playlists = data;
  }

  DeletePlaylist(playlist: Playlist): void {
    this.playlistService.delete(playlist.id).subscribe(
      (error: any) => alert(error)
    );
  }
}

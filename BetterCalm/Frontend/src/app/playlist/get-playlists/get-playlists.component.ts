import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';


@Component({
  selector: 'app-get-playlists',
  templateUrl: './get-playlists.component.html',
  styleUrls: ['./get-playlists.component.css']
})
export class GetPlaylistsComponent implements OnInit {

  public playlists: Playlist[] = [];

  constructor(private playlistService: PlaylistService) {
  }

  ngOnInit(): void {
    this.playlistService.getAll()
      .subscribe(
        ((data: Array<Playlist>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Playlist>): void {
    this.playlists = data;
  }
}

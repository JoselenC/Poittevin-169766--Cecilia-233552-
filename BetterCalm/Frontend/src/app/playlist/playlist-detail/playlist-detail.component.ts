import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {ActivatedRoute} from '@angular/router';
import {PlaylistService} from '../../services/playlist/playlist.service';

@Component({
  selector: 'app-playlist-detail',
  templateUrl: './playlist-detail.component.html',
  styleUrls: ['./playlist-detail.component.css']
})
export class PlaylistDetailComponent implements OnInit {
  playlist: Playlist | undefined;

  constructor(
    private route: ActivatedRoute,
    private playlistService: PlaylistService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const playlistId = Number(routeParams.get('playlistId'));

    this.playlistService.getById(playlistId).subscribe(
      playlist => {
        this.playlist = playlist;
      }
    );
  }

}

import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-playlists',
  templateUrl: './get-playlists.component.html',
  styleUrls: ['./get-playlists.component.css']
})
export class GetPlaylistsComponent implements OnInit {

  public playlists: Playlist[] = [];

  constructor(
    private playlistService: PlaylistService,
    private router: Router
  ) {  }

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

  navigateTo(playlistId: number): void {
    this.router.navigate(['playlists', playlistId]);
  }

  delete(id: number): void {
    this.playlistService.delete(id).subscribe(
      (error: any) => alert(error)
    );
    this.playlists = this.playlists.filter(p => p.id !== id);
  }
}

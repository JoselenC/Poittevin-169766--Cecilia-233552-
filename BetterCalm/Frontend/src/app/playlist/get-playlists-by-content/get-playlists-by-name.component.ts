import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-playlists-by-content',
  templateUrl: './get-playlists-by-content.component.html',
  styleUrls: ['./get-playlists-by-content.component.css']
})
export class GetPlaylistsByContentComponent implements OnInit {

  public playlists: Playlist[] = [];
  filter = '';

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

  filtrar(): void {
    this.playlistService.getByContentName(this.filter).subscribe(
      ((data: Array<Playlist>) => this.getByContentName(data)),
      ((error: any) => alert(error.message))
    );
  }

  getByContentName(data: Array<Playlist>): void{
    this.playlists = data;
  }
}

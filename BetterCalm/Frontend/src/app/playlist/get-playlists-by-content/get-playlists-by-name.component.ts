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
  public url = 'https://i.pinimg.com/originals/90/e3/41/90e34121229253d293dcd6e8e40b6f44.jpg';
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
    );
    this.playlists = this.playlists.filter(p => p.id !== id);
  }

  filtrar(): void {
    this.playlistService.getByContentName(this.filter).subscribe(
      ((data: Array<Playlist>) => this.getByContentName(data)),
    );
  }

  getByContentName(data: Array<Playlist>): void{
    this.playlists = data;
  }
}

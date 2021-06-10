import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-playlists-by-name',
  templateUrl: './get-playlists-by-name.component.html',
  styleUrls: ['./get-playlists-by-name.component.css']
})
export class GetPlaylistsByNameComponent implements OnInit {

  public playlists: Playlist[] = [];
  filter = '';
  public url = 'https://i.pinimg.com/originals/90/e3/41/90e34121229253d293dcd6e8e40b6f44.jpg';
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
    this.playlistService.getByName(this.filter).subscribe(
      ((data: Array<Playlist>) => this.getByName(data)),
      ((error: any) => alert(error.message))
    );
  }

  getByName(data: Array<Playlist>): void{
    this.playlists = data;
  }
}

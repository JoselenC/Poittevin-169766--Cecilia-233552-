import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-playlists-by-category',
  templateUrl: './get-playlists-by-category.component.html',
  styleUrls: ['./get-playlists-by-category.component.css']
})
export class GetPlaylistsByCategoryComponent implements OnInit {

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
    this.playlistService.getByCategoryName(this.filter).subscribe(
      ((data: Array<Playlist>) => this.getByCategoryName(data)),
      ((error: any) => alert(error.message))
    );
  }

  getByCategoryName(data: Array<Playlist>): void{
    this.playlists = data;
  }
}

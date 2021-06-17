import {Component, OnInit} from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';
import {Patient} from '../../models/Patient';
import {Category} from '../../models/Category';
import {Content} from '../../models/Content';


@Component({
  selector: 'app-get-playlists',
  templateUrl: './get-playlists.component.html',
  styleUrls: ['./get-playlists.component.css']
})
export class GetPlaylistsComponent implements OnInit {
  public url = 'https://i.pinimg.com/originals/90/e3/41/90e34121229253d293dcd6e8e40b6f44.jpg';
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

  navigateToAddEdit(playlist ?: Playlist): void {
    if (playlist === undefined) {
      playlist = new Playlist (0,
        '',
        '',
        '',
        new Array<Category>(),
        new Array<Content>()
      ); }
    this.router.navigate(['add-playlist'], {state: {playlist}});
  }
}

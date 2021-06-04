import { Component, OnInit } from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {ActivatedRoute, Router} from '@angular/router';
import {PlaylistService} from '../../services/playlist/playlist.service';

@Component({
  selector: 'app-update-playlist',
  templateUrl: './update-playlist.component.html',
  styleUrls: ['./update-playlist.component.css']
})
export class UpdatePlaylistComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private playlistService: PlaylistService
  ) { }

public playlistId = 0;
  public playlists: Playlist [] = [];


  id = 0;
  name = '';
  description = '';
  urlImage = '';
  private data = Playlist;

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.playlistId = Number(id);
    this.playlistService.getAll()
      .subscribe(
        ((data: Array<Playlist>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }
  private result(data: Array<Playlist>): void {
    this.playlists = data;
  }

  updateplaylist(id: number): void {
    const playlist = new Playlist (
      this.id,
      this.name,
      this.description,
      this.urlImage,
    );
    this.playlistService.update(id, playlist).subscribe(
      (data: Playlist) => this.resultData(data),
      (error: any) => alert(error)
    );
  }

  // tslint:disable-next-line:typedef
  private resultData(data: Playlist) {
    this.router.navigate(['/playlist']);
  }

}

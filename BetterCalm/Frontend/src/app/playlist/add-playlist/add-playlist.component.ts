import { Component, OnInit } from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {Router} from '@angular/router';
import {PlaylistService} from '../../services/playlist/playlist.service';

@Component({
  selector: 'app-add-playlist',
  templateUrl: './add-playlist.component.html',
  styleUrls: ['./add-playlist.component.css']
})
export class AddPlaylistComponent implements OnInit {

  constructor(
  private servicePlaylist: PlaylistService,
  private router: Router
  ){ }

  id = 0;
  name = '';
  urlImage = '';
  description = '';

  ngOnInit(): void {
  }


  addPlaylist(): void{
    const playlist = new Playlist(
      this.id,
      this.name,
      this.urlImage,
      this.description
    );
    this.servicePlaylist.add(playlist).subscribe(
      (data: Playlist) => this.result(data),
      (error: any) => alert(error)
    );
  }
  // tslint:disable-next-line:typedef
  private result(data: Playlist) {
    this.router.navigate(['/playlist']);
  }

}

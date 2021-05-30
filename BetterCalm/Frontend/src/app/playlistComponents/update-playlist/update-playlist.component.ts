import { Component, OnInit } from '@angular/core';
import {Playlist} from "../../models/Playlist";
import {ActivatedRoute, Router} from "@angular/router";
import {PlaylistService} from "../../services/Playlist/playlist.service";

@Component({
  selector: 'app-update-playlist',
  templateUrl: './update-playlist.component.html',
  styleUrls: ['./update-playlist.component.css']
})
export class UpdatePlaylistComponent implements OnInit {

public playlistId:number=0;
  public playlists:Playlist[]=[]

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private playlistService:PlaylistService
  ) { }

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


  id:number=0;
  name: string="";
  description: string="";
  urlImage: string="";
  private _data!: Playlist;

  updateplaylist(id:number):void {
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

  private resultData(data: Playlist) {
    this.router.navigate(["/Playlist"]);
  }

}

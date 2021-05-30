import { Component, OnInit } from '@angular/core';
import {Playlist} from "../../models/Playlist";
import {Router} from "@angular/router";
import {PlaylistService} from "../../services/Playlist/playlist.service";
import {Audio} from "../../models/Audio";

@Component({
  selector: 'app-add-playlist',
  templateUrl: './add-playlist.component.html',
  styleUrls: ['./add-playlist.component.css']
})
export class AddPlaylistComponent implements OnInit {

  constructor(
  private servicePlaylist:PlaylistService,
  private router:Router
  ){ }

  ngOnInit(): void {
  }

  id:number=0;
  name:string="";
  urlImage:string="";
  description:string="";


  addPlaylist():void{
    const playlist= new Playlist(
      this.id,
      this.name,
      this.urlImage,
      this.description
    );
    this.servicePlaylist.add(playlist).subscribe(
      (data:Playlist)=>this.result(data),
      (error:any)=>alert(error)
    )
  }
  private result(data: Playlist) {
    this.router.navigate(["/Playlist"]);
  }

}

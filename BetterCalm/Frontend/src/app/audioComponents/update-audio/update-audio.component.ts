import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {AudioService} from "../../services/Audio/audio.service";
import {Audio} from "../../models/Audio";

@Component({
  selector: 'app-update-audio',
  templateUrl: './update-audio.component.html',
  styleUrls: ['./update-audio.component.css']
})
export class UpdateAudioComponent implements OnInit {
public audioId:number=0;
  public audios:Audio[]=[]

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private audioService:AudioService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.audioId = Number(id);
    this.audioService.getAll()
      .subscribe(
        ((data: Array<Audio>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }
  private result(data: Array<Audio>): void {
    this.audios = data;
  }


id:number=0;
  name: string="";
  authorName: string="";
  urlAudio: string="";
  urlImage: string="";
  _duration: string="";
  private _data!: Audio;

  updateAudio(id:number):void {
    const audio = new Audio (
      this.id,
      this.name,
      this.authorName,
      this.urlAudio,
      this.urlImage,
      this._duration
    );
    this.audioService.update(id, audio).subscribe(
      (data: Audio) => this.resultData(data),
      (error: any) => alert(error)
    );
  }

  private resultData(data: Audio) {
    this.router.navigate(["/Audio"]);
  }
}

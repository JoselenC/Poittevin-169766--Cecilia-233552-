import { Component, OnInit } from '@angular/core';
import {Audio} from "../../models/Audio";
import {AudioService} from "../../services/Audio/audio.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-audio',
  templateUrl: './add-audio.component.html',
  styleUrls: ['./add-audio.component.css']
})
export class AddAudioComponent implements OnInit {
  get duration(): string {
    return this._duration;
  }

  set duration(value: string) {
    this._duration = value;
  }
  get data(): Audio {
    return this._data;
  }
  set data(value: Audio) {
    this._data = value;
  }

  constructor(
    private serviceAudio: AudioService,
    private router: Router
  ) {}

  ngOnInit(): void {
  }

  id:number=0;
  name: string="";
  authorName: string="";
  urlAudio: string="";
  urlImage: string="";
  _duration: string="";
  private _data!: Audio;


  addAudio(): void {
    const audio = new Audio (
      this.id,
      this.name,
      this.authorName,
      this.urlAudio,
      this.urlImage,
      this._duration
    );
    this.serviceAudio.newAudio(audio).subscribe(
      (data: Audio) => this.result(data),
      (error: any) => alert(error)
    );
  }

  private result(data: Audio) {
    this.router.navigate(["/Audio"]);
  }
}


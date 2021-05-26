import { Component, OnInit } from '@angular/core';
import {Audio} from "../../models/Audio";
import {AudioService} from "../../services/Audio/audio.service";

@Component({
  selector: 'app-delete-audio',
  templateUrl: './delete-audio.component.html',
  styleUrls: ['./delete-audio.component.css']
})
export class DeleteAudioComponent implements OnInit {

  public audios:Audio[]=[]

  constructor(private audioService:AudioService) { }

  ngOnInit(): void {
    this.audioService.getAll()
      .subscribe(
        ((data: Array<Audio>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }
  private result(data: Array<Audio>): void {
    this.audios = data;
  }

  DeleteAudio(audio: Audio):void {
    this.audioService.delete(audio.id).subscribe(
      (error: any) => alert(error)
    );
  }
}

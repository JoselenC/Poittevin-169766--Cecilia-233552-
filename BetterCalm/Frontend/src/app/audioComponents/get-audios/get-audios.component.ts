import {Component, OnInit} from '@angular/core';
import {AudioService} from '../../services/Audio/audio.service';
import {Audio} from '../../models/Audio';

@Component({
  selector: 'app-get-audios',
  templateUrl: './get-audios.component.html',
  styleUrls: ['./get-audios.component.css']
})
export class GetAudiosComponent implements OnInit {

  public audios: Audio[] = [];

  constructor(private audioService: AudioService) {
  }

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


}

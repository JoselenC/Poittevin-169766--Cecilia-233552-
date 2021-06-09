import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {PsychologyService} from '../../services/Psychology/psychology.service';
import {Psychology} from '../../models/Psychology';

@Component({
  selector: 'app-psychology-detail',
  templateUrl: './psychology-detail.component.html',
  styleUrls: ['./psychology-detail.component.css']
})
export class PsychologyDetailComponent implements OnInit {

  psychology: Psychology | undefined;

  constructor(
    private route: ActivatedRoute,
    private psychologyService: PsychologyService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const psychologyId = Number(routeParams.get('psychologyId'));

    this.psychologyService.getById(psychologyId).subscribe(
      psychology => {
        this.psychology = psychology;
      }
    );
  }

}

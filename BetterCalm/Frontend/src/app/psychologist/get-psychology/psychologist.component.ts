import {Component, OnInit} from '@angular/core';
import {Psychology} from '../../models/Psychology';
import {Router} from '@angular/router';
import {PsychologyService} from '../../services/Psychology/psychology.service';

@Component({
  selector: 'app-psychology',
  templateUrl: './psychologist.component.html',
  styleUrls: ['./psychologist.component.css']
})
export class PsychologyComponent implements OnInit {
  public psychologies: Psychology[] = [];

  constructor(
    private psychologyService: PsychologyService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.psychologyService.getAll()
      .subscribe(
        ((data: Array<Psychology>) => this.result(data)),
      );
  }

  private result(data: Array<Psychology>): void {
    this.psychologies = data;
  }

  delete(id: number): void {
    this.psychologyService.delete(id).subscribe(
    );
    this.psychologies = this.psychologies.filter(p => p.psychologistId !== id);
  }

  navigateTo(psychologyId: number): void {
    this.router.navigate(['psychology', psychologyId]);
  }

  navigateToAddEdit(psychology ?: Psychology): void {
    if (psychology === undefined) {
      psychology = new Psychology(
        0,
        '',
        '',
        '',
        false,
        500,
        [],
        []
      );
    }
    this.router.navigate(['add-psychology'], {state: {psychology}});
  }
}

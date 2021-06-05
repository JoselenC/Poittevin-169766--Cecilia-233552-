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
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Psychology>): void {
    this.psychologies = data;
    console.log(this.psychologies);
  }

  delete(id: number): void {
    this.psychologyService.delete(id).subscribe(
      (error: any) => alert(error)
    );
    this.psychologies = this.psychologies.filter(p => p.psychologistId !== id);
  }

  navigateTo(psychologyId: number): void {
    this.router.navigate(['psychology', psychologyId]);
  }
}

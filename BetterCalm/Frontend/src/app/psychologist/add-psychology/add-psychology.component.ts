import {Component, Input, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Psychology} from '../../models/Psychology';
import {PsychologyService} from '../../services/Psychology/psychology.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {Problematic} from '../../models/Problematic';

@Component({
  selector: 'app-add-psychology',
  templateUrl: './add-psychology.component.html',
  styleUrls: ['./add-psychology.component.css']
})

export class AddPsychologyComponent implements OnInit {
  public psychology: Psychology = new Psychology(
    0,
    '',
    '',
    '',
    false,
    500,
    [],
    []
  );
  problematics: Array<Problematic> = [
    new Problematic(1, 'Depresión'),
    new Problematic(2, 'Estrés'),
    new Problematic(3, 'Ansiedad'),
    new Problematic(4, 'Autoestima'),
    new Problematic(5, 'Enojo'),
    new Problematic(6, 'Relaciones'),
    new Problematic(7, 'Duelo'),
    new Problematic(8, 'Otros')
  ];
  selectedProblematics: Array<string> = [];
  rates: Array<number> = [
    500,
    750,
    1000,
    2000
  ];

  constructor(
    private psychologyService: PsychologyService,
    private router: Router,
  ) {
  }

  addPsychology(): void {
    this.psychology.problematics = this.selectedProblematics.map((x: any) => new Problematic(0, x));
    if (this.psychology.psychologistId === 0) {
      this.psychologyService.add(this.psychology).subscribe(
        (data: Psychology) => this.result(data),
        (error: any) => {
          alert(error);
        }
      );
    } else {
      this.psychologyService.update(this.psychology).subscribe(
        (data: Psychology) => this.result(data),
        (error: any) => {
          alert(error);
        }
      );
    }
  }

  private result(data: Psychology): void {
    this.router.navigate(['/psychologits']);
  }

  ngOnInit(): void {
    if (history.state.psychology !== undefined) {
      this.psychology = history.state.psychology;
      this.selectedProblematics = this.psychology.problematics.map((x: any) => x.name);
    }
  }

}

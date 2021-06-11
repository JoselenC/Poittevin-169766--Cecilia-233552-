import {Component, OnInit} from '@angular/core';
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
  name !: string;
  lastName !: string;
  address !: string;
  worksOnline  !: boolean;
  problematics: Array<string> = [
    'Depresión',
    'Estrés',
    'Ansiedad',
    'Autoestima',
    'Enojo',
    'Relaciones',
    'Duelo',
    'Otros'
  ];
  problems = new FormControl();
  problematicGroup ?: FormGroup;

  rates: Array<number> = [
    500,
    750,
    1000,
    2000
  ];
  rate = new FormControl();
  rateGroup ?: FormGroup;

  constructor(
    private psychologyService: PsychologyService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
  }

  addPsychology(): void {
    const psychology = new Psychology(
      0,
      this.name,
      this.lastName,
      this.address,
      this.worksOnline,
      this.rate.value,
      this.problems.value.map((x: any) => (new Problematic(0, x))),
      undefined
    );
    this.psychologyService.add(psychology).subscribe(
      (data: Psychology) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
    );
  }

  private result(data: Psychology): void {
    this.router.navigate(['/psychologits']);
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.problematicGroup = this.formBuilder.group({
      problemsToString: this.problems
    });

    this.rateGroup = this.formBuilder.group({
      rateToString: this.rates
    });
  }
}

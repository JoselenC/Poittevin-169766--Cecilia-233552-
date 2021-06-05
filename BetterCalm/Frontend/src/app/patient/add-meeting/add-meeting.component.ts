import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {Problematic} from '../../models/Problematic';
import {ScheduleMeeting} from '../../models/ScheduleMeeting';
import {Patient} from '../../models/Patient';
import {PatientService} from '../../services/patient/patient.service';

@Component({
  selector: 'app-add-meeting',
  templateUrl: './add-meeting.component.html',
  styleUrls: ['./add-meeting.component.css']
})
export class AddMeetingComponent implements OnInit {
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
  patientId !: number;

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private patientService: PatientService
  ) {
  }

  addSchedule(): void {
    const schedule = new ScheduleMeeting(
      new Patient(this.patientId, 'pedro'),
      new Problematic(0, this.problems.value),
    );
    this.patientService.scheduleMeeting(schedule).subscribe(
      (data: any) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
    );
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.patientId = Number(routeParams.get('patientId'));
    this.initFormProblematics();
  }

  result(data: any): void {
    console.log(data);
    alert(data);
  }

  initFormProblematics(): void {
    this.problematicGroup = this.formBuilder.group({
      problemsToString: this.problems
    });
  }

}

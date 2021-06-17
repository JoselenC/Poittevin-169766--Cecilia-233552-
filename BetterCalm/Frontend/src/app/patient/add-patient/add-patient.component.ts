import {Component, Inject, Input, OnInit} from '@angular/core';
import {Patient} from '../../models/Patient';
import {PatientService} from '../../services/patient/patient.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css'],
})

export class AddPatientComponent implements OnInit {
  public patient: Patient = new Patient(
    0,
    '',
    '',
    '',
    new Date(),
    []
  );

  constructor(
    private patientService: PatientService,
    private router: Router,
  ) {
  }

  editOrAddPatient(): void {
    if (this.patient.id === 0) {
      this.patientService.add(this.patient).subscribe(
        (data: Patient) => this.result(data),
      );
    } else {
      this.patientService.update(this.patient).subscribe(
        (data: Patient) => this.result(data),
      );
    }
  }

  private result(data: Patient): void {
    this.router.navigate(['/patients']);
  }

  ngOnInit(): void {
    if (history.state.patient !== undefined) {
      this.patient = history.state.patient;
    }
  }

}

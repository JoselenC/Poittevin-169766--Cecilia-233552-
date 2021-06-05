import {Component, OnInit} from '@angular/core';
import {Patient} from '../../models/Patient';
import {PatientService} from '../../services/patient/patient.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})

export class AddPatientComponent implements OnInit {
  name ?: string;
  lastName ?: string;
  cellphone ?: string;
  birthday ?: Date;

  constructor(
    private patientService: PatientService,
    private router: Router
  ) {
  }

  addPatient(): void {
    const patient = new Patient(
      0,
      this.name,
      this.lastName,
      this.cellphone,
      undefined
    );
    this.patientService.add(patient).subscribe(
      (data: Patient) => this.result(data),
      (error: any) => alert(error)
    );
  }

  private result(data: Patient): void {
    this.router.navigate(['/patients']);
  }

  ngOnInit(): void {
  }

}

import {Component, OnInit} from '@angular/core';
import {PatientService} from '../services/patient/patient.service';
import {Patient} from '../models/Patient';
import {Router} from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  public patients: Patient[] = [];

  constructor(private patientService: PatientService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.patientService.getAll()
      .subscribe(
        ((data: Array<Patient>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Patient>): void {
    this.patients = data;
  }

  navigateTo(patientId: number): void {
    this.router.navigate(['patients', patientId]);
  }
}

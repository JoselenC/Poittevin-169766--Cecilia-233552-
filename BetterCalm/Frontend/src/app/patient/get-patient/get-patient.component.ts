import {Component, OnInit} from '@angular/core';
import {PatientService} from '../../services/patient/patient.service';
import {Patient} from '../../models/Patient';
import {Router} from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './get-patient.component.html',
  styleUrls: ['./get-patient.component.css']
})
export class GetPatientComponent implements OnInit {
  public patients: Patient[] = [];

  constructor(
    private patientService: PatientService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.patientService.getAll()
      .subscribe(
        ((data: Array<Patient>) => this.result(data)),
      );
  }

  private result(data: Array<Patient>): void {
    this.patients = data;
  }

  delete(id: number): void {
    this.patientService.delete(id).subscribe(
    );
    this.patients = this.patients.filter(p => p.id !== id);
  }

  navigateTo(patientId: number): void {
    this.router.navigate(['patients', patientId]);
  }

  navigateToAddEdit(patient ?: Patient): void {
    if (patient === undefined) {
      patient = new Patient(0, '', '', '', new Date(), []);
    }
    this.router.navigate(['add-patient'], {state: {patient}});
  }
}

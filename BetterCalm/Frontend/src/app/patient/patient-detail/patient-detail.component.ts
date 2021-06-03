import {Component, OnInit} from '@angular/core';
import {Patient} from '../../models/Patient';
import {ActivatedRoute} from '@angular/router';
import {PatientService} from '../../services/patient/patient.service';

@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html',
  styleUrls: ['./patient-detail.component.css']
})
export class PatientDetailComponent implements OnInit {
  patient: Patient | undefined;

  constructor(
    private route: ActivatedRoute,
    private patientService: PatientService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const patientId = Number(routeParams.get('patientId'));

    this.patientService.getById(patientId).subscribe(
      patient => {
        this.patient = patient;
        console.log(this.patient);
      }
    );
  }

}

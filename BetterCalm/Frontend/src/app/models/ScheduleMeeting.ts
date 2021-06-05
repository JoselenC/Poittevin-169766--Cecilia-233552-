import {Patient} from './Patient';
import {Problematic} from './Problematic';

export class ScheduleMeeting {
  patient !: Patient;
  problematic: Problematic;


  constructor(
    patient: Patient,
    problematic: Problematic
  ) {
    this.patient = patient;
    this.problematic = problematic;
  }

}

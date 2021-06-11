import {Patient} from './Patient';
import {Problematic} from './Problematic';

export class ScheduleMeeting {
  patient !: Patient;
  problematic: Problematic;
  duration: number;


  constructor(
    patient: Patient,
    problematic: Problematic,
    duration: number
  ) {
    this.patient = patient;
    this.problematic = problematic;
    this.duration = duration;
  }

}

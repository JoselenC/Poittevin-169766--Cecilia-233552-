import {Patient} from './Patient';
import {Psychology} from './Psychology';

export class Meeting {
  id!: number;
  patient: Patient;
  psychologist: Psychology;
  dateTime: Date;
  address: string;
  duration: number;
  cost: number;


  constructor(
    id: number,
    patient: Patient,
    psychologist: Psychology,
    dateTime: Date,
    address: string,
    duration: number,
    cost: number
  ) {
    this.id = id;
    this.patient = patient;
    this.psychologist = psychologist;
    this.dateTime = dateTime;
    this.address = address;
    this.duration = duration;
    this.cost = cost;
  }
}

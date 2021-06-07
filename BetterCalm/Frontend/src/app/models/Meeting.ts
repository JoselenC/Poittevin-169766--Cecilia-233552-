import {Patient} from './Patient';
import {Psychology} from './Psychology';

export class Meeting {
  id!: number;
  patient: Patient;
  psychologist: Psychology;
  dateTime: Date;
  address: string;


  constructor(id: number, patient: Patient, psychologist: Psychology, dateTime: Date, address: string){
    this.id = id;
    this.patient = patient;
    this.psychologist = psychologist;
    this.dateTime = dateTime;
    this.address = address
  }

}

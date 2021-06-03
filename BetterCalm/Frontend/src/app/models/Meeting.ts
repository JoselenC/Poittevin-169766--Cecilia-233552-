import {Patient} from './Patient';
import {Psychologist} from './Psychologist';

export class Meeting {
  id!: number;
  patient: Patient;
  psychologist: Psychologist;
  dateTime: Date;
  address: string;


  constructor(id: number, patient: Patient, psychologist: Psychologist, dateTime: Date, address: string){
    this.id = id;
    this.patient = patient;
    this.psychologist = psychologist;
    this.dateTime = dateTime;
    this.address = address
  }

}

import {Meeting} from './Meeting';

export class Patient {
  id : number;
  name ?: string;
  lastName ?: string;
  cellphone ?: string;
  meetings ?: Array<Meeting>|undefined;


  constructor(id: number, name ?: string, lastName ?: string, cellphone ?: string, meetings ?: Array<Meeting>){
    this.id = id;
    this.name = name;
    this.lastName = lastName;
    this.cellphone = cellphone;
    this.meetings = meetings;
  }

}

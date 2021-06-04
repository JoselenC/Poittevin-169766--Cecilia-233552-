import {Meeting} from './Meeting';

export class Psychologist {
  id!: number;
  name: string;
  lastName: string;
  meetings: Array<Meeting>;


  constructor(id: number, name: string, lastName: string, meetings: Array<Meeting>){
    this.id = id;
    this.name = name;
    this.lastName = lastName;
    this.meetings = meetings;
  }

}

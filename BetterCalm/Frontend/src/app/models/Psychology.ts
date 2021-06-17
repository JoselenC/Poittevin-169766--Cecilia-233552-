import {Meeting} from './Meeting';
import {Problematic} from './Problematic';

export class Psychology {
  psychologistId!: number;
  name: string;
  lastName: string;
  address: string;
  worksOnline: boolean;
  rate: number;
  problematics: Array<Problematic>;
  meetings?: Array<Meeting>;


  constructor(
    psychologistId: number,
    name: string,
    lastName: string,
    address: string,
    worksOnline: boolean,
    rate: number,
    problematics: Array<Problematic>,
    meetings?: Array<Meeting>
  ) {
    this.psychologistId = psychologistId;
    this.name = name;
    this.lastName = lastName;
    this.address = address;
    this.worksOnline = worksOnline;
    this.rate = rate;
    this.problematics = problematics;
    this.meetings = meetings;
  }

}

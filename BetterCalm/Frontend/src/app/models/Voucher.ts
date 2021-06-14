import {Patient} from './Patient';
import {Status} from './Status';

export class Voucher {
  voucherId: number;
  patient !: Patient;
  meetingsAmount: number;
  status: Status;
  discount: number;


  constructor(
    voucherId: number,
    patient: Patient,
    meetingsAmount: number,
    status: number,
    discount: number
  ) {
    this.voucherId = voucherId;
    this.patient = patient;
    this.meetingsAmount = meetingsAmount;
    this.status = status;
    this.discount = discount;
  }

}

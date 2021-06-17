import {Injectable} from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Patient} from '../../models/Patient';
import {catchError} from 'rxjs/operators';
import {Playlist} from '../../models/Playlist';
import {ScheduleMeeting} from '../../models/ScheduleMeeting';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private patientUri = '/api/patient';
  private scheduleUri = this.patientUri + '/schedule/';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.patientUri);
  }

  getById(id: number): Observable<Patient> {
    return this.http.get<Patient>(this.patientUri + '/' + id);
  }

  add(patient: Patient): Observable<Patient> {
    return this.http.post<Patient>(this.patientUri, patient);
  }

  scheduleMeeting(schedule: ScheduleMeeting): Observable<any> {
    return this.http.post<ScheduleMeeting>(this.scheduleUri, schedule);
  }

  delete(id: number): Observable<Patient> {
    return this.http.delete<Patient>(this.patientUri + '/' + id);
  }

  update(patient: Patient): Observable<Patient> {
    return this.http.put<Patient>(this.patientUri + '/' + patient.id, patient);
  }
}

import {Injectable} from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Patient} from '../../models/Patient';
import {catchError} from 'rxjs/operators';
import {Playlist} from '../../models/Playlist';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private uri = '/api/patient';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.uri);
  }

  getById(id: number): Observable<Patient> {
    return this.http.get<Patient>(this.uri + '/' + id);
  }

  add(patient: Patient): Observable<Patient> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const options = {headers};
    return this.http.post<Patient>(this.uri, patient, options);
  }

  delete(id: number): Observable<Patient> {
    let headers: HttpHeaders;
    headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = {headers};
    return this.http.delete<Patient>(this.uri + '/' + id, options);
  }

}

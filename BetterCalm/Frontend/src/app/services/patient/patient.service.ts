import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Patient} from '../../models/Patient';

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
}

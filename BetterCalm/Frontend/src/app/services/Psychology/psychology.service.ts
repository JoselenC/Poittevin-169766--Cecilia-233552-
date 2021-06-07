import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Psychology} from '../../models/Psychology';


@Injectable({
  providedIn: 'root'
})
export class PsychologyService {
  private token = '4a475118-b08c-4c47-bd9f-660d09d44abd';
  private uri = '/api/Psychologist';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Psychology[]> {
    const headers = new HttpHeaders({
      Authorization: this.token
    });
    const options = {headers};
    return this.http.get<Psychology[]>(this.uri, options);
  }

  getById(id: number): Observable<Psychology> {
    const headers = new HttpHeaders({
      Authorization: this.token
    });
    const options = {headers};
    return this.http.get<Psychology>(this.uri + '/' + id, options);
  }

  add(psychology: Psychology): Observable<Psychology> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.token
    });
    const options = {headers};
    return this.http.post<Psychology>(this.uri, psychology, options);
  }

  delete(id: number): Observable<Psychology> {
    let headers: HttpHeaders;
    headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.token
    });
    const options = {headers};
    return this.http.delete<Psychology>(this.uri + '/' + id, options);
  }

}

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Psychology} from '../../models/Psychology';


@Injectable({
  providedIn: 'root'
})
export class PsychologyService {
  private uri = '/api/Psychologist';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Psychology[]> {
    return this.http.get<Psychology[]>(this.uri);
  }

  getById(id: number): Observable<Psychology> {
    return this.http.get<Psychology>(this.uri + '/' + id);
  }

  add(psychology: Psychology): Observable<Psychology> {
    return this.http.post<Psychology>(this.uri, psychology);
  }

  delete(id: number): Observable<Psychology> {
    return this.http.delete<Psychology>(this.uri + '/' + id);
  }

}

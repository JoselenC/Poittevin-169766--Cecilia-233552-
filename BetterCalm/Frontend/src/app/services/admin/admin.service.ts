import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Administrator} from '../../models/Administrator';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private administratorUri = '/api/administrator';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Administrator[]> {
    return this.http.get<Administrator[]>(this.administratorUri);
  }

  getById(id: number): Observable<Administrator> {
    return this.http.get<Administrator>(this.administratorUri + '/' + id);
  }

  add(administrator: Administrator): Observable<Administrator> {
    return this.http.post<Administrator>(this.administratorUri, administrator);
  }

  delete(id: number): Observable<Administrator> {
    return this.http.delete<Administrator>(this.administratorUri + '/' + id);
  }
}

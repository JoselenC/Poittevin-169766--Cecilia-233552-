import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Problematic} from '../../models/Problematic';

@Injectable({
  providedIn: 'root'
})
export class ProblematicService {
  private uri = '/api/problematic';

  constructor(private http: HttpClient) {
  }

  getProblematics(): Observable<Array<Problematic>> {
    return this.http.get<Array<Problematic>>(this.uri);
  }
}

import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {Observable, throwError} from 'rxjs';
import {Import} from '../../models/Import';
import {Category} from '../../models/Category';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  private uri = '/api/import';
  constructor(private http: HttpClient) { }

  importContent(importer: Import): Observable<Import>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const options = {headers};
    const httpRequest = this.http.post<any>(this.uri, importer, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  getImportNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.uri + '/name');
  }

  // tslint:disable-next-line:typedef
  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  }
}

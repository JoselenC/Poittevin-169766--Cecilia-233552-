import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Content} from '../../models/Content';
import {catchError} from 'rxjs/operators';
import {Playlist} from '../../models/Playlist';


@Injectable({
  providedIn: 'root'
})
export class ContentService {
  private uri = '/api/content';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Content[]> {
    return this.http.get<Content[]>(this.uri);
  }

  getById(id: number): Observable<Content> {
    return this.http.get<Content>(this.uri + '/' + id);
  }

  getByName(name: string): Observable<Content[]> {
    return this.http.get<Content[]>(this.uri + '/name?name=' + name);
  }

  getByCategoryName(name: string): Observable<Content[]> {
    return this.http.get<Content[]>(this.uri + '/Category?Category=' + name);
  }

  getByAuthorName(name: string): Observable<Content[]> {
    return this.http.get<Content[]>(this.uri + '/author?author=' + name);
  }

  newContent(content: Content): Observable<Content> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const options = {headers};
    const httpRequest = this.http.post<any>(this.uri, content, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id: number, content: Content): Observable<Content> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = {headers};
    const httpRequest = this.http.put<Content>(this.uri + '/' + id, content, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  delete(id: number): Observable<Content> {
    let headers: HttpHeaders;
    headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = {headers};
    return this.http.delete<Content>(this.uri + '/' + id, options);
  }

  // tslint:disable-next-line:typedef
  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  }
}

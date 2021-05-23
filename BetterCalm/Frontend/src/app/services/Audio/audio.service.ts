import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Audio} from "../../models/Audio"
import {catchError} from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class AudioService {
  private uri = '/api/Audio';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Audio[]> {
    return this.http.get<Audio[]>(this.uri)
  }

  getBy(id: number): Observable<Audio> {
    return this.http.get<Audio>(this.uri + '/' + id)
  }

  newAudio(audio: Audio): Observable<Audio> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {headers: headers};
    var httpRequest = this.http.post<any>(this.uri, audio, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id: number, audio: Audio): Observable<Audio> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = {headers: headers};
    var httpRequest = this.http.put<Audio>(this.uri + '/' + id, audio, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  delete(id: number): Observable<Audio> {
    let headers: HttpHeaders;
    headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = {headers: headers};
    var httpRequest = this.http.delete<Audio>(this.uri + '/' + id, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  };
}

import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Playlist} from '../../models/Playlist';
import {catchError} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PlaylistService {
  private uri = '/api/playlist';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Playlist[]> {
    return this.http.get<Playlist[]>(this.uri);
  }

  getBy(id: number): Observable<Playlist> {
    return this.http.get<Playlist>(this.uri + '/' + id);
  }

  add(playlist: Playlist): Observable<Playlist> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const options = {headers};
    const httpRequest = this.http.post<any>(this.uri, playlist, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  update(id: number, playlist: Playlist): Observable<Playlist> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = {headers};
    const httpRequest = this.http.put<Playlist>(this.uri + '/' + id, playlist, options)
      .pipe(catchError(this.handleError));
    return httpRequest;
  }

  delete(id: number): Observable<Playlist> {
    let headers: HttpHeaders;
    headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = {headers};
    return this.http.delete<Playlist>(this.uri + '/' + id, options);
  }
  // tslint:disable-next-line:typedef
  private handleError(error: HttpErrorResponse) {
    return throwError(error.error);
  }
}

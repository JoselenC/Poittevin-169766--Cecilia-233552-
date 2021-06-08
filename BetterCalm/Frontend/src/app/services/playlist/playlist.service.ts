import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Playlist} from '../../models/Playlist';


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

  getById(id: number): Observable<Playlist> {
    return this.http.get<Playlist>(this.uri + '/' + id);
  }

  getByName(name: string): Observable<Playlist[]> {
    return this.http.get<Playlist[]>(this.uri + '/name?name=' + name);
  }

  getByContentName(name: string): Observable<Playlist[]> {
    return this.http.get<Playlist[]>(this.uri + '/content?name=' + name);
  }

  getByCategoryName(name: string): Observable<Playlist[]> {
    return this.http.get<Playlist[]>(this.uri + '/category?name=' + name);
  }

  add(playlist: Playlist): Observable<Playlist> {
    return this.http.post<any>(this.uri, playlist);
  }

  update(id: number, playlist: Playlist): Observable<Playlist> {
    return this.http.put<Playlist>(this.uri + '/' + id, playlist);
  }

  delete(id: number): Observable<Playlist> {
    return this.http.delete<Playlist>(this.uri + '/' + id);
  }
}

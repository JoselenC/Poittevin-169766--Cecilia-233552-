import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Content} from '../../models/Content';


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
    return this.http.get<Content[]>(this.uri + '/Category?name=' + name);
  }

  getByAuthorName(name: string): Observable<Content[]> {
    return this.http.get<Content[]>(this.uri + '/author?author=' + name);
  }

  newContent(content: Content): Observable<Content> {
    return this.http.post<any>(this.uri, content);
  }

  update(id: number, content: Content): Observable<Content> {
    return this.http.put<Content>(this.uri + '/' + id, content);
  }

  delete(id?: number): Observable<Content> {
    return this.http.delete<Content>(this.uri + '/' + id);
  }

}

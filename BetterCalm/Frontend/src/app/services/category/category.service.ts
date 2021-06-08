﻿import {Injectable} from '@angular/core';
import {Category} from '../../models/Category';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  private uri = '/api/category';
  private id: number = 1;

  constructor(private http: HttpClient) {
  }

  getCategories(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.uri);
  }

  getBy(id: number): Observable<Category> {
    return this.http.get<Category>(this.uri + '/' + id);
  }
}

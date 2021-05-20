import { Injectable } from '@angular/core';
import { Category } from "../models/Category";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private WEB_API_URL: string = "https://localhost:5001/api/Category";
  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.WEB_API_URL);
  };
}

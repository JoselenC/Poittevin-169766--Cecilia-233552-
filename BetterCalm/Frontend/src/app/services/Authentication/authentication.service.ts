import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {LoginData} from '../../models/LoginData';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private uri = '/api/login';

  constructor(private http: HttpClient) {
  }

  login(loginData: LoginData): void {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const options = {headers};
    this.http.post<string>(
      this.uri,
      loginData,
      options
    ).subscribe(
      (token: any) => {
        localStorage.setItem('token', token.token);
      }
    );
  }

  getAuthorizationToken(): string {
    return (localStorage.getItem('token') ? localStorage.getItem('token') : '') as string;
  }
}

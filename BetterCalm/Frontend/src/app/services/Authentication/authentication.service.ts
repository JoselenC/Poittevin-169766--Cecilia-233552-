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
      (data: any) => {
        localStorage.setItem('token', data.token);
        localStorage.setItem('authData', JSON.stringify(data));
      }
    );
  }

  getLoginData(): LoginData|undefined  {
    const localData: string|null = localStorage.getItem('authData') ;
    if (localData) {
      return JSON.parse(localData);
    }
    return undefined;
  }

  getAuthorizationToken(): string {
    return (localStorage.getItem('token') ? localStorage.getItem('token') : '') as string;
  }
}

import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from '../../services/Authentication/authentication.service';
import {LoginData} from '../../models/LoginData';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  password ?: string;
  email ?: string;

  constructor(
    private authService: AuthenticationService
  ) {
  }

  ngOnInit(): void {
  }

  login(): void {
    if (this.email && this.password) {
      this.authService.login(new LoginData(this.email, this.password));
      alert('logged in successfully');
    }
    else{
      alert('Email and password can not be null');
    }
  }
}

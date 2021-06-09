import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {LoginData} from '../models/LoginData';
import {AuthenticationService} from '../services/Authentication/authentication.service';

@Component({
  selector: 'app-custom-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})

export class LayoutComponent implements OnInit {
  loggedData: LoginData | undefined;

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {
  }

  ngOnInit(): void {
    this.loggedData = this.authService.getLoginData();
  }
}

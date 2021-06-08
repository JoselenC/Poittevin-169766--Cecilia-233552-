import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../layout/layout.component';
import {LoginComponent} from './login-component/login.component';
import {FlexModule} from '@angular/flex-layout';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';

const routes: Routes = [
  {
    path: 'login',
    component: LayoutComponent,
    children: [
      { path: '', component: LoginComponent },
    ]
  }
];

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FlexModule,
    MatInputModule,
    MatButtonModule,
    FormsModule
  ],
  exports: [
    RouterModule
  ]
})
export class LoginModule { }

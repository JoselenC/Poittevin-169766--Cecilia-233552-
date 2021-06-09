import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {Administrator} from '../../models/Administrator';
import {AdminService} from '../../services/admin/admin.service';

@Component({
  selector: 'app-add-admin',
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.css']
})
export class AddAdminComponent implements OnInit {
  name ?: string;
  lastName ?: string;
  email ?: string;
  password ?: string;

  constructor(
    private adminService: AdminService,
    private router: Router
  ) {
  }

  addAdministrator(): void {
    const administrator = new Administrator(
      0,
      this.email,
      this.password,
      this.name,
      this.lastName,
    );
    this.adminService.add(administrator).subscribe(
      (data: Administrator) => this.result(data),
      (error: any) => alert(error)
    );
  }

  private result(data: Administrator): void {
    this.router.navigate(['/admins']);
  }

  ngOnInit(): void {
  }

}

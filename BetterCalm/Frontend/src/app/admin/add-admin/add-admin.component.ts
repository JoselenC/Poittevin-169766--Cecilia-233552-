import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Administrator} from '../../models/Administrator';
import {AdminService} from '../../services/admin/admin.service';

@Component({
  selector: 'app-add-admin',
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.css']
})
export class AddAdminComponent implements OnInit {
  public admin: Administrator = new Administrator(
    0,
    '',
    '',
    '',
    '',
    '',
  );

  constructor(
    private adminService: AdminService,
    private router: Router
  ) {
  }

  addEditAdministrator(): void {
    if (this.admin.administratorId === 0) {
      this.adminService.add(this.admin).subscribe(
        (data: Administrator) => this.result(data),
      );
    } else {
      this.adminService.update(this.admin).subscribe(
        (data: Administrator) => this.result(data),
      );
    }
  }

  private result(data: Administrator): void {
    this.router.navigate(['/admins']);
  }

  ngOnInit(): void {
    console.log(1);
    if (history.state.admin !== undefined) {
      this.admin = history.state.admin;
      console.log(this.admin);
    }
  }

}

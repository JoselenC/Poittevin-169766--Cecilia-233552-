import {Component, OnInit} from '@angular/core';
import {Administrator} from '../../models/Administrator';
import {Router} from '@angular/router';
import {AdminService} from '../../services/admin/admin.service';

@Component({
  selector: 'app-get-admin',
  templateUrl: './get-admin.component.html',
  styleUrls: ['./get-admin.component.css']
})
export class GetAdminComponent implements OnInit {
  public administrators: Administrator[] = [];

  constructor(
    private adminService: AdminService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.adminService.getAll()
      .subscribe(
        ((data: Array<Administrator>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Administrator>): void {
    this.administrators = data;
  }

  delete(id: number): void {
    this.adminService.delete(id).subscribe(
      (error: any) => alert(error)
    );
    this.administrators = this.administrators.filter(p => p.administratorId !== id);
  }

  navigateTo(administratorId: number): void {
    this.router.navigate(['admins', administratorId]);
  }

  navigateToAddEdit(admin ?: Administrator): void {
    if (admin === undefined) {
      admin = new Administrator(
        0,
        '',
        '',
        '',
        '',
        ''
      );
    }
    this.router.navigate(['add-admin'], {state: {admin}});
  }
}

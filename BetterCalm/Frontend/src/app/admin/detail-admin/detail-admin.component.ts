import { Component, OnInit } from '@angular/core';
import {Administrator} from '../../models/Administrator';
import {ActivatedRoute} from '@angular/router';
import {AdminService} from '../../services/admin/admin.service';

@Component({
  selector: 'app-detail-admin',
  templateUrl: './detail-admin.component.html',
  styleUrls: ['./detail-admin.component.css']
})
export class DetailAdminComponent implements OnInit {
  administrator: Administrator | undefined;

  constructor(
    private route: ActivatedRoute,
    private adminService: AdminService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const administratorId = Number(routeParams.get('adminId'));

    this.adminService.getById(administratorId).subscribe(
      administrator => {
        this.administrator = administrator;
      }
    );
  }

}

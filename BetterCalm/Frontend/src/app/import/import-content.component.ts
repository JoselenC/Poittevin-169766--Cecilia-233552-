import { Component, OnInit } from '@angular/core';
import {ImportService} from '../services/import/import.service';
import {Router} from '@angular/router';
import { Import } from '../models/Import';

@Component({
  selector: 'app-import-content',
  templateUrl: './import-content.component.html',
  styleUrls: ['./import-content.component.css']
})
export class ImportContentComponent implements OnInit {

  constructor(
    private router: Router,
    private importService: ImportService
  ) { }

  id = 0;
  name = '';
  path = '';

  ngOnInit(): void {
  }

  importContent(): void {
    const importer = new Import(
      this.id,
      this.name,
      this.path
    );

    this.importService.importContent(importer).subscribe(
      (data: Import) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
      );
  }

  // tslint:disable-next-line:typedef
      private result(data: Import) {
    this.router.navigate(['/contents']);
  }
}

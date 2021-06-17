import { Component, OnInit } from '@angular/core';
import {ImportService} from '../services/import/import.service';
import {Router} from '@angular/router';
import { Import } from '../models/Import';
import {Category} from '../models/Category';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-import-content',
  templateUrl: './import-content.component.html',
  styleUrls: ['./import-content.component.css']
})
export class ImportContentComponent implements OnInit {
  fileInfo: Import = {} as Import;

  constructor(
    private router: Router,
    private importService: ImportService,
    private formBuilder: FormBuilder
  ) { }

  id = 0;
  name = '';
  path = '';

  importNames: string[] | undefined;
  import = new FormControl();
  importGroup ?: FormGroup;

  onSelectFile(event: any): void{
    const fileName = event.target.files[0] ? event.target.files[0] : '';
    this.fileInfo.path = './Parser/' + fileName.name;
  }


  ngOnInit(): void {
    this.importService.getImportNames()
      .subscribe(
        ((data: Array<string>) => this.getNames(data)),
      );
    this.initImportNames();
  }

  initImportNames(): void {
    this.importGroup = this.formBuilder.group({
      categoriesToString: this.import
    });
  }

  private getNames(data: Array<string>): void {
    this.importNames = data;
  }

  importContent(): void {
    const importer = new Import(
      this.id,
      this.import.value,
      this.fileInfo.path
    );

    this.importService.importContent(importer).subscribe(
      (data: Import) => this.result(data),
      );
  }

  private result(data: Import): void {
    this.router.navigate(['/contents']);
  }

  acceptType(): string {
    return '.' + this.import.value;
  }

}


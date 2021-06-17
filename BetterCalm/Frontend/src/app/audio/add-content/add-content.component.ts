import {Component, Input, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {Router} from '@angular/router';
import {Category} from '../../models/Category';
import {CategoryService} from '../../services/category/category.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-add-content',
  templateUrl: './add-content.component.html',
  styleUrls: ['./add-content.component.css']
})
export class AddContentComponent implements OnInit {
  constructor(
    private serviceContent: ContentService,
    private serviceCategory: CategoryService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  id = 0;
  name = '';
  authorName = '';
  urlContent = '';
  urlImage = '';
  duration = '';
  data = Content;
  categories: Category[]| undefined;
  cat = new FormControl();
  catGroup ?: FormGroup;

  types: Array<string> = [
    'audio',
    'video'
  ];

  typ = new FormControl();
  typGroup ?: FormGroup;

  ngOnInit(): void {
    this.serviceCategory.getCategories().subscribe(
      ((data: Array<Category>) => this.getResult(data)),
    );
    this.initFormCategories();
    this.initFormTypes();
  }

  private getResult(data: Array<Category>): void {
    this.categories = data;
  }

  initFormCategories(): void {
    this.catGroup = this.formBuilder.group({
      categoriesToString: this.cat
    });
  }

  initFormTypes(): void {
    this.typGroup = this.formBuilder.group({
      typesToString: this.typ
    });
  }


  addContent(): void {
    const content = new Content(this.id, this.name, this.authorName, this.urlContent, this.urlImage, this.duration, this.cat.value.map((x: any) => (new Category(0, x))), this.typ.value.toString());
    this.serviceContent.addContent(content).subscribe(
      (data: Content) => this.result(data),
    );
  }

  // tslint:disable-next-line:typedef
  private result(data: Content) {
    this.router.navigate(['/contents']);
  }
}



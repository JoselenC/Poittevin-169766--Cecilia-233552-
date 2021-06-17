import {Component, Input, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {Router} from '@angular/router';
import {Category} from '../../models/Category';
import {CategoryService} from '../../services/category/category.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {Problematic} from '../../models/Problematic';

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

  public content: Content = new Content(
    0,
    '',
    '',
    '',
    '',
    '',
    new Array<Category>(),
    ''
  );

  data = Content;
  categories: Category[]| undefined;
  cat = new FormControl();
  catGroup ?: FormGroup;

  selectedType = '';
  selectedCategories: Array<string> = [];
  types: Array<string> = [
    'audio',
    'video'
  ];

  typ = new FormControl();
  typGroup ?: FormGroup;

  ngOnInit(): void {
    if (history.state.content !== undefined) {
      this.content = history.state.content;
      this.selectedType = this.content.type;
      this.selectedCategories = this.content.categories.map((x: any) => x.name);
    }
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
    this.content.categories = this.selectedCategories.map((x: any) => new Category(0, x));
    this.content.type = this.typ.value;
    this.serviceContent.addContent(this.content).subscribe(
      (data: Content) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
    );
  }

  updateContent(): void {
    this.content.categories = this.selectedCategories.map((x: any) => new Category(0, x));
    this.content.type = this.typ.value;
    this.serviceContent.update(this.content.id , this.content).subscribe(
      (data: Content) => this.result(data),
    );
  }

  private result(data: Content): void {
    this.router.navigate(['/contents']);
  }
}



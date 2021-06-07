import {Component, Input, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {ActivatedRoute, Router} from '@angular/router';
import {Category} from '../../models/Category';
import {CategoryService} from '../../services/category/category.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-update-content',
  templateUrl: './update-content.component.html',
  styleUrls: ['./update-content.component.css']
})
export class UpdateContentComponent implements OnInit {
  content: Content | undefined;

  constructor(
    private route: ActivatedRoute,
    private serviceContent: ContentService,
    private serviceCategory: CategoryService,
    private router: Router,
    private formBuilder: FormBuilder,
  ) {}

  id = 0;
  name: string | undefined;
  authorName: string | undefined ;
  urlContent: string | undefined ;
  urlImage: string | undefined;
  duration: string | undefined;
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
    const routeParams = this.route.snapshot.paramMap;
    const contentId = Number(routeParams.get('contentId'));

    this.serviceContent.getById(contentId).subscribe(
      content => {
        this.content = content;
        console.log(this.content);
      }
    );
    this.name = this.content?.name;
    this.authorName = this.content?.creatorName;
    this.duration = this.content?.duration;
    this.urlImage = this.content?.urlImage;
    this.urlContent = this.content?.urlArchive;

    this.serviceCategory.getCategories().subscribe(
      ((data: Array<Category>) => this.getResult(data)),
      ((error: any) => alert(error.message))
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


  updateContent(): void {
    const routeParams = this.route.snapshot.paramMap;
    const contentId = Number(routeParams.get('contentId'));
    const content = new Content (
      this.id,
      this.name,
      this.authorName,
      this.urlContent,
      this.urlImage,
      this.duration,
      this.cat.value.map((x: any) => (new Category(0, x))),
      this.typ.value.toString()
    );
    this.serviceContent.update(contentId, content).subscribe(
      (data: Content) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
    );
  }

  // tslint:disable-next-line:typedef
  private result(data: Content) {
    this.router.navigate(['/contents']);
  }
}



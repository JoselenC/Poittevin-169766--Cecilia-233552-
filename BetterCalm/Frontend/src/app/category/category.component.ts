import { Component, OnInit } from '@angular/core';
import { Category } from "../models/Category";
import { CategoryService } from "../services/Category/category.service";


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
  providers:[CategoryService],
})

export class CategoryComponent implements OnInit {

  public categories: Category[] = []

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getCategories()
      .subscribe(
        ((data: Array<Category>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }
  private result(data: Array<Category>): void {
    this.categories = data;
  }


}

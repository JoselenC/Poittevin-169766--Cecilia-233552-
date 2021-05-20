import { Component, OnInit } from '@angular/core';
import { Category } from "../models/Category";
import { CategoryService } from "../services/category.service";


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {

  public categories: Category[] = [];

  constructor(private categoryService: CategoryService) { }


  ngOnInit(): void {
    this.categoryService.getCategories()
      .subscribe(
        response => {
          this.categories = response;
        }
      );
  }

}

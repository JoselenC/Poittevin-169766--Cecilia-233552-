import { Component, OnInit } from '@angular/core';
import { Category } from '../models/Category';
import { CategoryService } from '../services/category/category.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
  providers: [CategoryService],
})

export class CategoryComponent implements OnInit {

  public categories: Category[] = [];

  constructor(
    private categoryService: CategoryService,
    private router: Router
  ) { }

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

  navigateTo(categoryId: number): void {
    this.router.navigate(['category', categoryId]);
  }
}

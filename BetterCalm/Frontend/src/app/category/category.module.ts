import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CategoryComponent} from "./category.component";
import {HttpClientModule} from "@angular/common/http";
import {CategoryService} from "../services/category.service";



@NgModule({
  declarations: [CategoryComponent],
  exports: [
    CategoryComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  providers: [CategoryService],
})
export class CategoryModule { }

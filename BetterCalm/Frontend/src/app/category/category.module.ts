import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CategoryComponent} from './category.component';
import {HttpClientModule} from '@angular/common/http';
import {CategoryService} from '../services/category/category.service';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatOptionModule} from '@angular/material/core';
import {MaterialComponentsModule} from '../material.module';



@NgModule({
  declarations: [CategoryComponent],
  exports: [
    CategoryComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MatFormFieldModule,
    MatOptionModule,
    MaterialComponentsModule,
  ],
  providers: [CategoryService],
})
export class CategoryModule { }

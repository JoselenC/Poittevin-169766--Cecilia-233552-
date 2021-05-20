import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CategoryService } from "./services/category.service";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CategoryModule} from "./category/category.module";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CategoryModule,
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }

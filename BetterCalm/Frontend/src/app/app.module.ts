import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CategoryService } from "./services/Category/category.service";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CategoryModule} from "./category/category.module";
import {HttpClientModule} from "@angular/common/http";
import {AddSongModule} from "./SongComponents/AddSong/add-song/add-song.module";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CategoryModule,
    HttpClientModule,
    AddSongModule,
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }

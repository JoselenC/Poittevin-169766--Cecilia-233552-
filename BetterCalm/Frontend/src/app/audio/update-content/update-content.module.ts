import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {UpdateContentComponent} from './update-content.component';
import {MaterialComponentsModule} from '../../material.module';
import {ContentService} from '../../services/content/content.service';
import {AddAudioModule} from '../add-content/add-content.module';
import {CategoryModule} from '../../category/category.module';
import {FormsModule} from '@angular/forms';



@NgModule({
  declarations: [
    UpdateContentComponent
  ],
  exports: [
    UpdateContentComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule,
    AddAudioModule,
    CategoryModule,
    FormsModule
  ],
  providers: [ContentService],
})
export class UpdateContentModule { }

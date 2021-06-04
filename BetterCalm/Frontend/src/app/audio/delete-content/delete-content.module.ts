import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MaterialComponentsModule} from '../../material.module';
import {HttpClientModule} from '@angular/common/http';
import {ContentService} from '../../services/content/content.service';
import {DeleteContentComponent} from './delete-content.component';



@NgModule({
  declarations: [DeleteContentComponent],
  exports: [
    DeleteContentComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialComponentsModule
  ],
  providers: [ContentService],
})
export class DeleteContentModule { }

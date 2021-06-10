import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {LayoutComponent} from './layout.component';
import {RouterModule} from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatTreeModule} from '@angular/material/tree';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatOptionModule} from '@angular/material/core';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatTableModule} from '@angular/material/table';
import {FlexModule} from '@angular/flex-layout';

@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    BrowserAnimationsModule,
    RouterModule,
    CommonModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatIconModule,
    MatTreeModule,
    MatFormFieldModule,
    MatOptionModule,
    MatExpansionModule,
    MatTableModule,
    FlexModule,
  ],
  exports: [
    LayoutComponent
  ]
})
export class LayoutModule { }

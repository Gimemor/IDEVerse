import { GridsterModule } from "angular-gridster2";
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { MaterialModule } from "src/app/material.module";
import { DashboardComponent } from "./dashboard.component";
import {CKEditorModule} from "@ckeditor/ckeditor5-angular";



@NgModule({
  declarations: [DashboardComponent],
  exports: [DashboardComponent],
  imports: [
    CommonModule,
    BrowserModule,
    MaterialModule,
    FormsModule,
  ]
})
export class DashboardModule { }

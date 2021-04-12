import { MaterialModule } from "src/app/material.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HasRightDirective } from "./directives/has-right.directive";

@NgModule({
  declarations: [HasRightDirective],
  imports: [CommonModule, MaterialModule],
  exports: [HasRightDirective],
})
export class SharedModule {}

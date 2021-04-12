import { MaterialModule } from "src/app/material.module";
import { NgModule } from "@angular/core";
import { TeacherControlPanelComponent } from "./teacher-control-panel.component";
import { TeacherControlPanelRoutingModule } from "./teacher-control-panel-routing.module";

@NgModule({
  declarations: [TeacherControlPanelComponent],
  exports: [TeacherControlPanelComponent],
  imports: [MaterialModule, TeacherControlPanelRoutingModule],
})
export class TeacherControlPanelModule {}

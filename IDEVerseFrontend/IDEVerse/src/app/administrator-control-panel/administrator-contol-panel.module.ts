import { UserRightPanelComponent } from "./components/user-right-panel/user-right-panel.component";
import { SchedulePanelComponent } from "./components/schedule-panel/schedule-panel.component";
import { TasksPanelComponent } from "./components/tasks-panel/tasks-panel.component";
import { SubjectPanelComponent } from "./components/subject-panel/subject-panel.component";
import { UserPanelComponent } from "./components/user-panel/user-panel.component";
import { AdministratorControlPanelRoutingModule } from "./administrator-control-panel-routing.module";
import { UserRolePanelComponent } from "./components/user-role-panel/user-role-panel.component";
import { MaterialModule } from "src/app/material.module";
import { AdministratorControlPanelComponent } from "./administrator-control-panel.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Router, RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AdministratorControlPanelComponent,
    UserRolePanelComponent,
    UserPanelComponent,
    SubjectPanelComponent,
    TasksPanelComponent,
    SchedulePanelComponent,
    UserRightPanelComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    MaterialModule,
    FormsModule,
    AdministratorControlPanelRoutingModule,
  ],
})
export class AdministratorControlPanelModule {}

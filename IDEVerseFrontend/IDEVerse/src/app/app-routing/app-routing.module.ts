import { AuthGuard } from "./../../../_helpers/auth.guard";
import { AdministratorControlPanelRoutingModule } from "../administrator-control-panel/administrator-control-panel-routing.module";
import { AdministratorControlPanelComponent } from "../administrator-control-panel/administrator-control-panel.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Router, CanActivate } from "@angular/router";
import { HomeComponent } from "src/app/components/home/home.component";
import { DashboardComponent } from "src/app/components/dashboard/dashboard.component";
import { TasksComponent } from "src/app/components/tasks/tasks.component";
import { ScheduleComponent } from "src/app/components/schedule/schedule.component";
import { LoginComponent } from "../components/login/login.component";
import {VerseEditorComponent} from "../components/verse-editor/verse-editor.component";

const routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "verse-editor",
  },
  {
    path: "dashboard",
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "verse-editor",
    component: VerseEditorComponent,
    canActivate: [AuthGuard]
  },
  { path: "tasks", component: TasksComponent, canActivate: [AuthGuard] },
  { path: "schedule", component: ScheduleComponent, canActivate: [AuthGuard] },

  // AuthGuardless
  { path: "login", component: LoginComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    AdministratorControlPanelRoutingModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }

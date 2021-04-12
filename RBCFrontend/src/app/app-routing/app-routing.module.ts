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

const routes = [
  {
    path: "",
    component: HomeComponent,
    match: "full",
    canActivate: [AuthGuard],
  },
  {
    path: "dashboard",
    component: DashboardComponent,
    canActivate: [AuthGuard],
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

import { SchedulePanelComponent } from "./components/schedule-panel/schedule-panel.component";
import { TasksPanelComponent } from "./components/tasks-panel/tasks-panel.component";
import { SubjectPanelComponent } from "./components/subject-panel/subject-panel.component";
import { UserRolePanelComponent } from "./components/user-role-panel/user-role-panel.component";
import { AdministratorControlPanelComponent } from "./administrator-control-panel.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { UserPanelComponent } from "./components/user-panel/user-panel.component";
import { UserRightPanelComponent } from "./components/user-right-panel/user-right-panel.component";
import { AuthGuard } from "_helpers/auth.guard";

const acpRoutes: Routes = [
  {
    path: "control-panel",
    component: AdministratorControlPanelComponent,
    children: [
      { path: "", component: UserRolePanelComponent, canActivate: [AuthGuard] },
      {
        path: "users",
        component: UserPanelComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "subjects",
        component: SubjectPanelComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "tasks",
        component: TasksPanelComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "schedule",
        component: SchedulePanelComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "rights",
        component: UserRightPanelComponent,
        canActivate: [AuthGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(acpRoutes)],
  exports: [RouterModule],
})
export class AdministratorControlPanelRoutingModule {}

import { Routes, Route, RouterModule } from "@angular/router";
import { TeacherControlPanelComponent } from "./teacher-control-panel.component";
import { NgModule } from "@angular/core";

const tcpRoutes: Routes = [
  {
    path: "teacher-panel",
    component: TeacherControlPanelComponent,
    children: [],
  } as Route,
];

@NgModule({
  imports: [RouterModule.forChild(tcpRoutes)],
  exports: [RouterModule],
})
export class TeacherControlPanelRoutingModule {}

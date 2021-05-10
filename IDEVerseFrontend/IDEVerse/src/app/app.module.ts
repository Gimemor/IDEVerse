import { HomeModule } from "./components/home/home.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppComponent } from "./app.component";
import { TasksModule } from "./components/tasks/tasks.module";
import { ScheduleModule } from "./components/schedule/schedule.module";
import { ToastrModule } from "ngx-toastr";
import { NavMenuModule } from "./components/nav-menu/nav-menu.module";
import { SharedModule } from "./components/shared/shared.module";
import { AdministratorControlPanelModule } from "./administrator-control-panel/administrator-contol-panel.module";
import { MaterialModule } from "./material.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing/app-routing.module";
import { ErrorInterceptor, JwtInterceptor } from "_helpers/helpers";
import { LoginComponent } from "./components/login/login.component";
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { TeacherControlPanelModule } from "./teacher-control-panel/teacher-control-panel.module";
import {VerseEditorModule} from "./components/verse-editor/verse-editor.module";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    NavMenuModule,
    SharedModule,
    TasksModule,
    ScheduleModule,
    HomeModule,
    CommonModule,
    AdministratorControlPanelModule,
    TeacherControlPanelModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ToastrModule,
    VerseEditorModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    // fakeBackendProvider
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }

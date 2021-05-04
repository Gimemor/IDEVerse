import { SubjectService } from "src/app/services/subject.service";
import { AuthenticationService } from "src/app/services/authentication.service";
import { Component } from "@angular/core";
import { Subject } from "src/app/entities/subject";
import { Observable } from "rxjs";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  public userName = "";
  public subjects: Observable<Subject[]>;
  constructor(
    public authService: AuthenticationService,
    public subjectService: SubjectService
  ) {
    this.userName = authService.currentUserValue.firstName;
    this.subjects = subjectService.getSubjects();
  }
}

import { Observable } from "rxjs";
import { Component, OnInit } from "@angular/core";
import { Subject } from "src/app/entities/subject";
import { AdminSubjectService } from "../../services/admin-subject.service";

@Component({
  selector: "app-subject-panel",
  templateUrl: "./subject-panel.component.html",
})
export class SubjectPanelComponent implements OnInit {
  isEditPanelVisible = false;
  editSubject: Subject = {} as Subject;
  public subjects: Observable<Subject[]>;
  constructor(private subjectService: AdminSubjectService) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.subjects = this.subjectService.getSubjects();
  }

  handleAddClick() {
    this.editSubject = {} as Subject;
    this.isEditPanelVisible = true;
  }

  handleEditClick(subject: Subject) {
    this.editSubject = subject;
    this.isEditPanelVisible = true;
  }

  handleCancelClick(subject: Subject) {
    this.editSubject = {} as Subject;
    this.isEditPanelVisible = false;
  }

  handleSaveClick() {
    this.subjectService.saveSubject(this.editSubject).subscribe((d) => {
      this.editSubject = {} as Subject;
      this.isEditPanelVisible = false;
      this.load();
    });
  }
}

import { TasksService } from "../../../services/tasks.service";
import { Task } from "src/app/entities/task";
import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { SubjectService } from "src/app/services/subject.service";
import { Subject } from "src/app/entities/subject";
import { AdminTasksService } from "../../services/admin-tasks.service";
import { AdminSubjectService } from "../../services/admin-subject.service";

@Component({
  selector: "app-tasks-panel",
  templateUrl: "./tasks-panel.component.html",
})
export class TasksPanelComponent implements OnInit {
  isEditPanelVisible = false;
  editTask: Task = {} as Task;
  public tasks: Observable<Task[]>;
  public subjects: Observable<Subject[]>;
  constructor(
    private taskService: AdminTasksService,
    private subjectService: AdminSubjectService
  ) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.tasks = this.taskService.getTasks();
    this.subjects = this.subjectService.getSubjects();
  }

  handleAddClick() {
    this.editTask = {} as Task;
    this.isEditPanelVisible = true;
  }

  handleEditClick(task: Task) {
    this.editTask = task;
    this.isEditPanelVisible = true;
  }

  handleCancelClick(subject: Task) {
    this.editTask = {} as Task;
    this.isEditPanelVisible = false;
  }

  handleSaveClick() {
    this.taskService.saveTask(this.editTask).subscribe((d) => {
      this.editTask = {} as Task;
      this.isEditPanelVisible = false;
      this.load();
    });
  }

  compareSubjects(s1: Subject, s2: Subject) {
    return !!s1 && !!s2 && s1.id === s2.id;
  }
}

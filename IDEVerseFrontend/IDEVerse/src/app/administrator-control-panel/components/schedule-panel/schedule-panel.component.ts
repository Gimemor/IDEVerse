import { Schedule } from "src/app/entities/schedule";
import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Subject } from "src/app/entities/subject";
import { SubjectService } from "src/app/services/subject.service";
import { User } from "src/app/entities/user";
import { UsersService } from "src/app/services/users.service";
import { AdminScheduleService } from "../../services/admin-schedule.service";
import { AdminSubjectService } from "../../services/admin-subject.service";

@Component({
  selector: "app-schedule-panel",
  templateUrl: "./schedule-panel.component.html",
})
export class SchedulePanelComponent implements OnInit {
  isEditPanelVisible = false;
  editSchedule: Schedule = {} as Schedule;
  public subjects: Observable<Subject[]>;
  public schedule: Observable<Schedule[]>;
  public users: Observable<User[]>;
  constructor(
    private scheduleService: AdminScheduleService,
    private userService: UsersService,
    private subjectService: AdminSubjectService
  ) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.subjects = this.subjectService.getSubjects();
    this.schedule = this.scheduleService.getSchedule();
    this.users = this.userService.getAll();
  }

  handleAddClick() {
    this.editSchedule = {} as Schedule;
    this.isEditPanelVisible = true;
  }

  handleEditClick(schedule: Schedule) {
    this.editSchedule = schedule;
    this.isEditPanelVisible = true;
  }

  handleCancelClick() {
    this.editSchedule = {} as Schedule;
    this.isEditPanelVisible = false;
  }

  handleSaveClick() {
    this.scheduleService.saveSchedule(this.editSchedule).subscribe((d) => {
      this.editSchedule = {} as Schedule;
      this.isEditPanelVisible = false;
      this.load();
    });
  }
  compareEntities(s1: any, s2: any) {
    return !!s1 && !!s2 && s1.id === s2.id;
  }
}

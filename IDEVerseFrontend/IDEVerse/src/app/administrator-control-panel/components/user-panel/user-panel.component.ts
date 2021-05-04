import { User } from "../../../entities/user";
import { UserRole } from "src/app/entities/user-role";
import { Observable } from "rxjs";
import { Component, OnInit } from "@angular/core";
import { Subject } from "src/app/entities/subject";
import { AdminUsersService } from "../../services/admin-users.service";
import { AdminUserRoleService } from "../../services/admin-user-roles.service";
import { AdminSubjectService } from "../../services/admin-subject.service";

@Component({
  selector: "app-user-panel",
  templateUrl: "./user-panel.component.html",
})
export class UserPanelComponent implements OnInit {
  roles: Observable<UserRole[]>;
  subjects: Observable<Subject[]>;
  users: Observable<User[]>;
  editUser: User = {} as User;
  isEditPanelVisible = false;

  constructor(
    private userRoleService: AdminUserRoleService,
    private userService: AdminUsersService,
    private subjectService: AdminSubjectService
  ) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.roles = this.userRoleService.getRoles();
    this.subjects = this.subjectService.getSubjects();
    this.users = this.userService.getAll();
  }

  handleAddClick() {
    this.editUser = {} as User;
    this.isEditPanelVisible = true;
  }
  handleEditClick(user: User) {
    this.editUser = user;
    this.isEditPanelVisible = true;
  }
  handleCancelClick() {
    this.editUser = {} as User;
    this.isEditPanelVisible = false;
  }
  handleSaveClick() {
    this.userService.saveUser(this.editUser).subscribe((u) => {
      this.load();
    });
    this.isEditPanelVisible = false;
  }

  compareSubjects(s1: Subject, s2: Subject) {
    return s1.id === s2.id;
  }
}

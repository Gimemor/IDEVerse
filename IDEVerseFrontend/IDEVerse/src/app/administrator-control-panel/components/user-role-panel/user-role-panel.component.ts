import { UserRightsService } from "../../../services/user-rights.service";
import { UserRight } from "../../../entities/user-right";
import { UserRoleService } from "../../../services/user-roles.service";
import { Component, OnInit, OnDestroy } from "@angular/core";
import { UserRole } from "src/app/entities/user-role";
import { Subject, Observable } from "rxjs";
import { AdminUserRightsService } from "../../services/admin-user-rights.service";
import { AdminUserRoleService } from "../../services/admin-user-roles.service";

@Component({
  selector: "app-user-role-panel",
  templateUrl: "./user-role-panel.component.html",
})
export class UserRolePanelComponent implements OnInit, OnDestroy {
  public roles: Observable<UserRole[]>;
  public rights: Observable<UserRight[]>;
  public isEditPanelVisible = false;
  public editingRole: UserRole = {} as UserRole;

  constructor(
    private userRoleService: AdminUserRoleService,
    private userRightsService: AdminUserRightsService
  ) {}

  async ngOnInit() {
    this.roles = this.userRoleService.getRoles();
    this.rights = this.userRightsService.getRights();
  }

  handleAddClick(): void {
    this.editingRole = new UserRole();
    this.isEditPanelVisible = true;
  }

  handleSaveClick(): void {
    this.userRoleService.saveRole(this.editingRole).subscribe(() => {
      this.roles = this.userRoleService.getRoles();
    });
    this.isEditPanelVisible = false;
  }

  handleEditClick(userRoleId: string) {
    this.userRoleService
      .getRole(userRoleId)
      .subscribe((x) => (this.editingRole = x));
    this.isEditPanelVisible = true;
  }

  handleCancelClick() {
    this.editingRole = undefined;
    this.isEditPanelVisible = false;
  }

  ngOnDestroy(): void {}

  compareEntities(s1: any, s2: any) {
    return !!s1 && !!s2 && s1.id === s2.id;
  }
}

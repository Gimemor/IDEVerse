import { Component, OnInit, OnDestroy } from "@angular/core";
import { Observable } from "rxjs";
import { UserRight } from "src/app/entities/user-right";
import { AdminUserRightsService } from "../../services/admin-user-rights.service";

@Component({
  selector: "app-user-right-panel",
  templateUrl: "./user-right-panel.component.html",
})
export class UserRightPanelComponent implements OnInit, OnDestroy {
  public rights: Observable<UserRight[]>;
  public isEditPanelVisible = false;
  public editingRight: UserRight = {} as UserRight;

  constructor(private userRightService: AdminUserRightsService) { }

  async ngOnInit() {
    this.rights = this.userRightService.getRights();
  }

  handleAddClick(): void {
    this.editingRight = new UserRight();
    this.isEditPanelVisible = true;
  }

  handleSaveClick(): void {
    this.userRightService.saveRight(this.editingRight).subscribe(() => {
      this.rights = this.userRightService.getRights();
    });
    this.isEditPanelVisible = false;
  }

  handleEditClick(userRoleId: string) {
    this.userRightService
      .getRight(userRoleId)
      .subscribe((x) => (this.editingRight = x));
    this.isEditPanelVisible = true;
  }

  handleCancelClick() {
    this.editingRight = undefined;
    this.isEditPanelVisible = false;
  }

  ngOnDestroy(): void { }
}

import { Component, OnInit } from "@angular/core";
import { DisplayGrid, GridsterConfig, GridsterItem, GridType } from "angular-gridster2";
import { ToastrService } from "ngx-toastr";
import { EMPTY, Observable } from "rxjs";
import { catchError } from "rxjs/operators";
import { Subject } from "src/app/entities/subject";
import { Task } from "src/app/entities/task";
import { AuthenticationService } from "src/app/services/authentication.service";
import { SubjectService } from "src/app/services/subject.service";
import { TasksService } from "src/app/services/tasks.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
})
export class DashboardComponent implements OnInit {

  constructor(public subjectService: SubjectService,
    public toastr: ToastrService,
    public authService: AuthenticationService,
  ) {
    this.dashboard = [];
    this.subjectService.getSubjects().pipe(catchError(x => {
      this.toastr.error(x.message);
      return EMPTY;
    })).subscribe(
      result => {
        result.forEach(x => this.addItem(x));
        console.log(this.dashboard);
      });
    this.userName = authService.currentUserValue.firstName;
  }

  isEditPanelVisible = false;
  public subjects: Observable<Subject[]>;
  options: GridsterConfig = {
    gridType: GridType.Fixed,
    displayGrid: DisplayGrid.None,
    defaultItemCols: 20,
    defaultItemRows: 20,
    pushItems: true,
    draggable: {
      enabled: true
    },
    resizable: {
      enabled: true
    }
  };
  dashboard: Array<GridsterItem>;
  public userName = "";

  static itemChange(item, itemComponent) {
    console.info("itemChanged", item, itemComponent);
  }

  static itemResize(item, itemComponent) {
    console.info("itemResized", item, itemComponent);
  }
  ngOnInit() {
  }

  changedOptions() {
    this.options.api.optionsChanged();
  }

  handleItemChanged() { }
  handleItemResized() { }
  removeItem(item) {
    this.dashboard.splice(this.dashboard.indexOf(item), 1);
  }

  addItem(item) {
    this.dashboard.push(Object.assign({ x: 0, y: 0, cols: 1, rows: 1 }, item));
  }

  handleAddClick() {
    this.isEditPanelVisible = true;
  }

  handleEditClick(subject: Subject) {
    this.isEditPanelVisible = true;
  }

  handleCancelClick(subject: Subject) {
    this.isEditPanelVisible = false;
  }

  handleSaveClick() {
  }

}

import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { TasksService } from './../../services/tasks.service';
import { Component, OnInit } from '@angular/core';
import { Task } from '../../entities/task';
import { EMPTY } from 'rxjs';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  public tasks: Task[] = [];
  constructor(public taskService: TasksService, public toastr: ToastrService) { }

  ngOnInit(): void {
    this.taskService.getTasks().pipe(catchError(x => {
          this.toastr.error(x.message);
          return EMPTY;
    })).subscribe(
      result => this.tasks = result
    );
  }
}

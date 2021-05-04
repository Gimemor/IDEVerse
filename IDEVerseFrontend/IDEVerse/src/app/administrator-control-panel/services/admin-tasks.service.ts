import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Task } from "src/app/entities/task";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminTasksService extends BaseService<Task> {
  public getTasks(): Observable<Task[]> {
    return this.getMany(environment.baseApiUrl + "/admin/Tasks/");
  }

  public saveTask(task: Task): Observable<Task> {
    return this.post(environment.baseApiUrl + "/admin/Tasks", task);
  }
  constructor(http: HttpClient) {
    super(http);
  }
}

import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Task } from "src/app/entities/task";
import { BaseService } from "./base.service";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class TasksService extends BaseService<Task> {
  public getTasks(): Observable<Task[]> {
    return this.getMany(environment.baseApiUrl + "/Tasks/");
  }

  public saveTask(task: Task): Observable<Task> {
    return this.post(environment.baseApiUrl + "/Tasks", task);
  }
  constructor(http: HttpClient) {
    super(http);
  }
}

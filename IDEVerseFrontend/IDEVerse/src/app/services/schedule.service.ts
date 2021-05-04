import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Schedule } from "src/app/entities/schedule";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class ScheduleService extends BaseService<Schedule> {
  public getSchedule(): Observable<Schedule[]> {
    return this.getMany(environment.baseApiUrl + "/Schedule/");
  }

  public saveSchedule(schedule: Schedule): Observable<Schedule> {
    return this.post(environment.baseApiUrl + "/Schedule", schedule);
  }
  constructor(http: HttpClient) {
    super(http);
  }
}

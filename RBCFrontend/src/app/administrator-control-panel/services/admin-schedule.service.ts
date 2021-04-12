import { Injectable } from "@angular/core";
import { Schedule } from "src/app/entities/schedule";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminScheduleService extends BaseService<Schedule> {
  public getSchedule(): Observable<Schedule[]> {
    return this.getMany(environment.baseApiUrl + "/admin/Schedule/");
  }
  public saveSchedule(schedule: Schedule): Observable<Schedule> {
    return this.post(environment.baseApiUrl + "/admin/Schedule", schedule);
  }
  constructor(http: HttpClient) {
    super(http);
  }
}

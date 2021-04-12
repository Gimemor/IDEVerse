import { Injectable } from "@angular/core";
import { Subject } from "src/app/entities/subject";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminSubjectService extends BaseService<Subject> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getSubjects(): Observable<Subject[]> {
    return this.getMany(environment.baseApiUrl + "/admin/Subjects/");
  }

  public saveSubject(subject: Subject): Observable<Subject> {
    return this.post(environment.baseApiUrl + "/admin/Subjects", subject);
  }
}

import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Subject } from "src/app/entities/subject";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class SubjectService extends BaseService<Subject> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getSubjects(): Observable<Subject[]> {
    return this.getMany(environment.baseApiUrl + "/Subjects/");
  }

  public saveSubject(subject: Subject): Observable<Subject> {
    return this.post(environment.baseApiUrl + "/Subjects", subject);
  }
}

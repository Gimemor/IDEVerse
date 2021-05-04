import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserRight } from "src/app/entities/user-right";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminUserRightsService extends BaseService<UserRight> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getRights(): Observable<UserRight[]> {
    return this.getMany(environment.baseApiUrl + "/admin/UserRights/");
  }

  public getRight(id: string): Observable<UserRight> {
    return this.getOne(environment.baseApiUrl + "/admin/UserRights/" + id);
  }

  public saveRight(right: UserRight): Observable<UserRight> {
    return this.post(environment.baseApiUrl + "/admin/UserRights", right);
  }
}

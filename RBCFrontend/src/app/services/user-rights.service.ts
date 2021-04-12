import { BaseService } from "./base.service";
import { BaseApiRouter } from "../app-routing/base-api-router";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserRight } from "src/app/entities/user-right";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

export class UserRightsApiRoutes extends BaseApiRouter {
  static getList() {
    return BaseApiRouter.BaseUrl + "/api/UserRights/";
  }
}

@Injectable({
  providedIn: "root",
})
export class UserRightsService extends BaseService<UserRight> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getRights(): Observable<UserRight[]> {
    return this.getMany(environment.baseApiUrl + "/UserRights/");
  }

  public getRight(id: string): Observable<UserRight> {
    return this.getOne(environment.baseApiUrl + "/UserRights/" + id);
  }

  public saveRight(right: UserRight): Observable<UserRight> {
    return this.post(environment.baseApiUrl + "/UserRights", right);
  }
}

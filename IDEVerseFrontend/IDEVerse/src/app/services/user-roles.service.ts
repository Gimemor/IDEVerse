import { UserRolePanelComponent } from "../administrator-control-panel/components/user-role-panel/user-role-panel.component";
import { BaseService } from "./base.service";
import { BaseApiRouter } from "../app-routing/base-api-router";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserRole } from "src/app/entities/user-role";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

export class UserRoleApiRoutes extends BaseApiRouter {
  static getList() {
    return BaseApiRouter.BaseUrl + "/api/UserRoles/";
  }
}

@Injectable({
  providedIn: "root",
})
export class UserRoleService extends BaseService<UserRole> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getRoles(): Observable<UserRole[]> {
    return this.getMany(environment.baseApiUrl + "/UserRoles/");
  }

  public getRole(id: string): Observable<UserRole> {
    return this.getOne(environment.baseApiUrl + "/UserRoles/" + id);
  }

  public saveRole(role: UserRole): Observable<UserRole> {
    return this.post(environment.baseApiUrl + "/UserRoles", role);
  }
}

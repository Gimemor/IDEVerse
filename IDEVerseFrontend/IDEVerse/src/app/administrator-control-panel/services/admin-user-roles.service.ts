import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserRole } from "src/app/entities/user-role";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminUserRoleService extends BaseService<UserRole> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getRoles(): Observable<UserRole[]> {
    return this.getMany(environment.baseApiUrl + "/admin/UserRoles/");
  }

  public getRole(id: string): Observable<UserRole> {
    return this.getOne(environment.baseApiUrl + "/admin/UserRoles/" + id);
  }

  public saveRole(role: UserRole): Observable<UserRole> {
    return this.post(environment.baseApiUrl + "/admin/UserRoles", role);
  }
}

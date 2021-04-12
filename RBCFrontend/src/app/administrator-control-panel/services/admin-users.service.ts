import { Injectable } from "@angular/core";
import { User } from "src/app/entities/user";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { BaseService } from "src/app/services/base.service";

@Injectable({
  providedIn: "root",
})
export class AdminUsersService extends BaseService<User> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getAll(): Observable<User[]> {
    return this.getMany(environment.baseApiUrl + "/admin/users");
  }

  public getOne(id: string): Observable<User> {
    return this.getOne(environment.baseApiUrl + `/admin/users/${id}`);
  }

  public saveUser(user: User): Observable<User> {
    return this.post(environment.baseApiUrl + "/admin/users", user);
  }
}

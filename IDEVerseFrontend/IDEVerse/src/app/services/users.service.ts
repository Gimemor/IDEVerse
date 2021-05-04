import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { User } from 'src/app/entities/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends BaseService<User> {

  constructor(http: HttpClient) {
    super(http);
   }

   public getAll(): Observable<User[]> {
     return this.getMany(environment.baseApiUrl + '/users');
   }

   public getOne(id: string): Observable<User> {
     return this.getOne(environment.baseApiUrl + `/users/${id}`);
   }

   public saveUser(user: User): Observable<User> {
     return this.post(environment.baseApiUrl + '/users', user);
   }
}

import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Entity } from "src/app/entities/entity";

@Injectable({
  providedIn: "root",
})
export class BaseService<T extends Entity> {
  constructor(private http: HttpClient) {}

  protected getOne(url: string): Observable<T> {
    return this.http.get<T>(url);
  }

  protected getMany(url: string): Observable<T[]> {
    return this.http.get<T[]>(url);
  }

  protected post(url: string, payload: T): Observable<T> {
    const headers = new HttpHeaders().set(
      "Content-Type",
      "application/json; charset=utf-8"
    );
    return this.http.post<T>(url, JSON.stringify(payload), {
      headers: headers,
    });
  }
}

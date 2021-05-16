import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable, Subject} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({ providedIn: "root" })
export class VerseTheftService {

  constructor(public httpClient: HttpClient) {
  }

  public getRhymes(original: string): Observable<string[]> {
      return this.httpClient.get<string[]>(environment.baseApiUrl + "/versetheft/" + encodeURIComponent(original));
  }
}


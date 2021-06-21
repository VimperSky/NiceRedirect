import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {Redirect, RedirectData} from "../models/redirectData";
import {environment} from "../../environments/environment";
import {RedirectWithPassword} from "../models/redirect-with-password";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Origin': "*"
  })
};

@Injectable({
  providedIn: 'root'
})
export class RedirectService {
  constructor(private http: HttpClient) {
  }

  generateRedirect(data: RedirectData): Observable<Redirect> {
    return this.http.post<Redirect>(environment.apiUrl + "/RedirectManager/Create", data, httpOptions)
  }

  getAllRedirects(): Observable<Redirect[]> {
    return this.http.get<Redirect[]>(environment.apiUrl + "/RedirectManager/List", httpOptions)
  }

  deleteRedirect(key: string): Observable<Object> {
    const options = {...httpOptions, params: new HttpParams().set('key', key)};
    return this.http.delete(environment.apiUrl + "/RedirectManager/Delete", options);
  }

  verifyRedirect(redirect: RedirectWithPassword): Observable<string> {
    return this.http.post<string>(environment.apiUrl + "/RedirectForm/ProcessPasswordForm", redirect, httpOptions)
  }
}

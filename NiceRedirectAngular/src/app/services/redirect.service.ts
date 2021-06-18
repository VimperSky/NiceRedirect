import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpParams} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Redirect} from "../models/redirect";
import {environment} from "../../environments/environment";
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RedirectService {
  constructor(private http: HttpClient) { }


  generateRedirect(target: string): Observable<Redirect> {
    return this.http.post<Redirect>(environment.apiUrl + "/RedirectManager/Create", JSON.stringify(target))
  }

  getAllRedirects(): Observable<Redirect[]> {
    return this.http.get<Redirect[]>(environment.apiUrl + "/RedirectManager/List")
  }

  deleteRedirect(key: string): Observable<Object> {
    const options =  { params: new HttpParams().set('key', key) };
    return this.http.delete(environment.apiUrl + "/RedirectManager/Delete", options);
  }
}


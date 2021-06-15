import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Redirect} from "../models/redirect";
import {environment} from "../../environments/environment";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',

  })
};

@Injectable({
  providedIn: 'root'
})
export class RedirectService {
  constructor(private http: HttpClient) { }

  generateRedirect(target: string): Observable<Redirect> {
    return this.http.post<Redirect>(environment.apiUrl + "/Redirect", JSON.stringify(target), httpOptions);
  }
}


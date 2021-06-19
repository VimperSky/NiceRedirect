import {Component, OnInit} from '@angular/core';
import {Redirect, RedirectData, RedirectType} from "../models/redirectData";
import {MatDialog} from '@angular/material/dialog';
import {CreateComponent} from "./create/create-components.component";
import {RedirectService} from "../services/redirect.service";
import {environment} from "../../environments/environment";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-redirect-creator',
  templateUrl: './redirect-manager.component.html',
  styleUrls: ['./redirect-manager.component.sass']
})


export class RedirectManagerComponent implements OnInit {

  redirects: Redirect[] = [];

  basePath: string = window.location.origin;
  getPath (short: string): string {
    return this.basePath + "/" + short;
  }

  constructor(public dialog: MatDialog, private redirectService: RedirectService) {}

  ngOnInit(): void {
    this.redirectService.getAllRedirects().subscribe((redirects: Redirect[]) => this.redirects = redirects);
  }

  copy(redirect: Redirect): string {
    return environment.apiUrl + "/" + redirect.key;
  }

  delete(redirect: Redirect) {
    if (this.redirects.includes(redirect)) {
      this.redirectService.deleteRedirect(redirect.key).subscribe(
        () =>
          this.redirects = this.redirects.filter(x => x != redirect),
        (error: HttpErrorResponse) =>
          console.log('Error happened while processing delete redirect' + error))
    }
  }

  create() {
    const dialogRef = this.dialog.open(CreateComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (!result) return;

      let value = result.value as string;
      let password = result.password as string;
      const passwordNotEmpty = /\S/.test(password);
      const data: RedirectData = {target: value, type: passwordNotEmpty ? RedirectType.WithPassword :
          RedirectType.Standard, password: passwordNotEmpty ? password : null }
      this.redirectService.generateRedirect(data).subscribe((redirect: Redirect) => {
        this.redirects.push(redirect);
      })
    });
  }
}

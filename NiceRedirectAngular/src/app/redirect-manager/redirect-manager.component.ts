import { Component, OnInit, Inject } from '@angular/core';
import {Redirect} from "../models/redirect";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
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

      let value = result as string;
      this.redirectService.generateRedirect(value).subscribe((redirect: Redirect) => {
        this.redirects.push(redirect);
      })
    });
  }
}

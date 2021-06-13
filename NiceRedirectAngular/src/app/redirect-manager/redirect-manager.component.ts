import { Component, OnInit, Inject } from '@angular/core';
import {Redirect} from "../models/redirect";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {CreateComponent} from "./create/create.component";

@Component({
  selector: 'app-redirect-creator',
  templateUrl: './redirect-manager.component.html',
  styleUrls: ['./redirect-manager.component.sass']
})


export class RedirectManagerComponent implements OnInit {

  redirects: Redirect[] = [
    {short: "abcdef12", target: "https://yandex.ru/", useCount: 0},
    {short: "ff32f324", target: "https://github.com/", useCount: 2},
    {short: "aaaaaaaa", target: "https://www.youtube.com/", useCount: 3}
  ]

  basePath: string = window.location.origin;
  getPath (short: string): string {
    return this.basePath + "/" + short;
  }

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
  }

  info(redirect: Redirect) {
    alert(redirect.target)
  }

  delete(redirect: Redirect) {
    if (this.redirects.includes(redirect)) {
      this.redirects = this.redirects.filter(x => x != redirect)
    }
  }

  create() {
    const dialogRef = this.dialog.open(CreateComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (!result) return;

      let value = result as string;
      this.redirects.push({short: "abcdef2", target: value, useCount: 0})
    });
  }
}

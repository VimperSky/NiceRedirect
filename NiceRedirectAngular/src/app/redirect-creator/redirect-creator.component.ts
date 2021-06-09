import { Component, OnInit } from '@angular/core';
import {Redirect} from "../models/redirect";

@Component({
  selector: 'app-redirect-creator',
  templateUrl: './redirect-creator.component.html',
  styleUrls: ['./redirect-creator.component.sass']
})


export class RedirectCreatorComponent implements OnInit {

  redirects: Redirect[] = [
    {short: "abcdef12", target: "google.com"},
    {short: "ff32f324", target: "yandex.ru"},
    {short: "aaaaaaaa", target: "gmail.com"}
  ]

  basePath: string = window.location.origin;
  getPath (short: string): string {
    return this.basePath + "/" + short;
  }

  constructor() { }

  ngOnInit(): void {
  }

  save() {

  }

  undo() {

  }
}

import { Component, OnInit } from '@angular/core';
import {Redirect} from "../models/redirect";

@Component({
  selector: 'app-redirect-creator',
  templateUrl: './redirect-creator.component.html',
  styleUrls: ['./redirect-creator.component.sass']
})


export class RedirectCreatorComponent implements OnInit {

  redirects: Redirect[] = [
    {short: "abcdef12", target: "https://yandex.ru/", useCount: 0},
    {short: "ff32f324", target: "https://github.com/", useCount: 2},
    {short: "aaaaaaaa", target: "https://www.youtube.com/", useCount: 3}
  ]

  basePath: string = window.location.origin;
  getPath (short: string): string {
    return this.basePath + "/" + short;
  }

  constructor() { }

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
}

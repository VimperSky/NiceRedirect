  import { Component, OnInit } from '@angular/core';
  import {ActivatedRoute} from "@angular/router";
  import {RedirectService} from "../../services/redirect.service";

@Component({
  selector: 'app-form-with-password',
  templateUrl: './form-with-password.component.html',
  styleUrls: ['./form-with-password.component.sass']
})
export class FormWithPasswordComponent implements OnInit {
  hide: boolean = true;
  password: string = "";

  private key: string = "";

  constructor(private activatedRoute: ActivatedRoute, private redirectService: RedirectService) { }

  ngOnInit(): void {
    this.key = this.activatedRoute.snapshot.queryParams["key"];
  }


  submitButton() {
    this.redirectService.verifyRedirect({key: this.key, password: this.password})
      .subscribe((result) => {
        console.log("success")
        console.log(result)
    }, (result) => {
        console.log("err")
        console.log(result)
      })
  }
}

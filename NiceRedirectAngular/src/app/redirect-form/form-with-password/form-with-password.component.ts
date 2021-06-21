  import { Component, OnInit } from '@angular/core';
  import {ActivatedRoute} from "@angular/router";
  import {RedirectService} from "../../services/redirect.service";
  import {FormControl, FormGroupDirective, NgForm} from "@angular/forms";
  import {ErrorStateMatcher} from "@angular/material/core";


@Component({
  selector: 'app-form-with-password',
  templateUrl: './form-with-password.component.html',
  styleUrls: ['./form-with-password.component.sass']
})
export class FormWithPasswordComponent implements OnInit {
  hide: boolean = true;
  password = new FormControl('', []);

  private key: string = "";

  constructor(private activatedRoute: ActivatedRoute, private redirectService: RedirectService) { }

  ngOnInit(): void {
    this.key = this.activatedRoute.snapshot.queryParams["key"];
  }


  submitButton() {
    this.redirectService.verifyRedirect({key: this.key, password: this.password.value})
      .subscribe((result: string) => {
        window.location.href = result;
      }, (result) => {
        this.password.setErrors({'passwordInvalid': true})
      })
  }
}

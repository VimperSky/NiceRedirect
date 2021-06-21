import { Component, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {fixUrl, urlPattern} from "../../tools/url";



@Component({
  selector: 'app-create',
  templateUrl: './create-components.component.html',
  styleUrls: ['./create.component.sass']
})

export class CreateComponent implements OnInit {
  target = new FormControl('', [
    Validators.required,
    Validators.pattern(urlPattern),
  ]);
  password = new FormControl('', []);

  hide: boolean = true;


  constructor(public dialogRef: MatDialogRef<CreateComponent>) {}


  ngOnInit(): void {
  }

  okButton() {
    this.dialogRef.close({value: fixUrl(this.target.value), password: this.password.value});
  }

  cancelButton() {
    this.dialogRef.close(null);
  }
}

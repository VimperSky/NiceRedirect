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
  hide: boolean = true;
  password: string = "";


  constructor(public dialogRef: MatDialogRef<CreateComponent>) {}


  ngOnInit(): void {
  }

  okButton() {
    alert (this.password)
    this.dialogRef.close({value: fixUrl(this.target.value), password: this.password});
  }

  cancelButton() {
    this.dialogRef.close(null);
  }
}

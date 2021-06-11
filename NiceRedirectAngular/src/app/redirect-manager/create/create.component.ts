import { Component, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.sass']
})
export class CreateComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CreateComponent>) {}


  ngOnInit(): void {
  }

  onNoClick() {
    this.dialogRef.close();
  }
}

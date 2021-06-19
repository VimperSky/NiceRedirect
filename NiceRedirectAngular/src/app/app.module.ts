import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import {MatListModule} from "@angular/material/list";
import {MatIconModule} from "@angular/material/icon";
import {RedirectManagerComponent} from "./redirect-manager/redirect-manager.component";
import { CreateComponent } from './redirect-manager/create/create-components.component';
import {MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule} from "@angular/material/dialog";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { NotFoundComponent } from './not-found/not-found.component';
import {ClipboardModule} from "@angular/cdk/clipboard";
import { FormWithPasswordComponent } from './redirect-form/form-with-password/form-with-password.component';



@NgModule({
  declarations: [
    AppComponent,
    RedirectManagerComponent,
    HomeComponent,
    CreateComponent,
    NotFoundComponent,
    FormWithPasswordComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    AppRoutingModule,
    MatListModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ClipboardModule
  ],
  bootstrap: [AppComponent],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: true}}
  ]
})



export class AppModule {

}

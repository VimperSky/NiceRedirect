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
import { CreateComponent } from './redirect-manager/create/create.component';
import {MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule} from "@angular/material/dialog";



@NgModule({
  declarations: [
    AppComponent,
    RedirectManagerComponent,
    HomeComponent,
    CreateComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    AppRoutingModule,
    MatListModule,
    MatIconModule,
    MatDialogModule
  ],
  bootstrap: [AppComponent],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: true}}
  ]
})



export class AppModule {

}

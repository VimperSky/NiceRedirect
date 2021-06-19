import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {RedirectManagerComponent} from "./redirect-manager/redirect-manager.component";
import {NotFoundComponent} from "./not-found/not-found.component";
import {FormWithPasswordComponent} from "./redirect-form/form-with-password/form-with-password.component";

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'redirects',
    component: RedirectManagerComponent
  },
  {
    path: 'not-found',
    component: NotFoundComponent
  },
  {
    path: 'form/password',
    component: FormWithPasswordComponent,
  },
  {
    path: '**',
    redirectTo: "/not-found",
    pathMatch: 'full',
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

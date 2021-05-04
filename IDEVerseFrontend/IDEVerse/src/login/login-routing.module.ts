import { LoginComponent } from '../app/components/login/login.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

export const loginRoutes: Routes = [
  {
    path: '',
    component: LoginComponent
  }
];

@NgModule({
  imports: [ RouterModule.forChild(loginRoutes) ],
  exports: [ RouterModule ]
})
export class LoginRoutesModule {

}

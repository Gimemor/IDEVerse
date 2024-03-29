import { LoginRoutesModule } from './login-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    LoginRoutesModule
  ],
  declarations: [LoginComponent]
})
export class LoginModule { }

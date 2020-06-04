import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/material.module';
import { LoginComponent } from './login/login.component';



@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    RouterModule.forChild(
      [{
        path: 'login',
        component: LoginComponent,
      }]
    )
  ],
  declarations: [
    LoginComponent
  ]
})
export class UserModule { }

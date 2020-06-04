import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from '../shared/services/auth.guard';
import { MaterialModule } from '../shared/material.module';
import { LayoutModule } from '@angular/cdk/layout';



@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule.forChild([
      { path: 'home',
        component:  DashboardComponent,
        canActivate: [AuthGuard] }
    ]),
    LayoutModule
  ],
  declarations: [DashboardComponent]
})
export class HomeModule { }

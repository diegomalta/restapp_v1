import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from '../shared/services/auth.guard';



@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'home', 
        component:  DashboardComponent,
        canActivate: [AuthGuard] }
    ])
  ],
  declarations: [DashboardComponent]
})
export class HomeModule { }

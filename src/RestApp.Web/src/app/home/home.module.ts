import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from '../shared/services/auth.guard';
import { MaterialModule } from '../shared/material.module';
import { LayoutModule } from '@angular/cdk/layout';
import { DashboardService } from './dashboard.service';
import { DailycardComponent } from './dashboard/dailycard/dailycard.component';
import { DashboardDirective } from './dashboard/dashboard.directive';
import { BasecardComponent } from './dashboard/basecard/basecard.component';



@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule.forChild([
      {
        path: 'home',
        component: DashboardComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'daily',
        component: DailycardComponent,
        canActivate: [AuthGuard]
      }
    ]),
    LayoutModule
  ],
  providers: [DashboardService],
  declarations: [DashboardComponent, DailycardComponent, DashboardDirective, BasecardComponent]
})
export class HomeModule { }

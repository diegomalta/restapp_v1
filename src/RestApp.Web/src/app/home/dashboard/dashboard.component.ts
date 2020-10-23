import { Component, OnInit } from '@angular/core';
import { map, tap } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { DashboardService } from '../dashboard.service';
import { DashboardItem } from './dashboard.item';
import { DailycardComponent } from './dailycard/dailycard.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  /** Based on the screen size, switch from standard to one column per row */
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Daily Report', 
            cols: 1, 
            rows: 1, 
            cardInfo: new DashboardItem(DailycardComponent,{ 
            date: '01/01/2000',
            totalAmount: 1909,
            totalOrders: 90,
            isActive: true
           }) }
        ];
      }

      return [
        { title: 'Daily Report', 
          cols: 2, 
          rows: 1, 
          cardInfo: new DashboardItem(DailycardComponent,{ 
          date: '01/01/2000',
          totalAmount: 1909,
          totalOrders: 90,
          isActive: true
         }) }
      ];
    })
  );

  constructor(private breakpointObserver: BreakpointObserver, 
              private dashboarService: DashboardService) {}

  ngOnInit(): void {
    this.dashboarService.getDailyReport()
    .pipe(tap(result => console.log(result))
    ).subscribe();
  }
}

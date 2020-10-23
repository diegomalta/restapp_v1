import { Component, Input } from '@angular/core';
import { DashboardComponent } from '../dashboard.item';

@Component({
  selector: 'app-dailycard',
  templateUrl: './dailycard.component.html',
  styleUrls: ['./dailycard.component.scss']
})
export class DailycardComponent implements DashboardComponent {

  @Input() data: any;

  constructor() { }

}

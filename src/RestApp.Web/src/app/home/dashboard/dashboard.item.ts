import { Type } from '@angular/core';

export interface DashboardComponent {
  data: any;
}

export class DashboardItem {
  constructor(public component: Type<any>, public data: any) {}
}

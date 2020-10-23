import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[app-dashboard-host]'
})
export class DashboardDirective {

  constructor(public viewContainerRef: ViewContainerRef) { }

}

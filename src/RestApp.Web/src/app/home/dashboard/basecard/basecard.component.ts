import { Component, OnInit, ViewChild, ComponentFactoryResolver, Input } from '@angular/core';
import { DashboardDirective } from '../dashboard.directive';
import { DashboardItem, DashboardComponent } from '../dashboard.item';

@Component({
  selector: 'app-basecard',
  template: '<ng-template app-dashboard-host></ng-template>'
})
export class BasecardComponent implements OnInit {

  @Input() dashboardItem: any;
  @ViewChild(DashboardDirective, { static: true }) dashboardHost: DashboardDirective;

  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.loadComponenet();
  }

  private loadComponenet(): void {

    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.dashboardItem.cardInfo.component);
    const viewContainerRef = this.dashboardHost.viewContainerRef;
    viewContainerRef.clear();
    const componentRef = viewContainerRef.createComponent(componentFactory);
    (<DashboardComponent>componentRef.instance).data = this.dashboardItem.cardInfo.data;
  }

}

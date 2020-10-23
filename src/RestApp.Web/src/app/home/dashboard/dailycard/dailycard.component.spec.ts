import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailycardComponent } from './dailycard.component';

describe('DailycardComponent', () => {
  let component: DailycardComponent;
  let fixture: ComponentFixture<DailycardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailycardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailycardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

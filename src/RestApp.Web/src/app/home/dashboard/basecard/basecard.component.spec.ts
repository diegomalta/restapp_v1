import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BasecardComponent } from './basecard.component';

describe('BasecardComponent', () => {
  let component: BasecardComponent;
  let fixture: ComponentFixture<BasecardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BasecardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BasecardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

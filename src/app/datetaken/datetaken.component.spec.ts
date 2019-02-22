import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatetakenComponent } from './datetaken.component';

describe('DatetakenComponent', () => {
  let component: DatetakenComponent;
  let fixture: ComponentFixture<DatetakenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatetakenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatetakenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

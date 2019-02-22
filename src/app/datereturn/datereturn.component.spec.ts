import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatereturnComponent } from './datereturn.component';

describe('DatereturnComponent', () => {
  let component: DatereturnComponent;
  let fixture: ComponentFixture<DatereturnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatereturnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatereturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

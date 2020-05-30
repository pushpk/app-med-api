import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCardiovascularRiskReynoldsComponent } from './dialog-cardiovascular-risk-reynolds.component';

describe('DialogCardiovascularRiskReynoldsComponent', () => {
  let component: DialogCardiovascularRiskReynoldsComponent;
  let fixture: ComponentFixture<DialogCardiovascularRiskReynoldsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCardiovascularRiskReynoldsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCardiovascularRiskReynoldsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

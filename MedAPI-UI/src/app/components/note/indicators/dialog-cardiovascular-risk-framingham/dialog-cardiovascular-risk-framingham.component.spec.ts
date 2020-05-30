import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCardiovascularRiskFraminghamComponent } from './dialog-cardiovascular-risk-framingham.component';

describe('DialogCardiovascularRiskFraminghamComponent', () => {
  let component: DialogCardiovascularRiskFraminghamComponent;
  let fixture: ComponentFixture<DialogCardiovascularRiskFraminghamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCardiovascularRiskFraminghamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCardiovascularRiskFraminghamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

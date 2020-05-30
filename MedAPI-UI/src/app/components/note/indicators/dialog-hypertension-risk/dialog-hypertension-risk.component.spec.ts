import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogHypertensionRiskComponent } from './dialog-hypertension-risk.component';

describe('DialogHypertensionRiskComponent', () => {
  let component: DialogHypertensionRiskComponent;
  let fixture: ComponentFixture<DialogHypertensionRiskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogHypertensionRiskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogHypertensionRiskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

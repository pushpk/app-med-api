import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogDiabetesRiskComponent } from './dialog-diabetes-risk.component';

describe('DialogDiabetesRiskComponent', () => {
  let component: DialogDiabetesRiskComponent;
  let fixture: ComponentFixture<DialogDiabetesRiskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogDiabetesRiskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogDiabetesRiskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

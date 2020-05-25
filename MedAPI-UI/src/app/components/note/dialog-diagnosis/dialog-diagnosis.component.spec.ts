import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogDiagnosisComponent } from './dialog-diagnosis.component';

describe('DialogDiagnosisComponent', () => {
  let component: DialogDiagnosisComponent;
  let fixture: ComponentFixture<DialogDiagnosisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogDiagnosisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogDiagnosisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

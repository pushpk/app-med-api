import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormTriageComponent } from './form-triage.component';

describe('FormTriageComponent', () => {
  let component: FormTriageComponent;
  let fixture: ComponentFixture<FormTriageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormTriageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormTriageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSummaryComponent } from './form-summary.component';

describe('FormSummaryComponent', () => {
  let component: FormSummaryComponent;
  let fixture: ComponentFixture<FormSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

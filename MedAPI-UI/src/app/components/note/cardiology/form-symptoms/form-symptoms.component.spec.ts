import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSymptomsComponent } from './form-symptoms.component';

describe('FormSymptomsComponent', () => {
  let component: FormSymptomsComponent;
  let fixture: ComponentFixture<FormSymptomsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormSymptomsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSymptomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

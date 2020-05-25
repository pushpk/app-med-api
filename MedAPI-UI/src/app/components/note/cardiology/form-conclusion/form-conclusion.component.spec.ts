import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormConclusionComponent } from './form-conclusion.component';

describe('FormConclusionComponent', () => {
  let component: FormConclusionComponent;
  let fixture: ComponentFixture<FormConclusionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormConclusionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormConclusionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

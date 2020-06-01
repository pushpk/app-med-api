import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardioFormSymptomsComponent } from './cardio-form-symptoms.component';

describe('CardioFormSymptomsComponent', () => {
  let component: CardioFormSymptomsComponent;
  let fixture: ComponentFixture<CardioFormSymptomsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardioFormSymptomsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardioFormSymptomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

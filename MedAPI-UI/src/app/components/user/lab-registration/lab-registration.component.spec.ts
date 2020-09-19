import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabRegistrationComponent } from './lab-registration.component';

describe('LabRegistrationComponent', () => {
  let component: LabRegistrationComponent;
  let fixture: ComponentFixture<LabRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

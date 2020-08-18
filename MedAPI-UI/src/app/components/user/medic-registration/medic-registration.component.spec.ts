import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicRegistrationComponent } from './medic-registration.component';

describe('MedicRegistrationComponent', () => {
  let component: MedicRegistrationComponent;
  let fixture: ComponentFixture<MedicRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedicRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

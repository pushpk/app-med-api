import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCardiovascularAgeComponent } from './dialog-cardiovascular-age.component';

describe('DialogCardiovascularAgeComponent', () => {
  let component: DialogCardiovascularAgeComponent;
  let fixture: ComponentFixture<DialogCardiovascularAgeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCardiovascularAgeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCardiovascularAgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

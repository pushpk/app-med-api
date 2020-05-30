import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogBmiComponent } from './dialog-bmi.component';

describe('DialogBmiComponent', () => {
  let component: DialogBmiComponent;
  let fixture: ComponentFixture<DialogBmiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogBmiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogBmiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

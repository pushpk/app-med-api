import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogFractureRiskComponent } from './dialog-fracture-risk.component';

describe('DialogFractureRiskComponent', () => {
  let component: DialogFractureRiskComponent;
  let fixture: ComponentFixture<DialogFractureRiskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogFractureRiskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogFractureRiskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

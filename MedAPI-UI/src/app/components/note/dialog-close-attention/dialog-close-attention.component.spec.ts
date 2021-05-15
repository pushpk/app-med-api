import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCloseAttentionComponent } from './dialog-close-attention.component';

describe('DialogCloseAttentionComponent', () => {
  let component: DialogCloseAttentionComponent;
  let fixture: ComponentFixture<DialogCloseAttentionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCloseAttentionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCloseAttentionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

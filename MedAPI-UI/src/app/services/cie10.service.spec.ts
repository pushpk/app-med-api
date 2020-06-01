import { TestBed } from '@angular/core/testing';

import { CIE10Service } from './cie10.service';

describe('CIE10Service', () => {
  let service: CIE10Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CIE10Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

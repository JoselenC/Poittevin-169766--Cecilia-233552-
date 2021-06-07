import { TestBed } from '@angular/core/testing';

import { PsychologyService } from './psychology.service';

describe('PsychologyService', () => {
  let service: PsychologyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PsychologyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

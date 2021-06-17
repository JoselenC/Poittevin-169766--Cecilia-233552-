import { TestBed } from '@angular/core/testing';

import { ProblematicService } from './problematic.service';

describe('ProblematicService', () => {
  let service: ProblematicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProblematicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

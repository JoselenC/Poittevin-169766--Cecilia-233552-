import { TestBed } from '@angular/core/testing';

import { CustomErrorHandler } from './error-interceptor.service';

describe('ErrorInterceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      CustomErrorHandler
      ]
  }));

  it('should be created', () => {
    const interceptor: CustomErrorHandler = TestBed.inject(CustomErrorHandler);
    expect(interceptor).toBeTruthy();
  });
});

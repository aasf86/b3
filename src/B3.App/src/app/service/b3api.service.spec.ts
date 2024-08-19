import { TestBed } from '@angular/core/testing';

import { B3apiService } from './b3api.service';

describe('B3apiService', () => {
  let service: B3apiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(B3apiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

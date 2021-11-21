import { TestBed } from '@angular/core/testing';

import { RecaudosService } from './recaudos.service';

describe('RecaudosService', () => {
  let service: RecaudosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecaudosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

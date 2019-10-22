import { TestBed } from '@angular/core/testing';

import { FormComponentService } from './formcomponent.service';

describe('FormComponentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FormComponentService = TestBed.get(FormComponentService);
    expect(service).toBeTruthy();
  });
});

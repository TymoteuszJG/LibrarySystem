/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookAccessServiceService } from './book-access-service.service';

describe('Service: BookAccessService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookAccessServiceService]
    });
  });

  it('should ...', inject([BookAccessServiceService], (service: BookAccessServiceService) => {
    expect(service).toBeTruthy();
  }));
});

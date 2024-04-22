import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { Booking } from '../models/booking.model';
import { BookingService } from './booking.service';

describe('BookingService', () => {
  let service: BookingService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BookingService],
    });
    service = TestBed.inject(BookingService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('BookingService_should_be_created', () => {
    expect(service).toBeTruthy();
  });

  fit('BookingService_should_have_addBooking_method', () => {
    expect(service.addBooking).toBeTruthy();
  });

  fit('BookingService_should_have_getBookings_method', () => {
    expect(service.getBookings).toBeTruthy();
  });

  fit('BookingService_should_add_a_booking_and_return_it', () => {
    const mockBooking: Booking = {
      bookingId: 1,
      customerName: 'Test CustomerName',
      bookingDate: 'Test BookingDate',
      numberOfGuests: 1,
      contactNumber: 'Test ContactNumber',
      email: 'Test Email',
      specialRequests: 'Test SpecialRequests'
    };

    service.addBooking(mockBooking).subscribe((booking) => {
      expect(booking).toEqual(mockBooking);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Booking`);
    expect(req.request.method).toBe('POST');
    req.flush(mockBooking);
  });

  fit('BookingService_should_get_bookings', () => {
    const mockBookings: Booking[] = [
      {
        bookingId: 1,
      customerName: 'Test CustomerName',
      bookingDate: 'Test BookingDate',
      numberOfGuests: 1,
      contactNumber: 'Test ContactNumber',
      email: 'Test Email',
      specialRequests: 'Test SpecialRequests'
      }
    ];

    service.getBookings().subscribe((bookings) => {
      expect(bookings).toEqual(mockBookings);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Booking`);
    expect(req.request.method).toBe('GET');
    req.flush(mockBookings);
  });
});


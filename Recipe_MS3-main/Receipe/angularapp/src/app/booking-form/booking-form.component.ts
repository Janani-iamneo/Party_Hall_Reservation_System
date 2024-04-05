import { Component } from '@angular/core';
import { Booking } from '../models/booking.model'; // Import the Booking model
import { BookingService } from '../services/booking.service'; // Import the Booking service
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styleUrls: ['./booking-form.component.css']
})
export class BookingFormComponent {
  newBooking: Booking = {
    bookingId: 0,
    customerName: '',
    bookingDate: '',
    numberOfGuests: 0,
    contactNumber: '',
    email: '',
    specialRequests: ''
  };

  constructor(private bookingService: BookingService, private router: Router) { }

  addBooking(): void {
    this.bookingService.addBooking(this.newBooking).subscribe(() => {
      console.log('Booking added successfully!');
      this.router.navigate(['/viewBookings']);
    });
  }
}

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BookingService } from '../services/booking.service';
import { BookingListComponent } from './booking-list.component';
import { of } from 'rxjs';

describe('BookingListComponent', () => {
    let component: BookingListComponent;
    let fixture: ComponentFixture<BookingListComponent>;
    let mockBookingService;

    beforeEach(async () => {
      mockBookingService = jasmine.createSpyObj(['getBookings']);

        await TestBed.configureTestingModule({
            declarations: [BookingListComponent],
            providers: [
                { provide: BookingService, useValue: mockBookingService }
            ]
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(BookingListComponent);
        component = fixture.componentInstance;
    });

    fit('should_create_booking_listComponent', () => {
      mockBookingService.getBookings.and.returnValue(of([]));
        fixture.detectChanges();
        expect(component).toBeTruthy();
    });

    fit('booking_listComponent_should_call_loadBooking_on_ngOnInit', () => {
        spyOn(component, 'loadBookings');
        fixture.detectChanges();
        expect(component.loadBookings).toHaveBeenCalled();
    });

});


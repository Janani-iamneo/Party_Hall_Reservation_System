import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { BookingService } from '../services/booking.service';
import { BookingFormComponent } from './booking-form.component';
import { Router } from '@angular/router';

describe('BookingFormComponent', () => {
    let component: BookingFormComponent;
    let fixture: ComponentFixture<BookingFormComponent>;
    let recipeService: BookingService;
    let router: Router;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [FormsModule, HttpClientTestingModule],
            declarations: [BookingFormComponent],
            providers: [BookingService, { provide: Router, useClass: class { navigate = jasmine.createSpy('navigate'); } }]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BookingFormComponent);
        component = fixture.componentInstance;
        recipeService = TestBed.inject(BookingService);
        router = TestBed.inject(Router);
    });

    fit('should_create_BookingFormComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('BooingFormComponent_should_have_a_form_for_adding_a_booking', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement).toBeTruthy();
    });

    fit('BookingFormComponent_should_have_form_controls_for_booking_details_description_ingredients_instructions_and_author', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement.querySelector('#customerName')).toBeTruthy();
        expect(formElement.querySelector('#bookingDate')).toBeTruthy();
        expect(formElement.querySelector('#numberOfGuests')).toBeTruthy();
        expect(formElement.querySelector('#contactNumber')).toBeTruthy();
        expect(formElement.querySelector('#email')).toBeTruthy();
        expect(formElement.querySelector('#specialRequests')).toBeTruthy();
    });

    fit('BookingFormComponent_should_have_a_button_for_adding_a_booking', () => {
        const buttonElement: HTMLButtonElement = fixture.nativeElement.querySelector('button');
        expect(buttonElement).toBeTruthy();
        expect(buttonElement.textContent).toContain('Book Now');
    });

    fit('BookingFormComponent_should_have_addBooking_method', () => {
        expect(component['addBooking']).toBeTruthy();
    });

});

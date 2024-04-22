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

  fit('BookingService_should_have_getRecipes_method', () => {
    expect(service.getRecipes).toBeTruthy();
  });

  // fit('RecipeService_should_add_a_recipe_and_return_it', () => {
  //   const mockRecipe: Recipe = {
  //     recipeId: 1,
  //     name: 'Test Recipe',
  //     description: 'Test Description',
  //     ingredients: 'Test Ingredients',
  //     instructions: 'Test Instructions',
  //     author: 'Test Author'
  //   };

  //   service.addRecipe(mockRecipe).subscribe((recipe) => {
  //     expect(recipe).toEqual(mockRecipe);
  //   });

  //   const req = httpTestingController.expectOne(`${service['apiUrl']}api/Recipe`);
  //   expect(req.request.method).toBe('POST');
  //   req.flush(mockRecipe);
  // });

  // fit('RecipeService_should_get_recipes', () => {
  //   const mockRecipes: Recipe[] = [
  //     {
  //       recipeId: 1,
  //       name: 'Test Recipe 1',
  //       description: 'Test Description',
  //       ingredients: 'Test Ingredients',
  //       instructions: 'Test Instructions',
  //       author: 'Test Author'
  //     }
  //   ];

  //   service.getRecipes().subscribe((recipes) => {
  //     expect(recipes).toEqual(mockRecipes);
  //   });

  //   const req = httpTestingController.expectOne(`${service['apiUrl']}api/Recipe`);
  //   expect(req.request.method).toBe('GET');
  //   req.flush(mockRecipes);
  // });
});


import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private apiUrl = 'https://8080-fcebdccccdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addRecipe(booking: Booking): Observable<Booking> {
    return this.http.post<Booking>(`${this.apiUrl}api/Recipe`, booking);
  }

  getRecipes(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.apiUrl}api/Recipe`);
  }
}


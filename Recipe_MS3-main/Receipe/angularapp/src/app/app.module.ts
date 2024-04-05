import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// import { RecipeFormComponent } from './recipe-form/recipe-form.component';
import { HeaderComponent } from './header/header.component';
// import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { BookingFormComponent } from './booking-form/booking-form.component';
import { BookingListComponent } from './booking-list/booking-list.component';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BookingFormComponent,
    BookingListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
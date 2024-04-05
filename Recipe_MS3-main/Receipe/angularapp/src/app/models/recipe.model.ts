
export interface Booking {
  BookingId: number;
  CustomerName: string;
  BookingDate: string;
  NumberOfGuests: number;
  ContactNumber: string;
  Email: string;
  SpecialRequests: string;
  }
  
  export interface Recipe {
    recipeId: number;
    name: string;
    description: string;
    ingredients: string;
    instructions: string;
    author: string;
  }
using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Booking date is required")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Number of guests is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of guests must be at least 1")]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = "Contact information is required")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string SpecialRequests { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using NUnit.Framework;
// using dotnetapp.Controllers;
// using dotnetapp.Models;
// using dotnetapp.Exceptions;

// namespace dotnetapp.Tests
// {
//     [TestFixture]
//     public class TurfBookingControllerTests
//     {
//         private ApplicationDbContext _dbContext;
//         private TurfController _turfController;
//         private BookingController _bookingController;


//         [SetUp]
//         public void Setup()
//         {
//             var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;
//             _dbContext = new ApplicationDbContext(options);
//             _turfController = new TurfController(_dbContext);
//             _bookingController = new BookingController(_dbContext);

//         }

//         [TearDown]
//         public void TearDown()
//         {
//             // Dispose the ApplicationDbContext and reset the database
//             _dbContext.Database.EnsureDeleted();
//             _dbContext.Dispose();
//         }

//         [Test]
//         public void BookingController_Get_Book_by_turfId_ReturnsViewResult()
//         {
//             // Arrange
//             var turfId = 1;
//             var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//             _dbContext.Turfs.Add(turf);
//             _dbContext.SaveChanges();

//             // Act
//             var result = _bookingController.Book(turfId) as ViewResult;

//             // Assert
//             Assert.IsNotNull(result);
//         }

//         [Test]
//         public void BookingController_Get_Book_by_InvalidTurfId_ReturnsNotFound()
//         {
//             // Arrange
//             var turfId = 1;

//             // Act
//             var result = _bookingController.Book(turfId) as NotFoundResult;

//             // Assert
//             Assert.IsNotNull(result);
//         }

//         [Test]
//         public void BookingController_Post_Book_ValidBooking_Success_Redirects_Details()
//         {
//             // Arrange
//             var turfId = 1;
//             var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//             var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "1234567890", DurationInMinutes = 60 };
//             _dbContext.Turfs.Add(turf);
//             _dbContext.SaveChanges();

//             // Act
//             var result = _bookingController.Book(turfId, booking1) as RedirectToActionResult;
//             var booking = _dbContext.Bookings.Include(b => b.Turf).FirstOrDefault();

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual("Details", result.ActionName);
//             Assert.IsNotNull(booking);
//             Assert.AreEqual(turfId, booking.Turf.TurfID);
//             Assert.AreEqual("John Doe", booking.CustomerName);
//             Assert.AreEqual("1234567890", booking.ContactNumber);
//             Assert.AreEqual(60, booking.DurationInMinutes);
//         }


//         [Test]
//         public void BookingController_Post_Book_by_InvalidTurfId_ReturnsNotFound()
//         {
//             // Arrange
//             var turfId = 1;
//             var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "123456789", DurationInMinutes = 60 };

//             // Act
//             var result = _bookingController.Book(turfId, booking1) as NotFoundResult;

//             // Assert
//             Assert.IsNotNull(result);
//         }

//        [Test]
//         public void TurfController_Delete_ValidTurfId_Success_Redirects_Delete()
//         {
//             // Arrange
//             var turfId = 1;
//             var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//             _dbContext.Turfs.Add(turf);
//             _dbContext.SaveChanges();

//             // Act
//             var result = _turfController.DeleteConfirmed(turfId) as RedirectToActionResult;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual("Index", result.ActionName); // Check if it redirects to Index action
//         }


//         [Test]
//         public void TurfController_DeleteConfirmed_ValidTurfId_RedirectsTo_Index()
//         {
//             // Arrange
//             var turfId = 1;
//             var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//             _dbContext.Turfs.Add(turf);
//             _dbContext.SaveChanges();

//             // Act
//             var result = _turfController.DeleteConfirmed(turfId) as RedirectToActionResult;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual("Index", result.ActionName);
//         }



//         [Test]
//         public void TurfController_Delete_InvalidTurfId_NotFound()
//         {
//             // Arrange
//             var invalidTurfId = 999;

//             // Act
//             var result = _turfController.Delete(invalidTurfId) as NotFoundResult;

//             // Assert
//             Assert.IsNotNull(result);
//         }

//         [Test]
//         public void TurfController_Index_ReturnsViewWithTurfList()
//         {
//             var turfId = 1;
//             var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//             _dbContext.Turfs.Add(turf);
//             _dbContext.SaveChanges();
//             // Act
//             var result = _turfController.Index() as ViewResult;
//             var model = result?.Model as List<Turf>;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual(1, model?.Count);
//         }

// [Test]
// public void BookingController_Post_Book_by_InvalidDurationInMinutes_ThrowsException()
// {
//     // Arrange
//     var turfId = 1;
//     var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//     var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "123456789", DurationInMinutes = 130 }; // Set duration to 130 minutes
//     _dbContext.Turfs.Add(turf);
//     _dbContext.SaveChanges();

//     // Act & Assert
//     var ex = Assert.Throws<TurfBookingException>(() =>
//     {
//         _bookingController.Book(turfId, booking1);
//     });

//     // Assert
//     Assert.AreEqual("Booking duration cannot exceed 120 minutes", ex.Message);
// }

// [Test]
// public void BookingController_Post_Book_ThrowsException_with_message()
// {
//     // Arrange
//     var turfId = 1;
//     var turf = new Turf { TurfID = turfId, Name = "Turf 1", Capacity = 4, Availability = true };
//     // Create a booking with duration exceeding 120 minutes
//     var booking1 = new Booking { DurationInMinutes = 180 }; // Set duration to 180 minutes 

//     _dbContext.Turfs.Add(turf);
//     _dbContext.SaveChanges();

//     // Act & Assert
//     var ex = Assert.Throws<TurfBookingException>(() =>
//     {
//         _bookingController.Book(turfId, booking1);
//     });

//     // Assert
//     Assert.AreEqual("Booking duration cannot exceed 120 minutes", ex.Message); 
// }


//         [Test]
//         public void BookingController_Details_by_InvalidBookingId_ReturnsNotFound()
//         {
//             // Arrange
//             var bookingId = 1;

//             // Act
//             var result = _bookingController.Details(bookingId) as NotFoundResult;

//             // Assert
//             Assert.IsNotNull(result);
//         }

//         [Test]
//         public void Booking_Properties_BookingID_GetSetCorrectly()
//         {
//             // Arrange
//             var booking = new Booking();

//             // Act
//             booking.BookingID = 1;

//             // Assert
//             Assert.AreEqual(1, booking.BookingID);
//         }

//         [Test]
//         public void Booking_Properties_TurfID_GetSetCorrectly()
//         {
//             // Arrange
//             var booking = new Booking();

//             // Act
//             booking.TurfID = 2;

//             // Assert
//             Assert.AreEqual(2, booking.TurfID);
//         }

//         [Test]
//         public void Booking_Properties_DurationInMinutes_GetSetCorrectly()
//         {
//             // Arrange
//             var booking = new Booking();

//             booking.DurationInMinutes = 90; // Example value

//             // Assert
//             Assert.AreEqual(90, booking.DurationInMinutes);
//         }


//         [Test]
//         public void Booking_Properties_BookingID_HaveCorrectDataTypes()
//         {
//             // Arrange
//             var booking = new Booking();

//             // Assert
//             Assert.That(booking.BookingID, Is.TypeOf<int>());
//         }
//         [Test]
//         public void Booking_Properties_TurfID_HaveCorrectDataTypes()
//         {
//             // Arrange
//             var booking = new Booking
//             {
//                 // Initialize TurfID property with an appropriate value
//                 TurfID = 1
//             };
//             // Assert
//             Assert.That(booking.TurfID, Is.TypeOf<int>());
//         }

//         [Test]
//         public void Booking_Properties_CustomerName_ContactNumber_DurationInMinutes_HaveCorrectDataTypes()
//         {
//             // Arrange
//             var booking = new Booking
//             {
//                 // Initialize properties with appropriate values
//                 CustomerName = "John Doe",
//                 ContactNumber = "1234567890",
//                 DurationInMinutes = 60
//             };

//             // Assert
//             Assert.That(booking.CustomerName, Is.TypeOf<string>());
//             Assert.That(booking.ContactNumber, Is.TypeOf<string>());
//             Assert.That(booking.DurationInMinutes, Is.TypeOf<int>());
//         }


//         [Test]
//         public void TurfClassExists()
//         {
//             var turf = new Turf();

//             Assert.IsNotNull(turf);
//         }

//         [Test]
//         public void BookingClassExists()
//         {
//             var booking = new Booking();

//             Assert.IsNotNull(booking);
//         }

//         [Test]
//         public void ApplicationDbContextContainsDbSetBookingProperty()
//         {

//             var propertyInfo = _dbContext.GetType().GetProperty("Bookings");

//             Assert.IsNotNull(propertyInfo);
//             Assert.AreEqual(typeof(DbSet<Booking>), propertyInfo.PropertyType);
//         }

//         [Test]
//         public void ApplicationDbContextContainsDbSetTurfProperty()
//         {

//             var propertyInfo = _dbContext.GetType().GetProperty("Turfs");

//             Assert.AreEqual(typeof(DbSet<Turf>), propertyInfo.PropertyType);
//         }

//         [Test]
//         public void Turf_Properties_GetSetCorrectly()
//         {
//             // Arrange
//             var turf = new Turf();

//             // Act
//             turf.TurfID = 1;
//             turf.Name = "Turf 1";

//             // Assert
//             Assert.AreEqual(1, turf.TurfID);
//             Assert.AreEqual("Turf 1", turf.Name);
//         }

//         [Test]
//         public void Turf_Properties_Capacity_GetSetCorrectly()
//         {
//             // Arrange
//             var turf = new Turf();

//             turf.Capacity = 4;

//             Assert.AreEqual(4, turf.Capacity);
//         }

//         [Test]
//         public void Turf_Properties_Availability_GetSetCorrectly()
//         {
//             // Arrange
//             var turf = new Turf();

//             turf.Availability = true;

//             Assert.IsTrue(turf.Availability);
//         }

//         [Test]
//         public void Turf_Properties_HaveCorrectDataTypes()
//         {
//             // Arrange
//             var turf = new Turf
//             {
//                 // Initialize the Name property with a valid string value
//                 Name = "Turf 1"
//             };

//             // Assert
//             Assert.That(turf.TurfID, Is.TypeOf<int>());
//             Assert.That(turf.Name, Is.TypeOf<string>());
//             Assert.That(turf.Capacity, Is.TypeOf<int>());
//             Assert.That(turf.Availability, Is.TypeOf<bool>());
//         }

//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using dotnetapp.Exceptions;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class PartyHallBookingControllerTests
    {
        private ApplicationDbContext _dbContext;
        private PartyHallController _partyHallController;
        private BookingController _bookingController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _partyHallController = new PartyHallController(_dbContext);
            _bookingController = new BookingController(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the ApplicationDbContext and reset the database
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Test]
        public void BookingController_Get_Book_by_partyHallId_ReturnsViewResult()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act
            var result = _bookingController.Book(partyHallId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BookingController_Get_Book_by_InvalidPartyHallId_ReturnsNotFound()
        {
            // Arrange
            var partyHallId = 1;

            // Act
            var result = _bookingController.Book(partyHallId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BookingController_Post_Book_ValidBooking_Success_Redirects_Details()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "1234567890", DurationInMinutes = 60 };
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act
            var result = _bookingController.Book(partyHallId, booking1) as RedirectToActionResult;
            var booking = _dbContext.Bookings.Include(b => b.PartyHall).FirstOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ActionName);
            Assert.IsNotNull(booking);
            Assert.AreEqual(partyHallId, booking.PartyHall.PartyHallID);
            Assert.AreEqual("John Doe", booking.CustomerName);
            Assert.AreEqual("1234567890", booking.ContactNumber);
            Assert.AreEqual(60, booking.DurationInMinutes);
        }

        [Test]
        public void BookingController_Post_Book_by_InvalidPartyHallId_ReturnsNotFound()
        {
            // Arrange
            var partyHallId = 1;
            var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "123456789", DurationInMinutes = 60 };

            // Act
            var result = _bookingController.Book(partyHallId, booking1) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PartyHallController_Delete_ValidPartyHallId_Success_Redirects_Delete()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act
            var result = _partyHallController.DeleteConfirmed(partyHallId) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName); // Check if it redirects to Index action
        }

        [Test]
        public void PartyHallController_DeleteConfirmed_ValidPartyHallId_RedirectsTo_Index()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act
            var result = _partyHallController.DeleteConfirmed(partyHallId) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public void PartyHallController_Delete_InvalidPartyHallId_NotFound()
        {
            // Arrange
            var invalidPartyHallId = 999;

            // Act
            var result = _partyHallController.Delete(invalidPartyHallId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PartyHallController_Index_ReturnsViewWithPartyHallList()
        {
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act
            var result = _partyHallController.Index() as ViewResult;
            var model = result?.Model as List<PartyHall>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, model?.Count);
        }

        [Test]
        public void BookingController_Post_Book_by_InvalidDurationInMinutes_ThrowsException()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            var booking1 = new Booking { CustomerName = "John Doe", ContactNumber = "123456789", DurationInMinutes = 130 }; // Set duration to 130 minutes
            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act & Assert
            var ex = Assert.Throws<PartyHallBookingException>(() =>
            {
                _bookingController.Book(partyHallId, booking1);
            });

            // Assert
            Assert.AreEqual("Booking duration cannot exceed 120 minutes", ex.Message);
        }

        [Test]
        public void BookingController_Post_Book_ThrowsException_with_message()
        {
            // Arrange
            var partyHallId = 1;
            var partyHall = new PartyHall { PartyHallID = partyHallId, Name = "Party Hall 1", Capacity = 100, Availability = true };
            // Create a booking with duration exceeding 120 minutes
            var booking1 = new Booking { DurationInMinutes = 180 }; // Set duration to 180 minutes 

            _dbContext.PartyHalls.Add(partyHall);
            _dbContext.SaveChanges();

            // Act & Assert
            var ex = Assert.Throws<PartyHallBookingException>(() =>
            {
                _bookingController.Book(partyHallId, booking1);
            });

            // Assert
            Assert.AreEqual("Booking duration cannot exceed 120 minutes", ex.Message); 
        }

        [Test]
        public void BookingController_Details_by_InvalidBookingId_ReturnsNotFound()
        {
            // Arrange
            var bookingId = 1;

            // Act
            var result = _bookingController.Details(bookingId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Booking_Properties_BookingID_GetSetCorrectly()
        {
            // Arrange
            var booking = new Booking();

            // Act
            booking.BookingID = 1;

            // Assert
            Assert.AreEqual(1, booking.BookingID);
        }

        [Test]
        public void Booking_Properties_PartyHallID_GetSetCorrectly()
        {
            // Arrange
            var booking = new Booking();

            // Act
            booking.PartyHallID = 2;

            // Assert
            Assert.AreEqual(2, booking.PartyHallID);
        }

        [Test]
        public void Booking_Properties_DurationInMinutes_GetSetCorrectly()
        {
            // Arrange
            var booking = new Booking();

            booking.DurationInMinutes = 90; // Example value

            // Assert
            Assert.AreEqual(90, booking.DurationInMinutes);
        }

        [Test]
        public void Booking_Properties_BookingID_HaveCorrectDataTypes()
        {
            // Arrange
            var booking = new Booking();

            // Assert
            Assert.That(booking.BookingID, Is.TypeOf<int>());
        }

        [Test]
        public void Booking_Properties_PartyHallID_HaveCorrectDataTypes()
        {
            // Arrange
            var booking = new Booking
            {
                // Initialize PartyHallID property with an appropriate value
                PartyHallID = 1
            };
            // Assert
            Assert.That(booking.PartyHallID, Is.TypeOf<int>());
        }

        [Test]
        public void Booking_Properties_CustomerName_ContactNumber_DurationInMinutes_HaveCorrectDataTypes()
        {
            // Arrange
            var booking = new Booking
            {
                // Initialize properties with appropriate values
                CustomerName = "John Doe",
                ContactNumber = "1234567890",
                DurationInMinutes = 60
            };

            // Assert
            Assert.That(booking.CustomerName, Is.TypeOf<string>());
            Assert.That(booking.ContactNumber, Is.TypeOf<string>());
            Assert.That(booking.DurationInMinutes, Is.TypeOf<int>());
        }

        [Test]
        public void PartyHallClassExists()
        {
            var partyHall = new PartyHall();

            Assert.IsNotNull(partyHall);
        }

        [Test]
        public void BookingClassExists()
        {
            var booking = new Booking();

            Assert.IsNotNull(booking);
        }

        [Test]
        public void ApplicationDbContextContainsDbSetBookingProperty()
        {
            var propertyInfo = _dbContext.GetType().GetProperty("Bookings");

            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Booking>), propertyInfo.PropertyType);
        }

        [Test]
        public void ApplicationDbContextContainsDbSetPartyHallProperty()
        {
            var propertyInfo = _dbContext.GetType().GetProperty("PartyHalls");

            Assert.AreEqual(typeof(DbSet<PartyHall>), propertyInfo.PropertyType);
        }

        [Test]
        public void PartyHall_Properties_GetSetCorrectly()
        {
            // Arrange
            var partyHall = new PartyHall();

            // Act
            partyHall.PartyHallID = 1;
            partyHall.Name = "Party Hall 1";

            // Assert
            Assert.AreEqual(1, partyHall.PartyHallID);
            Assert.AreEqual("Party Hall 1", partyHall.Name);
        }

        [Test]
        public void PartyHall_Properties_Capacity_GetSetCorrectly()
        {
            // Arrange
            var partyHall = new PartyHall();

            partyHall.Capacity = 100;

            Assert.AreEqual(100, partyHall.Capacity);
        }

        [Test]
        public void PartyHall_Properties_Availability_GetSetCorrectly()
        {
            // Arrange
            var partyHall = new PartyHall();

            partyHall.Availability = true;

            Assert.IsTrue(partyHall.Availability);
        }

        [Test]
        public void PartyHall_Properties_HaveCorrectDataTypes()
        {
            // Arrange
            var partyHall = new PartyHall
            {
                // Initialize the Name property with a valid string value
                Name = "Party Hall 1"
            };

            // Assert
            Assert.That(partyHall.PartyHallID, Is.TypeOf<int>());
            Assert.That(partyHall.Name, Is.TypeOf<string>());
            Assert.That(partyHall.Capacity, Is.TypeOf<int>());
            Assert.That(partyHall.Availability, Is.TypeOf<bool>());
        }

//         [Test]
// public void Search_NoMatch_ReturnsNoMatchMessage()
// {
//     // Arrange
//     var partyHalls = new List<PartyHall>
//     {
//         new PartyHall { PartyHallID = 1, Name = "Elegant Banquet Hall", Capacity = 100, Availability = true },
//         new PartyHall { PartyHallID = 2, Name = "Cozy Party Room", Capacity = 50, Availability = true }
//     };
//     _dbContext.PartyHalls.AddRange(partyHalls);
//     _dbContext.SaveChanges();

//     // Clear any existing TempData to ensure a clean test environment
//     _partyHallController.TempData.Clear();

//     // Act
//     var result = _partyHallController.Search("Grand Celebration Hall") as RedirectToActionResult;

//     // Assert
//     Assert.IsNotNull(result);
//     Assert.AreEqual("Index", result.ActionName); // Ensure it redirects to Index action
//     Assert.IsTrue(_partyHallController.TempData.ContainsKey("Message")); // Check if TempData contains key "Message"
//     Assert.AreEqual("Party hall 'Grand Celebration Hall' not found.", _partyHallController.TempData["Message"]); // Ensure proper message is set
// }

    [Test]
public void Search_NoMatch_ReturnsNoMatchMessage()
{
    // Arrange
    var partyHalls = new List<PartyHall>
    {
        new PartyHall { PartyHallID = 1, Name = "Elegant Banquet Hall", Capacity = 100, Availability = true },
        new PartyHall { PartyHallID = 2, Name = "Cozy Party Room", Capacity = 50, Availability = true }
    };
    _dbContext.PartyHalls.AddRange(partyHalls);
    _dbContext.SaveChanges();

    _partyHallController.TempData.Clear();

    // Act
    var result = _partyHallController.Search("Grand Celebration Hall") as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ActionName); // Ensure it redirects to Index action

    // Check if TempData is not null and contains the expected message
    Assert.IsTrue(_partyHallController.TempData.ContainsKey("Message"));
    Assert.AreEqual("Party hall 'Grand Celebration Hall' not found.", _partyHallController.TempData["Message"]);
}

    }
}

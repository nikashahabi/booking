using System;
using booking.Controllers;
using Microsoft.AspNetCore.Mvc;
using booking.Models;
using booking.Services;
namespace booking.Controllers
{
    [ApiController]
    [Route("/salons")]
    public class SalonGenerator : ControllerBase
    {
        BookingService bookingService;
        public SalonGenerator (BookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpPost]
        public ActionResult <Show> PostSalon ([FromBody]Salon salon)
        {
            if (salon.Name is null)
            {
                return BadRequest("Name of the salon is null");
            }
            if (salon.SeatHeight <= 0)
            {
                return BadRequest("Seat width <= 0");
            }
            if (salon.SeatHeight <= 0)
            {
                return BadRequest("Seat heigth <= 0");
            }
            bookingService.AddToSalonDatabase(salon);
            return Ok(salon);

        }
    }
}

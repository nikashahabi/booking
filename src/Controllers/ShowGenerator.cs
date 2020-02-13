using System;
using booking.Controllers;
using Microsoft.AspNetCore.Mvc;
using booking.Models;
using booking.Services;
namespace booking.Controllers
{
    [ApiController]
    [Route("/shows")]
    public class ShowGenerator : ControllerBase
    {
        BookingService bookingService;
        public ShowGenerator (BookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpPost]
        public ActionResult <Show> PostShow ([FromBody]Show show)
        {
            if (show.Title is null)
            {
                return BadRequest("Show title is null");
            }
            if (show.Price <= 0)
            {
                return BadRequest("Price <= 0");
            }
            if (show.StartTime.ToShortDateString()=="0001-01-01T00:00:00")
            {
                return BadRequest("Start time is null");
            }
            if (show.EndTime.ToShortDateString()=="0001-01-01T00:00:00")
            {
                return BadRequest("End time is null");
            }
            if (show.StartTime >= show.EndTime)
            {
                return BadRequest("Start time sooner than end time");
            }
            // if (show.SalonId > bookingService.MaxSalonId() || show.SalonId < 0)
            // {
            //     return BadRequest("Salon Id does not exist");
            // }

            //bookingService.addToSalonDatabase(salon);
            bookingService.AddToShowDatabase(show);
            return Ok(show);

        }

    }


}
using booking.Models;
using booking.Controllers;
using System;

namespace booking.Services
{
    public class BookingService
    {
        public AppDbContext dbContext { get; set; }
        public BookingService (AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public void AddToShowDatabase (Show show)
        {
            dbContext.shows.Add(show);
            //Console.WriteLine("databse");
            dbContext.SaveChanges();
        }
        public void AddToSalonDatabase (Salon salon)
        {
            dbContext.salons.Add(salon);
            dbContext.SaveChanges();

        }
        // public int MaxSalonId ()
        // {
        //     return (dbContext.salons

        // }

    }
}
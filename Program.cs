using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BandsOfSuncoast
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BandsOfSuncoastContext();

            var bands = context.Bands;

            var albums = context.Albums.
            Include(album => album.Band);

            // var newBand = new Band
            // {
            //     Name = "The Owls",
            //     CountryOfOrigin = "Australia",
            //     NumberOfMembers = 5,
            //     Website = "Owls.com",
            //     Style = "R&B",
            //     IsSigned = true,
            //     ContactName = "Riz",
            //     ContactPhoneNumber = "727-239-9058"
            // };

            // context.Bands.Add(newBand);
            // context.SaveChanges();
            // Console.WriteLine($"Here are the list of {bands}");
        }
    }
}

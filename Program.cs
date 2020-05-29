using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BandsOfSuncoast
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            var context = new BandsOfSuncoastContext();

            var bands = context.Bands;

            var albums = context.Albums.
            Include(album => album.Band);

            var userHasQuitApp = false;

            while (userHasQuitApp == false)
            {
                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");

                Console.WriteLine("Please select a number from one of the choices: ");

                Console.WriteLine("(1) - View all the bands in Bands Of Suncoast");

                Console.WriteLine("(2) - Add a band to your directory");

                Console.WriteLine("(3) - Add an album for a band");

                Console.WriteLine("(4) - Remove a band from Bands Of Suncoast");

                Console.WriteLine("(5) - Sign a band to Bands Of Suncoast");

                Console.WriteLine("(6) - View a specific band and their albums");

                Console.WriteLine("(7) - View all albums in order by release date");

                Console.WriteLine("(8) - View all bands that are signed by Bands Of Suncoast");

                Console.WriteLine("(9) - View all bands that are not signed by Bands Of Suncoast");

                Console.WriteLine("(10) - Quit application");

                Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");

                var choice = PromptForInteger("Choice:");

                if (choice == 10)
                {
                    Console.WriteLine("Goodbye!");
                    userHasQuitApp = true;
                }

                if (choice == 1)
                {
                    foreach (var band in bands)
                    {
                        Console.WriteLine(band.Name);
                    }
                }


            }
        }
    }
}
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

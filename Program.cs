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

        static bool PromptForBool(string prompt)
        {
            Console.Write(prompt);
            bool inputFromUser;
            var isThisGoodInput = bool.TryParse(Console.ReadLine(), out inputFromUser);

            if (inputFromUser == true || inputFromUser == false)
            {
                return inputFromUser;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using false as your answer.");
                return false;
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
                        Console.WriteLine("Here are the list of bands under Bands Of Suncoast!");
                        Console.WriteLine(band.Name);
                    }
                }

                if (choice == 2)
                {
                    var newName = PromptForString("Name: ");
                    var newCountryOfOrigin = PromptForString("Country Of Origin: ");
                    var newNumberOfMembers = PromptForInteger("Number Of Members: ");
                    var newWebsite = PromptForString("Website: ");
                    var newStyle = PromptForString("Style: ");
                    var newIsSigned = PromptForBool("Is This Group Signed 'True or False': ");
                    var newContactName = PromptForString("Bands Main Contact Name: ");
                    var newContactPhoneNumber = PromptForString($"Contact number for {newContactName}: ");


                    var newBand = new Band
                    {
                        Name = newName,
                        CountryOfOrigin = newCountryOfOrigin,
                        NumberOfMembers = newNumberOfMembers,
                        Website = newWebsite,
                        Style = newStyle,
                        IsSigned = newIsSigned,
                        ContactName = newContactName,
                        ContactPhoneNumber = newContactPhoneNumber,
                    };

                    context.Bands.Add(newBand);
                    context.SaveChanges();
                }
            }
        }
    }
}


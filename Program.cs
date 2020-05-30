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

        static DateTime PromptForDateTime(string prompt)
        {
            Console.Write(prompt);
            DateTime inputByUser;
            var isThisGoodInput = DateTime.TryParse(Console.ReadLine(), out inputByUser);

            if (isThisGoodInput)
            {
                return inputByUser;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return DateTime.Now;
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

                Console.WriteLine("(5) - Resign a band to Bands Of Suncoast");

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
                    Console.WriteLine("Here are the list of bands under Bands Of Suncoast!");
                    foreach (var band in bands)
                    {
                        Console.WriteLine(band.Name);
                    }
                    Console.WriteLine("Press any key to return to the main menu");
                    Console.ReadKey();
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

                if (choice == 3)
                {
                    Console.WriteLine("Here is a list of bands in Bands of Suncoast: ");
                    foreach (var band in bands)
                    {
                        Console.WriteLine($"({band.Id}), {band.Name} ");
                    }
                    var selectedBandId = PromptForInteger("Which band would you like to chose?");
                    var selectedBand = bands.FirstOrDefault(band => band.Id == selectedBandId);
                    if (selectedBand == null)
                    {
                        Console.WriteLine("You entered a band that does not exist. Returning to the main menu.");
                    }
                    else
                    {
                        var newTitle = PromptForString("Album title: ");
                        var newIsExplicit = PromptForBool("Is this album categorized as explicit? 'True or False': ");
                        var newReleaseDate = PromptForDateTime("The date and time album was released: Input in formart of 'YYYY-MM-DD hh:mm:ss' ");

                        var newAlbum = new Album()
                        {
                            BandId = selectedBand.Id,
                            Title = newTitle,
                            IsExplicit = newIsExplicit,
                            ReleaseDate = newReleaseDate
                        };
                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                    }
                }

                if (choice == 7)
                {
                    Console.WriteLine("Here are the list of albums in order by release date: ");
                    Console.WriteLine();

                    foreach (var album in albums)
                    {
                        var albumInOrderByDateReleased = context.Albums.OrderBy(album => album.ReleaseDate);
                        var description = album.Description();

                        Console.WriteLine(description);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to return to the main menu");
                    Console.ReadKey();
                }

                if (choice == 8)
                {
                    Console.WriteLine("Here are the list of bands that are signed by Bands Of Suncoast.");
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine(band.Name, band.IsSigned);
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("This is the list of current bands signed. Press any key to return to the main menu");
                    Console.ReadKey();
                }

                if (choice == 9)
                {
                    Console.WriteLine("Here are the list of bands that are not signed by Bands Of Suncoast.");
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine(band.Name, band.IsSigned);
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("This is the list of current bands signed. Press any key to return to the main menu");
                    Console.ReadKey();
                }
            }
        }
    }
}


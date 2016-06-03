using System;
using System.Collections.Generic;
using System.Linq;
using BA.Airline.Common.Flight;
using BA.Airline.Passengers;
using BA.Airline.Utils;

namespace BA.Airline.Flights
{
    public static class FlightsMenu
    {
        public static void ShowMain(List<IFlight> flights)
        {
            var flightsViewer = new FlightsViewer();
            var flightsManager = new FlightsManager();

            string headerMenu = "  F L I G H T S   O F   A I R L I N E  ".PadLeft(68, '─').PadRight(98, '─');

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Output.PrintHeader(headerMenu);
                Console.WriteLine();

                flightsViewer.PrintTable(flights);
                Output.PrintMsg(
                    "  1-FlightDetails  2-PassByName  3-PassByPassport  4-SearchEconomy  5-Add  6-Edit  7-Del  0-Exit",
                    ConsoleColor.DarkGray);

                switch (Input.GetKey(0, 7))
                {
                    case 1:
                        ShowDetails(flights);
                        break;
                    case 2:
                        PassengersService.SearchBy(flights, "name");
                        break;
                    case 3:
                        PassengersService.SearchBy(flights, "passport");
                        break;
                    case 4:
                        FlightsService.SearchEconomy(flights);
                        break;
                    case 5:
                        flightsManager.Add(flights);
                        break;
                    case 6:
                        flightsManager.Edit(flights);
                        break;
                    case 7:
                        flightsManager.Delete(flights);
                        break;
                    case 0:
                        return;
                }
            } // while
        }

        public static void ShowDetails(List<IFlight> flights)
        {
            //int i = 0;
            int flightNumber = 0;
            int countPassengers = 0;
            IFlight flightSelected = null;
            var passengersViewer = new PassengersViewer();
            var passengersManager = new PassengersManager();
            string menuPartEdit = string.Empty;

            Console.WriteLine();
            flightNumber = Input.GetNumber("Enter flight number for view details information: ");
            Console.WriteLine();

            flightSelected = flights.FirstOrDefault(f => f.Number == flightNumber);

            if (flightSelected != null)
            {
                string headerMenu = "  D E T A I L S   O F   F L I G H T  ".PadLeft(68, '─').PadRight(98, '─');

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Output.PrintHeader(headerMenu);
                    Console.WriteLine();

                    Output.PrintValue("     Number: ", flightSelected.Number);
                    Output.PrintValue("       Time: ", flightSelected.Time.ToString("g"));
                    Output.PrintValue("  Direction: ", flightSelected.Direction);
                    Output.PrintValue("       City: ", flightSelected.City);
                    Output.PrintValue("   Terminal: ", flightSelected.Terminal);
                    Output.PrintValue("     Status: ", flightSelected.Status);
                    Output.PrintValue("       Gate: ", flightSelected.Gate);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" Passengers:");
                    passengersViewer.PrintTable(flightSelected.Passengers);
                    countPassengers = flightSelected.Passengers.Count;
                    menuPartEdit = (countPassengers != 0) ? "2-Edit  3-Del" : "".PadLeft(13);
                    Output.PrintMsg(
                        $"  1-Add  {menuPartEdit}                                                        0-Return main menu",
                        ConsoleColor.DarkGray);

                    switch (Input.GetKey(0, (countPassengers != 0) ? 3 : 1))
                    {
                        case 1:
                            passengersManager.Add(flightSelected.Passengers);
                            break;
                        case 2:
                            passengersManager.Edit(flightSelected.Passengers);
                            break;
                        case 3:
                            passengersManager.Delete(flightSelected.Passengers);
                            break;
                        case 0:
                            return;
                    }
                } // while
            }
            else
            {
                Output.PrintMsgLine($"Flight with number {flightNumber} is absent!", ConsoleColor.Red);
                Output.PrintPause();
            }
        }
    }
}

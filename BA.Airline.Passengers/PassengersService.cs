using System;
using System.Collections.Generic;
using System.Linq;
using BA.Airline.Common.Flight;
using BA.Airline.Common.Passenger;
using BA.Airline.Utils;

namespace BA.Airline.Passengers
{
    public static class PassengersService
    {
        public static void SearchBy(List<IFlight> flights, string fieldSearch)
        {
            var passengersViewer = new PassengersViewer();

            Console.WriteLine();
            Output.PrintHeader($"Search passengers by {fieldSearch} (partial coincidence)");
            Console.WriteLine();

            string textForSearch = Input.GetString($"Enter {fieldSearch} (or part of {fieldSearch}) for search: ", 20).ToUpper();

            var foundPassengers = GetSearchBy(flights, fieldSearch, textForSearch);

            if (foundPassengers.Count != 0)
            {
                passengersViewer.PrintTable(foundPassengers);
            }
            else
            {
                Output.PrintMsgLine($"Flights haven't passengers with {fieldSearch} {textForSearch}!", ConsoleColor.Red);
            }

            Output.PrintPause();
        }

        public static List<IPassenger> GetSearchBy(List<IFlight> flights, string fieldSearch, string textForSearch)
        {
            textForSearch = textForSearch.ToUpper();
            switch (fieldSearch)
            {
                case "name":
                    return flights.SelectMany(f => f.Passengers.Where(
                                    p => (p.FirstName + " " + p.LastName).ToUpper().Contains(textForSearch) == true))
                                    .ToList();
                case "passport":
                    return flights.SelectMany(f => f.Passengers.Where(
                                    p => p.Passport.ToUpper().Contains(textForSearch) == true))
                                    .ToList();
                default:
                    return new List<IPassenger>();
            }
        }
    }
}

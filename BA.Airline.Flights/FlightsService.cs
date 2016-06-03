using System;
using System.Collections.Generic;
using System.Linq;
using BA.Airline.Common.Flight;
using BA.Airline.Tickets;
using BA.Airline.Utils;

namespace BA.Airline.Flights
{
    public static class FlightsService
    {
        public static void SearchEconomy(List<IFlight> flights)
        {
            Console.WriteLine();
            Output.PrintHeader("Search economy flights");
            Console.WriteLine();

            decimal maxPrice = Input.GetDecimal("Enter maximum price: ");

            var foundFlights = GetEconomy(flights, maxPrice);

            if (foundFlights.Count != 0)
            {
                var flightsViewer = new FlightsViewer();
                flightsViewer.PrintTable(foundFlights);
            }
            else
            {
                Output.PrintMsgLine($"Airline haven't flights with the price of economy ticket lower than {maxPrice} dollars!", ConsoleColor.Red);
            }

            Output.PrintPause();
        }

        public static List<IFlight> GetEconomy(List<IFlight> flights, decimal maxPrice)
        {
            return flights.Where(f => f.Passengers.Count(p => p.FlightTicket.Class == TicketClass.Economy && p.FlightTicket.Price < maxPrice) > 0)
                          .ToList();
        }
    }
}

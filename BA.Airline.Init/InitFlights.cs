using System;
using System.Collections.Generic;
using BA.Airline.Common.Flight;
using BA.Airline.Flights;

namespace BA.Airline.Init
{
    public static class InitFlights
    {
        private const int MinFlight = 5;
        private const int MaxFlightTimeSpread = 120;
        private const int MinGates = 1;
        private const int MaxGates = 32;

        private const int MinFlightNumber = 100;
        private const int MaxFlightNumber = 500;

        private static readonly string[] Cities = { "Kiev", "Kharkiv", "Boston", "Berlin", "New York",
                                                    "Hamburg", "Bruessel", "Istanbul", "Dubai", "London" };
        private static readonly string[] Terminals = { "A", "B", "C", "D", "E" };

        public static List<IFlight> CreateRandomList(int maxFlight, int maxPassenger)
        {
            var rnd = new Random();
            var flights = new List<IFlight>();

            int amountInitFlights = rnd.Next(MinFlight, maxFlight);

            for (int i = 0; i < amountInitFlights - 1; i++)
            {
                flights.Add(new Flight
                {
                    Direction = (rnd.NextDouble() >= 0.5) ? FlightDirection.Arrival : FlightDirection.Departure,
                    Time = DateTime.Now.AddMinutes(rnd.Next(-MaxFlightTimeSpread, MaxFlightTimeSpread)),
                    Number = rnd.Next(MinFlightNumber, MaxFlightNumber),
                    City = Cities[rnd.Next(Cities.Length - 1)],
                    Terminal = Terminals[rnd.Next(Terminals.Length - 1)],
                    Status = (FlightStatus)rnd.Next(Enum.GetNames(typeof(FlightStatus)).Length),
                    Gate = rnd.Next(MinGates, MaxGates),
                    Passengers = InitPassengers.CreateRandomList(maxPassenger)
                });
            }
            flights.Sort();

            return flights;
        }
    }
}

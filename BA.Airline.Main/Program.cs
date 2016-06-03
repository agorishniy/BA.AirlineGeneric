using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using BA.Airline.Common.Flight;
using BA.Airline.Flights;
using BA.Airline.Init;

namespace BA.Airline.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LogSystem();
            log.Write("Application was started");

            // get data from app.config
            int maxFlights = int.Parse(ConfigurationManager.AppSettings["MaxFlights"]);
            int maxPassengers = int.Parse(ConfigurationManager.AppSettings["MaxPassengers"]);

            // set size of console window
            Console.WindowWidth = 99;
            Console.WindowHeight = 50;

            List<IFlight> flights = InitFlights.CreateRandomList(maxFlights, maxPassengers);

            FlightsMenu.ShowMain(flights);

            log.Write("Application was ended");
        }
    }
}

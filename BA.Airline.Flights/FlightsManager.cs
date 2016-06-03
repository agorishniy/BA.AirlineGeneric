using System;
using System.Collections.Generic;
using System.Linq;
using BA.Airline.Common.Flight;
using BA.Airline.Common.Manager;
using BA.Airline.Utils;

namespace BA.Airline.Flights
{
    public class FlightsManager : Manager<IFlight>
    {
        /// <summary>
        /// Add flight to array
        /// </summary>
        /// <param name="flights">Array of flights</param>
        public override void Add(List<IFlight> flights)
        {
            IFlight newFlight = new Flight();

            Console.WriteLine();
            Output.PrintHeader("Add new flight");
            Console.WriteLine();
            Console.WriteLine("Enter data of new flight");
            Console.WriteLine();

            newFlight.Time = Input.GetDateTime("   Time   (DD.MM.YYYY HH:MM): ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Direction");
            Console.WriteLine("              0 - Arrival");
            newFlight.Direction = (FlightDirection)Input.GetNumber("              1 - Departure : ", 0, 1);
            newFlight.Number = (int)FlightInput.GetNewNumberFlight(flights, "   Number  (unique, 1<x<999): ", 1, 999);
            newFlight.City = Input.GetString("   City       (text, max 12): ", 12);
            newFlight.Terminal = Input.GetString("   Terminal    (text, max 8): ", 8);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Status");
            Console.WriteLine("              0 - CheckIn");
            Console.WriteLine("              1 - GateClosed");
            Console.WriteLine("              2 - Arrived");
            Console.WriteLine("              3 - DepartedAt");
            Console.WriteLine("              4 - Unknown");
            Console.WriteLine("              5 - Canceled");
            Console.WriteLine("              6 - ExpectedAt");
            Console.WriteLine("              7 - Delayed");
            newFlight.Status = (FlightStatus)Input.GetNumber("              8 - InFlight  : ", 0, 8);
            newFlight.Gate = (int)Input.GetNumber("   Gate             (1<x<32): ", 1, 32);

            flights.Add(newFlight);
            flights.Sort();

            Console.WriteLine();
            Output.PrintMsgLine("Flight was added successfully!", ConsoleColor.Green);

            Output.PrintPause();
        }

        /// <summary>
        /// Edit data of flight in array
        /// </summary>
        /// <param name="flights">Array of flights</param>
        public override void Edit(List<IFlight> flights)
        {
            Console.WriteLine();
            Output.PrintHeader("Edit flight");
            Console.WriteLine();

            var flightNumber = Input.GetNumber("Enter flight number: ");
            Console.WriteLine();

            var flight = flights.FirstOrDefault(f => f.Number == flightNumber);

            if (flight != null)
            {
                Console.WriteLine("  Enter new flight data");
                flight.City = Input.GetString("    City     (text, max 12): ", 12);
                flight.Terminal = Input.GetString("    Terminal  (text, max 8): ", 8);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Status:");
                Console.WriteLine("           0 - CheckIn");
                Console.WriteLine("           1 - GateClosed");
                Console.WriteLine("           2 - Arrived");
                Console.WriteLine("           3 - DepartedAt");
                Console.WriteLine("           4 - Unknown");
                Console.WriteLine("           5 - Canceled");
                Console.WriteLine("           6 - ExpectedAt");
                Console.WriteLine("           7 - Delayed");
                flight.Status = (FlightStatus)Input.GetNumber("           8 - InFlight    : ", 0, 8);
                flight.Gate = Input.GetNumber("    Gate           (1<x<32): ", 1, 32);

                Output.PrintMsgLine("Flight was edited successfully!", ConsoleColor.Green);
            }
            else
            {
                Output.PrintMsgLine($"Flight with number {flightNumber} is absent!", ConsoleColor.Red);
            }

            Output.PrintPause();
        }

        /// <summary>
        /// Delete flight from array
        /// </summary>
        /// <param name="flights">Array of flights</param>
        public override void Delete(List<IFlight> flights)
        {
            Console.WriteLine();
            Output.PrintHeader("Delete flight");
            Console.WriteLine();
            int flightNumber = Input.GetNumber("Enter flight number: ");
            Console.WriteLine();

            var flight = flights.FirstOrDefault(f => f.Number == flightNumber);

            if (flight != null)
            {
                if (flights.Remove(flight))
                    Output.PrintMsgLine("Flight was deleted successfully!", ConsoleColor.Green);
            }
            else
            {
                Output.PrintMsgLine($"Flight with number {flightNumber} is absent!", ConsoleColor.Red);
            }

            Output.PrintPause();
        }
    }
}

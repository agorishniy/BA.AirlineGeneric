using System;
using System.Collections.Generic;
using BA.Airline.Common.Manager;
using BA.Airline.Common.Passenger;
using BA.Airline.Tickets;
using BA.Airline.Utils;

namespace BA.Airline.Passengers
{
    public class PassengersManager: Manager<IPassenger>
    {
        /// <summary>
        /// Add passengers to array
        /// </summary>
        /// <param name="passengers">Array of passengers</param>
        public override void Add(List<IPassenger> passengers)
        {
            IPassenger newPassenger = new Passenger();
            var newTicket = new Ticket();

            Console.WriteLine();
            Output.PrintHeader("Add new passenger");
            Console.WriteLine();

            Console.WriteLine("Enter data of new passenger ");
            Console.WriteLine();

            newPassenger.LastName = Input.GetString("   Last name    (text, max 10): ", 10);
            newPassenger.FirstName = Input.GetString("   First name   (text, max 10): ", 10);
            newPassenger.Nationality = Input.GetString("   Nationality  (text, max 12): ", 12);
            newPassenger.Passport = Input.GetString("   Passport      (text, max 8): ", 8);
            newPassenger.Birthday = Input.GetDateTime("   Birthday       (DD.MM.YYYY): ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Sex");
            Console.WriteLine("                  0 - Male");
            newPassenger.Sex = (Gender)Input.GetNumber("                  1 - Female  : ", 0, 1);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Flight ticket class");
            Console.WriteLine("                  0 - Business");
            newTicket.Class = (TicketClass)Input.GetNumber("                  1 - Economy : ", 0, 1);
            newTicket.Price = Input.GetDecimal("   Flight ticket price        : ", 0, 1200);
            newPassenger.FlightTicket = newTicket;

            passengers.Add(newPassenger);
            passengers.Sort();

            Console.WriteLine();
            Output.PrintMsgLine("Passenger was added successfully!", ConsoleColor.Green);

            Output.PrintPause();
        }

        /// <summary>
        /// Edit data of passengers in array
        /// </summary>
        /// <param name="passengers">Array of passengers</param>
        public override void Edit(List<IPassenger> passengers)
        {
            Console.WriteLine();
            Output.PrintHeader("Edit flight");
            Console.WriteLine();
            int passengerNumber = Input.GetNumber("Enter passenger number: ", 1, passengers.Count) - 1;
            Console.WriteLine();

            Console.WriteLine("  Enter new passenger data");
            passengers[passengerNumber].LastName = Input.GetString("   Last name    (text, max 10): ", 10);
            passengers[passengerNumber].FirstName = Input.GetString("   First name   (text, max 10): ", 10);
            Console.WriteLine();

            Output.PrintMsgLine("Passenger was edited successfully!", ConsoleColor.Green);

            Output.PrintPause();
        }

        /// <summary>
        /// Delete passenger from array
        /// </summary>
        /// <param name="passengers">Array of passengers</param>
        public override void Delete(List<IPassenger> passengers)
        {
            Console.WriteLine();
            Output.PrintHeader("Delete passenger");
            Console.WriteLine();
            int passengerNumber = Input.GetNumber("Enter passenger number: ", 1, passengers.Count);
            Console.WriteLine();

            passengers.RemoveAt(passengerNumber - 1);
            passengers.Sort();

            Output.PrintMsgLine("Passenger was deleted successfully!", ConsoleColor.Green);

            Output.PrintPause();
        }
    }
}

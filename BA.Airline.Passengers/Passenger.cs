using System;
using System.Globalization;
using BA.Airline.Common.Passenger;
using BA.Airline.Tickets;

namespace BA.Airline.Passengers
{
    public class Passenger : IPassenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Sex { get; set; }
        public Ticket FlightTicket { get; set; }

        public string ToString(int[] headerColumLength, int number)
        {
            string sResult = "│ ";

            // Number (#)
            sResult += number.ToString().PadLeft(headerColumLength[0]) + " │ ";
            
            // Name
            sResult += (LastName + " " + FirstName).PadRight(headerColumLength[1]) + " │ ";

            // Nationality
            sResult += Nationality.PadRight(headerColumLength[2]) + " │ ";

            // Passport
            sResult += Passport.PadLeft(headerColumLength[3]) + " │ ";

            // Birthday
            sResult += Birthday.ToString("dd.MM.yyyy").PadLeft(headerColumLength[4]) + " │ ";

            // Sex
            sResult += ((Sex == Gender.Male) ? "M" : "F").PadLeft(headerColumLength[5]) + " │ ";

            // Price
            sResult += FlightTicket.Price.ToString("C", CultureInfo.GetCultureInfo("en-US")).PadLeft(headerColumLength[6]) + " │ ";

            // Class
            sResult += FlightTicket.Class.ToString().PadRight(headerColumLength[7]) + " │";

            return sResult;
        }

        public int CompareTo(IPassenger other)
        {
            if (other == null)
            {
                return 1;
            }

            return LastName.CompareTo(other.LastName);
        }
    }
}

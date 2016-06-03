using System;
using System.Collections.Generic;
using BA.Airline.Common.Flight;
using BA.Airline.Common.Passenger;

namespace BA.Airline.Flights
{
    public class Flight : IFlight
    {
        public FlightDirection Direction { get; set; }
        public DateTime Time { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Terminal { get; set; }
        public FlightStatus Status { get; set; }
        public int Gate { get; set; }
        public List<IPassenger> Passengers { get; set; }

        public Flight()
        {
            Passengers = new List<IPassenger>();
        }

        public string ToString(int[] headerColumLength)
        {
            string sResult = "│ ";
            // Time
            sResult += Time.ToString("dd.MM.yyyy HH:mm").PadLeft(headerColumLength[0]) + " │ ";
            // Direction
            sResult += Direction.ToString().PadRight(headerColumLength[1]) + " │ ";
            // Number
            sResult += Number.ToString().PadLeft(headerColumLength[2]) + " │ ";
            // City
            sResult += City.PadRight(headerColumLength[3]) + " │ ";
            // Terminal
            sResult += Terminal.PadLeft(headerColumLength[4]) + " │ ";
            // Status
            sResult += Status.ToString().PadRight(headerColumLength[5]) + " │ ";
            // Gate
            sResult += Gate.ToString().PadLeft(headerColumLength[6]) + " │";
            return sResult;
        }

        public int CompareTo(IFlight other)
        {
            if (other == null)
            {
                return 1;
            }

            return Time.CompareTo(other.Time);
        }
    }
}

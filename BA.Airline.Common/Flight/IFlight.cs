using System;
using System.Collections.Generic;
using BA.Airline.Common.Passenger;

namespace BA.Airline.Common.Flight
{
    public interface IFlight: IComparable<IFlight>
    {
        FlightDirection Direction { get; set; }
        DateTime Time { get; set; }
        int Number { get; set; }
        string City { get; set; }
        string Terminal { get; set; }
        FlightStatus Status { get; set; }
        int Gate { get; set; }
        List<IPassenger> Passengers { get; set; }

        string ToString(int[] headerColumLength);
    }
}

using System;
using BA.Airline.Tickets;

namespace BA.Airline.Common.Passenger
{
    public interface IPassenger: IComparable<IPassenger>
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Nationality { get; set; }
        string Passport { get; set; }
        DateTime Birthday { get; set; }
        Gender Sex { get; set; }
        Ticket FlightTicket { get; set; }

        string ToString(int[] headerColumLength, int number);
    }
}

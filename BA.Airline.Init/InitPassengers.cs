using System;
using System.Collections.Generic;
using BA.Airline.Common.Passenger;
using BA.Airline.Passengers;
using BA.Airline.Tickets;

namespace BA.Airline.Init
{
    class InitPassengers
    {
        private const int MinPassenger = 5;

        private static Random rnd = new Random();

        private static readonly string[] ManFirstName = { "Alex", "Kirill", "Bill", "Sam", "Oleg",
                                                          "Anton", "Denis", "Maxim", "Karl", "Lev" };

        private static readonly string[] ManLastName = { "Ivanov", "Petrov", "Sidorov", "Smith", "Williams",
                                                         "Davis", "Cooper", "Allen", "Rivera", "Ramos" };

        private static readonly string[] WomanFirstName = { "Kate", "Oksana", "Lena", "Eva", "Ella",
                                                            "Claire", "Stella", "Mira", "Alice", "Olga" };

        private static readonly string[] WomanLastName = { "Smirnova", "Petrova", "Sidorova", "Ivanova", "Popova",
                                                           "Stepanova", "Orlova", "Novikova", "Egorova", "Lomakina" };

        private static readonly string[] Nationality = { "Ukrainian", "Belarusian", "Spanish", "English", "German",
                                                          "French", "Italian", "Hungarian", "Polish", "Canadian" };

        public static List<IPassenger> CreateRandomList(int maxPassenger)
        {
            var passengers = new List<IPassenger>();
            var passenger = new Passenger();

            int amountInitPassengers = rnd.Next(MinPassenger, maxPassenger);
            TicketClass initTicketClass = TicketClass.Business;
            decimal initPrice = 0;

            for (int i = 0; i < amountInitPassengers - 1; i++)
            {
                passenger = new Passenger();
                passenger.Sex = (rnd.NextDouble() >= 0.5) ? Gender.Male : Gender.Female;
                if (passenger.Sex == Gender.Male)
                {
                    passenger.FirstName = ManFirstName[rnd.Next(ManFirstName.Length - 1)];
                    passenger.LastName = ManLastName[rnd.Next(ManFirstName.Length - 1)];
                }
                else
                {
                    passenger.FirstName = WomanFirstName[rnd.Next(WomanFirstName.Length - 1)];
                    passenger.LastName = WomanLastName[rnd.Next(WomanFirstName.Length - 1)];
                }

                passenger.Passport = ((char)rnd.Next(65, 90)).ToString() + ((char)rnd.Next(65, 90)).ToString() + rnd.Next(100000, 900000).ToString();
                passenger.Birthday = new DateTime(rnd.Next(1940, 2015), rnd.Next(1, 12), rnd.Next(1, 28));

                passenger.Nationality = Nationality[rnd.Next(WomanFirstName.Length - 1)];

                initTicketClass = (rnd.NextDouble() >= 0.5) ? TicketClass.Economy : TicketClass.Business;
                initPrice = (initTicketClass == TicketClass.Economy) ? (decimal)(50 + 400*rnd.NextDouble()) : (decimal)(300 + 400*rnd.NextDouble());

                passenger.FlightTicket = new Ticket(initTicketClass, initPrice);

                passengers.Add(passenger);
            }
            passengers.Sort();

            return passengers;
        }
    }
}

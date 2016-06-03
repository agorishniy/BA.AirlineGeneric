using System;
using System.Collections.Generic;
using System.Linq;
using BA.Airline.Common.Flight;
using BA.Airline.Common.Passenger;
using BA.Airline.Flights;
using BA.Airline.Passengers;
using BA.Airline.Tickets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BA.Airline.UnitTest
{
    [TestClass]
    public class UnitTestAirline
    {
        private static List<IFlight> InitFlights()
        {
            var flights = new List<IFlight>();

            // Flight number #1
            // Tickets price: 230, 440
            flights.Add(new Flight
            {
                Number = 1,
                Direction = FlightDirection.Arrival,
                Time = DateTime.Now,
                City = "Kiyv",
                Terminal = "A",
                Status = FlightStatus.Arrived,
                Gate = 12,
                Passengers = new List<IPassenger>()
                {
                    new Passenger {
                            FirstName = "Alex", LastName = "Sidorov", Nationality = "ukrainian",
                            Passport = "HF717171", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 230)
                    },
                    new Passenger {
                            FirstName = "Ivan", LastName = "Cooper", Nationality = "ukrainian",
                            Passport = "QD946352", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 440)
                    }
                }
            });

            // Flight number #2
            // Tickets price: 140, 600
            flights.Add(new Flight
            {
                Number = 2,
                Direction = FlightDirection.Arrival,
                Time = DateTime.Now,
                City = "Kiyv",
                Terminal = "A",
                Status = FlightStatus.Arrived,
                Gate = 12,
                Passengers = new List<IPassenger>()
                {
                    new Passenger {
                            FirstName = "Denis", LastName = "Davis", Nationality = "ukrainian",
                            Passport = "KA555555", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 140)
                    },
                    new Passenger {
                            FirstName = "Bill", LastName = "Ramos", Nationality = "ukrainian",
                            Passport = "YE912422", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 600)
                    }
                }
            });

            // Flight number #3
            // Tickets price: 700, 190
            flights.Add(new Flight
            {
                Number = 3,
                Direction = FlightDirection.Arrival,
                Time = DateTime.Now,
                City = "Kiyv",
                Terminal = "A",
                Status = FlightStatus.Arrived,
                Gate = 12,
                Passengers = new List<IPassenger>()
                {
                    new Passenger {
                            FirstName = "Oleg", LastName = "Petrov", Nationality = "ukrainian",
                            Passport = "MK236172", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 700)
                    },
                    new Passenger {
                            FirstName = "Anton", LastName = "Ivanov", Nationality = "ukrainian",
                            Passport = "RT986542", Birthday = DateTime.Now, Sex = Gender.Male,
                            FlightTicket = new Ticket(TicketClass.Economy, 190)
                    }
                }
            });

            return flights;
        }

        [TestMethod]
        public void TestGetEconomyFlight()
        {
            // arrange 
            // InitFlights method return 3 flights, total with 6 passengers
            // Tickets price: 
            // Flight #1: $230, $440
            // Flight #2: $140, $600
            // Flight #3: $700, $190
            var flights = InitFlights();
            decimal maxPrice = 200;

            // act
            var resultFlights = FlightsService.GetEconomy(flights, maxPrice);

            var isFlight2 = resultFlights.FirstOrDefault(f => f.Number == 2) != null;
            var isFlight3 = resultFlights.FirstOrDefault(f => f.Number == 3) != null;
            var isCount2 = resultFlights.Count == 2;

            // assert       
            Assert.AreEqual(true, isFlight2 && isFlight3 && isCount2,
                            "Method GetEconomy work incorrect");
        }

        [TestMethod]
        public void TestGetSearchByName()
        {
            // arrange 
            // InitFlights method return 3 flights, total with 6 passengers
            // Passengers: 
            //      Alex Sidorov
            //      Ivan Cooper
            //      Denis Davis
            //      Bill Ramos
            //      Oleg Petrov
            //      Anton Ivanov
            var flights = InitFlights();
            var fieldSearch = "name";
            var textForSearch = "Iv";


            // act
            var resultPassengers = PassengersService.GetSearchBy(flights, fieldSearch, textForSearch);

            var isPassengerIvan = resultPassengers.FirstOrDefault(p => p.FirstName == "Ivan") != null;
            var isPassengerIvanov = resultPassengers.FirstOrDefault(p => p.LastName == "Ivanov") != null;
            var isCount2 = resultPassengers.Count == 2;

            // assert       
            Assert.AreEqual(true, isPassengerIvan && isPassengerIvanov && isCount2,
                            "Method GetSearchBy works incorrect when search by name");
        }

        [TestMethod]
        public void TestGetSearchByPassport()
        {
            // arrange 
            // InitFlights method return 3 flights, total with 6 passengers
            // Passenger passports: 
            //      HF717171
            //      QD946352
            //      KA555555
            //      YE912422
            //      MK236172
            //      RT986542
            var flights = InitFlights();
            var fieldSearch = "passport";
            var textForSearch = "5";

            // act
            var resultPassengers = PassengersService.GetSearchBy(flights, fieldSearch, textForSearch);

            var isPassenger1 = resultPassengers.FirstOrDefault(p => p.Passport == "QD946352") != null;
            var isPassenger2 = resultPassengers.FirstOrDefault(p => p.Passport == "KA555555") != null;
            var isPassenger3 = resultPassengers.FirstOrDefault(p => p.Passport == "RT986542") != null;
            var isCount3 = resultPassengers.Count == 3;

            // assert       
            Assert.AreEqual(true, isPassenger1 && isPassenger2 && isPassenger3 && isCount3,
                            "Method GetSearchBy works incorrect when search by passport");
        }
    }
}

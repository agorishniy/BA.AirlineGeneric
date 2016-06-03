using System;
using System.Collections.Generic;
using BA.Airline.Common.Flight;
using BA.Airline.Utils;

namespace BA.Airline.Flights
{
    public static class FlightInput
    {
        public static int GetNewNumberFlight(List<IFlight> flights, string text = "", int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            string valueStr;
            int valueNumber;
            var isValid = false;

            Console.WriteLine("");
            do
            {
                Input.ClearLine(1);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.Yellow;
                valueStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                isValid = int.TryParse(valueStr, out valueNumber);
                if (!isValid)
                {
                    Output.PrintValidateMsg("    Inputed value is not number!");
                    continue;
                }

                isValid = valueNumber >= minValue && valueNumber <= maxValue;
                if (!isValid)
                {
                    Output.PrintValidateMsg($"    Inputed value must be {minValue}<x<{maxValue}!");
                    continue;
                }

                foreach (var flight in flights)
                {
                    if (flight.Number == valueNumber)
                    {
                        isValid = false;
                        Output.PrintValidateMsg("   Flight with this number has already");
                        break;
                    }
                }
            } while (!isValid);

            return valueNumber;
        }
    }
}

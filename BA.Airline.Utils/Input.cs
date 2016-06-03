using System;

namespace BA.Airline.Utils
{
    public static class Input
    {
        /// <summary>
        /// Read pressed key from specified range
        /// </summary>
        /// <param name="minValue">Min value of key</param>
        /// <param name="maxValue">Max value of key</param>
        /// <returns>Number of pressed key</returns>
        public static int GetKey(int minValue, int maxValue)
        {
            int item;

            ConsoleKeyInfo keyPressed;
            var isValidKey = false;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                keyPressed = Console.ReadKey();
                isValidKey = int.TryParse(keyPressed.KeyChar.ToString(), out item);
                ClearLine();
            } while (!(isValidKey && item >= minValue && item <= maxValue));

            
            Console.ForegroundColor = ConsoleColor.White;

            return item;
        }

        /// <summary>
        /// Enter a number from user with check specified range 
        /// </summary>
        /// <param name="text">Description of value</param>
        /// <param name="minValue">Min value of number</param>
        /// <param name="maxValue">Max value of number</param>
        /// <returns>Number was entered by user</returns>
        public static int GetNumber(string text = "", int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            string valueStr;
            int inputedValue;
            var isValid = false;

            Console.WriteLine("");
            do
            {
                ClearLine(1);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.Yellow;
                valueStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                isValid = int.TryParse(valueStr, out inputedValue);
                if (!isValid)
                {
                    Output.PrintValidateMsg("    Inputed value is not number!");
                    continue;
                }
                isValid = inputedValue >= minValue && inputedValue <= maxValue;
                if (!isValid)
                {
                    Output.PrintValidateMsg($"    Inputed value must be {minValue}<x<{maxValue}!");
                    continue;
                }
            } while (!isValid);

            return inputedValue;
        }

        /// <summary>
        /// Enter a decimal from user with check specified range 
        /// </summary>
        /// <param name="text">Description of value</param>
        /// <param name="minValue">Min value of decimal</param>
        /// <param name="maxValue">Max value of decimal</param>
        /// <returns>Decimal was entered by user</returns>
        public static decimal GetDecimal(string text = "", decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            string valueStr;
            decimal inputedValue;
            var isValid = false;

            Console.WriteLine("");
            do
            {
                ClearLine(1);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.Yellow;
                valueStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                isValid = decimal.TryParse(valueStr, out inputedValue);
                if (!isValid)
                {
                    Output.PrintValidateMsg("    Inputed value is not number!");
                    continue;
                }
                isValid = inputedValue >= minValue && inputedValue <= maxValue;
                if (!isValid)
                {
                    Output.PrintValidateMsg($"    Inputed value must be {minValue}<x<{maxValue}!");
                    continue;
                }
            } while (!isValid);

            return inputedValue;
        }

        public static string GetString(string text = "", int maxLength = 100)
        {
            string valueStr;
            var isValid = false;

            Console.WriteLine("");
            do
            {
                ClearLine(1);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Yellow;
                valueStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                isValid = valueStr != "";
                if (!isValid)
                {
                    Output.PrintValidateMsg("    Inputed string can't was empty!");
                    continue;
                }

                isValid = valueStr.Length <= maxLength;
                if (!isValid)
                {
                    Output.PrintValidateMsg($"    Length of inputed string more then {maxLength}!");
                    continue;
                }
            } while (!isValid);

            return valueStr;
        }

        public static DateTime GetDateTime(string text = "")
        {
            string valueStr;
            DateTime valueDateTime;
            var isValid = false;

            Console.WriteLine("");
            do
            {
                ClearLine(1);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Yellow;
                valueStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                isValid = DateTime.TryParse(valueStr, out valueDateTime);
                if (!isValid)
                {
                    Output.PrintValidateMsg("    Inputed value is not DateTime!");
                    continue;
                }
            } while (!isValid);

            return valueDateTime;
        }

        public static void ClearLine(int shift = 0)
        {
            int currentLineCursor = 0;

            Console.SetCursorPosition(0, Console.CursorTop - shift);
            currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

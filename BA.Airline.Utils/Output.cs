using System;

namespace BA.Airline.Utils
{
    public class Output
    {
        public static void PrintPause()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void PrintValidateMsg(string msg)
        {
            PrintMsgLine(msg, ConsoleColor.Red);
            Console.WriteLine("    Press any key");
            Console.ReadKey();
            Input.ClearLine(1);
            Input.ClearLine(1);
        }

        public static void PrintBorderLine(int[] headerColumLength, string left, char fill, string mid, string right)
        {
            Console.Write(left);

            for (var i = 0; i < headerColumLength.Length; i++)
            {
                Console.Write(new string(fill, headerColumLength[i]));
                if (i != headerColumLength.Length - 1)
                {
                    Console.Write(mid);
                }
            }

            Console.WriteLine(right);
        }

        public static void PrintHeaderLine(int[] headerColumLength, string[] headerNames)
        {
            int indentLeft = 0;
            int indentRight = 0;

            Console.Write("│ ");

            for (var i = 0; i < headerColumLength.Length; i++)
            {
                indentRight = (headerColumLength[i] - headerNames[i].Length) / 2;
                if (indentRight < 0)
                {
                    indentRight = 0;
                }

                indentLeft = headerColumLength[i] - headerNames[i].Length - indentRight;
                if (indentLeft < 0)
                {
                    indentLeft = 0;
                }

                Console.Write("{0}{1}{2}", new string(' ', indentLeft), headerNames[i], new string(' ', indentRight));
                if (i != headerColumLength.Length - 1)
                {
                    Console.Write(" │ ");
                }
            }

            Console.WriteLine(" │");
        }

        public static void PrintMsg(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintMsgLine(string text, ConsoleColor color)
        {
            PrintMsg(text, color);
            Console.WriteLine();
        }

        public static void PrintHeader(string text)
        {
            PrintMsgLine(text, ConsoleColor.Yellow);
        }

        public static void PrintValue<T>(string text, T value)
        {
            var curColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value.ToString());

            Console.ForegroundColor = curColor;
        }
    }
}

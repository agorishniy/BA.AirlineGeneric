using System;
using System.Collections.Generic;
using BA.Airline.Utils;

namespace BA.Airline.Common.Viewer
{
    public abstract class Viewer<T> : IViewer<T>
    {
        protected string[] HeaderNames;
        protected int[] HeaderColumLength;
        protected abstract string GetOutputRow(T element, int index);
        protected abstract void SetDataOfHeader();

        protected Viewer()
        {
            SetDataOfHeader();
        }

        public void PrintTable(List<T> arr)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Output.PrintBorderLine(HeaderColumLength, "┌─", '─', "─┬─", "─┐");
            Output.PrintHeaderLine(HeaderColumLength, HeaderNames);
            Output.PrintBorderLine(HeaderColumLength, "├─", '─', "─┼─", "─┤");

            int i = 0;
            foreach (var item in arr)
            {
                Console.WriteLine(GetOutputRow(item, i));
                i++;
            }

            Output.PrintBorderLine(HeaderColumLength, "└─", '─', "─┴─", "─┘");
        }
    }
}

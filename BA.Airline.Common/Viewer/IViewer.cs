using System.Collections.Generic;

namespace BA.Airline.Common.Viewer
{
    interface IViewer<T>
    {
        void PrintTable(List<T> flights);
    }
}

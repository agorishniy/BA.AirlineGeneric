using BA.Airline.Common.Flight;
using BA.Airline.Common.Viewer;

namespace BA.Airline.Flights
{
    public class FlightsViewer : Viewer<IFlight>
    {
        protected override string GetOutputRow(IFlight element, int index)
        {
            return element.ToString(HeaderColumLength);
        }
        protected override void SetDataOfHeader()
        {
            HeaderNames = new[] { "Time", "Direction", "Number", "City", "Terminal", "Status", "Gate" };
            HeaderColumLength = new[] { 16, 9, 6, 23, 8, 10, 4 };
        }
    }
}

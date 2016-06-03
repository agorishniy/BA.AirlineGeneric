using BA.Airline.Common.Passenger;
using BA.Airline.Common.Viewer;

namespace BA.Airline.Passengers
{
    public class PassengersViewer:Viewer<IPassenger>
    {
        protected override string GetOutputRow(IPassenger element, int index)
        {
            return element.ToString(HeaderColumLength, index + 1);
        }

        protected override void SetDataOfHeader()
        {
            HeaderNames = new[] { "#", "Name", "Nationality", "Passp.", "Birthday", "Sex", "Price", "Class" };
            HeaderColumLength = new[] { 3, 19, 11, 8, 10, 3, 10, 9 };
        }
    }
}

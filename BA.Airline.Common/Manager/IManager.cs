using System.Collections.Generic;

namespace BA.Airline.Common.Manager
{
    public interface IManager<T>
    {
        void Add(List<T> arr);
        void Edit(List<T> arr);
        void Delete(List<T> arr);
        //void Sort(List<T> arr);
    }
}

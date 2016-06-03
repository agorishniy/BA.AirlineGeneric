using System;
using System.Collections.Generic;

namespace BA.Airline.Common.Manager
{
    public abstract class Manager<T> : IManager<T>
    {
        public abstract void Add(List<T> arr);
        public abstract void Edit(List<T> arr);
        public abstract void Delete(List<T> arr);
    }
}

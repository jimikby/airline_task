using System.Collections.Generic;
using Airline.entity;

namespace Airline.repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Write(T objectToWrite);
        List<T> Read();
    }
}

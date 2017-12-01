using System.Collections.Generic;
using Airline.entity;

namespace Airline.serivce
{
    public interface IService<T> where T : IEntity
    {
        void Write(T objectToWrite);
        List<T> Read();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;

namespace Airline.repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Write(T objectToWrite);
        List<T> Read();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;
using Airline.repository;

namespace Airline.serivce
{
    public class FlightService : IService<Plane>
    {
        public FlightService(IRepository<Plane> repository)
        {
            Repository = repository;
        }

        private IRepository<Plane> Repository { get; }

        public void Write(Plane plane)
        {
            Repository.Write(plane);
        }

        public List<Plane> Read()
        {
            return Repository.Read();
        }
    }
}

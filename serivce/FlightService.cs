using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;
using Airline.repository;

namespace Airline.serivce
{
    internal class FlightService : IService<Flight>
    {
        public FlightService(IRepository<Flight> repository)
        {
            Repository = repository;
        }

        private IRepository<Flight> Repository { get; }

        public void SaveState()
        {
            Repository.SaveState();
        }

        public Flight LoadState()
        {
            return Repository.LoadState();
        }
    }
}

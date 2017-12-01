using System.Collections.Generic;
using Airline.entity;
using Airline.repository;

namespace Airline.serivce
{
    public class PlaneService : IService<Plane>
    {
        public PlaneService(IRepository<Plane> repository)
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

using System.Collections.Generic;
using Airline.entity;

namespace Airline.controller
{
    public interface IController
    {
        void StartFlight();
        List<Plane> GetPlanes();
    }  
}

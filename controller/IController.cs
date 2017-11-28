using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;

namespace Airline.controller
{
    public interface IController
    {
        void StartFlight();
        List<Plane> GetPlanes();
    }  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.entity;

namespace Airline.controller
{
    internal interface IController
    {
        void StartPlane(Plane plane);
        Flight TakeFlight(Plane plane);
        void SaveFlight(Flight fight);
    }  
}

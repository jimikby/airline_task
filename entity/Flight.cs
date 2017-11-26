using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.entity
{
    internal class Flight : IEntity
    {
        public Plane Plane { get; set;} 
        public int Altitude { get; set; }
        public int Course { get; set; }
    }
}

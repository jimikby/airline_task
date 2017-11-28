using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Airline.app;
using Airline.repository;

namespace Airline.entity
{
    [Serializable]
    public class Plane : IEntity
    {
        private const double MinDistance = 40;
        private const double MaxDistance = 800;
        private const double MaxAltitude = 10000;

        public PlaneRepository Repository { get; set; }

        public static Random Rand { get; } = new Random();

        public int Uid { get; set; }
        public double Speed { get; set; }
        public double Altitude { get; set; }
        public double Distance { get; set; }
        public double FlightDistance { get; set; }
        public int TimeOfFligh { get; set; }

        public Plane()
        {
        }

        public void Fly()
        {
            Uid = Thread.CurrentThread.GetHashCode();
            Altitude = 0;
            FlightDistance = Rand.Next((int)MinDistance, (int)MaxDistance);
            TimeOfFligh = 0;
            Repository = new PlaneRepository(AppConfig.PlanesFolder + Uid + ".txt", true);
            Distance = FlightDistance;
            Speed = 2;
            var distc = FlightDistance / 200;
            while (Distance > 0)
            {
                TimeOfFligh++;
                Distance -= Speed;
                Altitude = -Math.Pow(((FlightDistance - Distance) / distc) - 100, 2) + MaxAltitude;

                Thread.Sleep(200);

                if (TimeOfFligh % 10 == 0)
                {
                    Repository.Write(this);
                }
            }
            File.Delete(AppConfig.PlanesFolder + Uid + ".txt");
        }
    }
}

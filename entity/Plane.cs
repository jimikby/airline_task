using System;
using System.IO;
using System.Threading;
using Airline.app;
using Airline.repository;
using Airline.serivce;

namespace Airline.entity
{
    [Serializable]
    public class Plane : IEntity
    {
        private const double MinDistance = 40;
        private const double MaxDistance = 800;
        private const double MaxAltitude = 10000;

        private PlaneService Service { get; set; }

        private static Random Rand { get; } = new Random();

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
            Service = new PlaneService(new PlaneRepository(AppConfig.PlanesFolder + Uid + ".txt", true));
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
                    Service.Write(this);
                }
            }
            File.Delete(AppConfig.PlanesFolder + Uid + ".txt");
        }
    }
}

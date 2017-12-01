using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Airline.app;
using Airline.entity;
using Airline.repository;

namespace Airline.controller
{
    public class PlaneController : IController
    {
        public void StartFlight()
        {
            new Thread(new Plane().Fly).Start();
        }

        public List<Plane> GetPlanes()
        {
            var files = Directory.GetFiles(AppConfig.PlanesFolder);
            return (from file in files select new PlaneRepository(file, false).Read() into planes1 where planes1 != null select planes1[planes1.Count - 1]).ToList();
        }
    }
}

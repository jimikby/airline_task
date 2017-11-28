using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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
            var planes = new List<Plane>();
            foreach (var file in files)
            {
                var planes1 = new PlaneRepository(file, false).Read();
                if (planes1 != null)
                {
                    planes.Add(planes1[planes1.Count - 1]);
                }
            }
            return planes;
        }
    }
}

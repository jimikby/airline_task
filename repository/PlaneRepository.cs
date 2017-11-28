using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;
using Airline.entity;

namespace Airline.repository
{
    public class PlaneRepository : IRepository<Plane>
    {
        private readonly string _filePath;
        private readonly EventWaitHandle _waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        public PlaneRepository(string filePath, bool clean)
        {
            _filePath = filePath;
            if (clean || !File.Exists(_filePath)) Clean();
        }

        public PlaneRepository()
        {
        }

        public void Write(Plane objectToWrite)
        {
            var planes = Read() ?? new List<Plane>();
            planes.Add(objectToWrite);
            var contentsToWriteToFile = new JavaScriptSerializer().Serialize(planes);
            PerformAction("Write", contentsToWriteToFile);

        }

        public List<Plane> Read()
        {    
           return PerformAction("Read", null);
        }

        private List<Plane> PerformAction(string actionName,string contentsToWriteToFile)
        {
            _waitHandle.WaitOne();
            switch (actionName)
            {
                case "Read":
                    {
                        var planes = new JavaScriptSerializer().Deserialize<List<Plane>>(File.ReadAllText(_filePath));
                        _waitHandle.Set();
                        return planes;
                    }
                case "Write":
                    {
                        TextWriter writer = null;
                        try
                        {
                            writer = new StreamWriter(_filePath, false);
                            writer.Write(contentsToWriteToFile);
                        }
                        finally
                        {
                            writer?.Close();
                        }
                        _waitHandle.Set();
                        return null;
                    }
                default:
                    _waitHandle.Set();
                    return null;
            }
        }

        public void Clean()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
            using (File.Create(_filePath))
            {
            };
        }

    }
}

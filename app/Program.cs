using System;
using System.IO;
using System.Windows.Forms;
using Airline.controller;

namespace Airline.app
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var di = new DirectoryInfo(AppConfig.PlanesFolder);
            foreach (var file in di.GetFiles())
            {
                file.Delete();
            }
            Application.Run(new AirlineForm(new PlaneController()));
        }
    }
}

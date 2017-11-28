using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Airline.controller;
using Airline.entity;

namespace Airline.app
{
    public static class Program
    {
        [STAThread]
        static void Main()
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

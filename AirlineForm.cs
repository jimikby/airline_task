using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Airline.controller;
using Airline.entity;

namespace Airline
{
    public partial class AirlineForm : Form
    {
        public IController Controller { get; }

        public AirlineForm(IController controller)
        {
            Controller = controller;
            InitializeComponent();
        }


        private void AirlineForm_Load_1(object sender, EventArgs e)
        {
            var timer = new Timer { Interval = (200) };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.StartFlight();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var planes = Controller.GetPlanes();
            var aBrush = Brushes.NavajoWhite;
            var bBrush = Brushes.Coral;
            var g = CreateGraphics();
            g.Clear(Color.Black);
            foreach (var plane in planes)
            {

                g.FillEllipse(aBrush, (int)(plane.FlightDistance - plane.Distance),
                      500 - (int)(plane.Altitude / 40), 15, 15);

                for (var i = 0; i < plane.Uid; i++)
                {
                    g.FillEllipse(bBrush, (int) (plane.FlightDistance - plane.Distance)+(6*i),
                        496 - (int) (plane.Altitude / 40), 4, 3);
                }
                Debug.WriteLine(plane.Distance);
            }
        }
    }
}

using EastyForms.ScreenItem.Implementation;
using EastyForms.ScreenItem.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace EastyForms
{
    public partial class Form1 : Form
    {
        //private Graphics _graphics;
        private List<IScreenItem> _screenItems;
        private System.Timers.Timer _timer;

        public Form1()
        {
            InitializeComponent();

            _screenItems = new List<IScreenItem>();

            _screenItems.Add(new Froggy(new Size(64, 64), new Point(0, 0), this.panel1));
            _screenItems.Add(new Froggy(new Size(64, 64), new Point(0, 64), this.panel1));
            _screenItems.Add(new Froggy(new Size(64, 64), new Point(64, 0), this.panel1));
            _screenItems.Add(new Froggy(new Size(64, 64), new Point(64, 64), this.panel1));

            _screenItems.Add(new Doggo(new Size(64, 64), new Point(200, 200), this.panel1));
            _screenItems.Add(new Doggo(new Size(64, 64), new Point(200, 264), this.panel1));
            _screenItems.Add(new Doggo(new Size(64, 64), new Point(264, 200), this.panel1));
            _screenItems.Add(new Doggo(new Size(64, 64), new Point(264, 264), this.panel1));

            //Task.Run(() => StartLoop() );
        }

        //Calls the Tick() method on all of the implementations of IScreenItem
        public void Tick(Object sender, ElapsedEventArgs e)
        {
            //Stops the timer while running the code, prevents the application from hanging
            _timer.Stop();

            foreach(IScreenItem item in _screenItems)
            {
                item.Tick(this.panel1);
            }

            //Restarts the timer to be able to continue calling the ticks
            _timer.Start();
        }

        //Starts a timer to call the Tick() method once every 1000/60 ms
        private void StartLoop()
        {
            if(_timer == null)
            {
                _timer = new System.Timers.Timer();
                _timer.SynchronizingObject = this;
                _timer.Interval = 1000 / 60;
                _timer.Elapsed += Tick;
            }
            
            _timer.Start();
        }

        private void StopLoop()
        {
            _timer.Stop();
        }

        //Method called when pressing the start button
        private void button1_Click(object sender, EventArgs e)
        {
            StartLoop();
        }

        //Method called when pressing the stop button
        private void button2_Click(object sender, EventArgs e)
        {
            StopLoop();
        }
    }
}

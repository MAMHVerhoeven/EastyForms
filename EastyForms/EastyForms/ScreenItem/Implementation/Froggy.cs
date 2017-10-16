using EastyForms.ScreenItem.Enumeration;
using EastyForms.ScreenItem.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EastyForms.ScreenItem.Implementation
{
    class Froggy : IScreenItem
    {
        private PictureBox _box;
        
        private Heading _heading;
        private int _step = 5;

        public Froggy(Size size, Point location, Panel panel)
        {
            _heading = Heading.RIGHT;

            Bitmap image = new Bitmap(Properties.Resources.FrogImage);

            _box = new PictureBox();

            _box.Image = image;
            _box.Size = size;
            _box.Location = location;


            panel.Controls.Add(_box);
        }

        public void Tick(Panel panel)
        {
            if(_heading == Heading.LEFT)
            {
                if(_box.Location.X < 0)
                {
                    _heading = Heading.RIGHT;
                    _box.Location = new Point(_box.Location.X + _step, _box.Location.Y);
                }
                else
                {
                    _box.Location = new Point(_box.Location.X - _step, _box.Location.Y);
                }
            }
            else
            {
                if (_box.Location.X + _box.Size.Width > panel.Width)
                {
                    _heading = Heading.LEFT;
                    _box.Location = new Point(_box.Location.X - _step, _box.Location.Y);
                }
                else
                {
                    _box.Location = new Point(_box.Location.X + _step, _box.Location.Y);
                }
            }

            //panel.Controls.Add(box);
            Console.WriteLine("Froggy does tick!");
        }
    }
}

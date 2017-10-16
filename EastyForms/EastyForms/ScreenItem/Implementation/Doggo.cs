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
    class Doggo : IScreenItem
    {
        private PictureBox _box;

        private Heading _heading;
        private int _step = 5;

        public Doggo(Size size, Point location, Panel panel)
        {
            _heading = Heading.UP;

            Bitmap image = new Bitmap(Properties.Resources.DogImage);

            _box = new PictureBox();

            _box.Image = image;
            _box.Size = size;
            _box.Location = location;


            panel.Controls.Add(_box);
        }

        public void Tick(Panel panel)
        {
            if (_heading == Heading.UP)
            {
                if (_box.Location.Y < 0)
                {
                    _heading = Heading.DOWN;
                    _box.Location = new Point(_box.Location.X, _box.Location.Y + _step);
                }
                else
                {
                    _box.Location = new Point(_box.Location.X, _box.Location.Y - _step);
                }
            }
            else
            {
                if (_box.Location.Y + _box.Size.Height > panel.Height)
                {
                    _heading = Heading.UP;
                    _box.Location = new Point(_box.Location.X, _box.Location.Y - _step);
                }
                else
                {
                    _box.Location = new Point(_box.Location.X, _box.Location.Y + _step);
                }
            }
        }
    }
}

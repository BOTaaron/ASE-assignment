using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    public abstract class Shape
    {
        // base class for future shapes, taking graphics object and location to create the shape as parameters
        public abstract void Draw(Graphics graphics, Pen pen, int x, int y);
    }
}

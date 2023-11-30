using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Circle : Shape
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        // overrides the draw method in the Shape class, with x and y parameters the current cursor location
        // takes radius as a single parameter from user input
        public override void Draw(Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(Pens.Black, x - Radius, y - Radius, Radius * 2, Radius * 2);
        }
    }
}

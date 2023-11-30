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

        public override void Draw(Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(Pens.Black, x - Radius, y - Radius, Radius * 2, Radius * 2);
        }
    }
}

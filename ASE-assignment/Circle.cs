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
        public override void Draw(Graphics graphics, Pen pen, int x, int y)
        {
            // depending on the value of shapeFill, draw either a solid or drawn shape
            if (ShapeFill)
            {
                Fill(graphics, new SolidBrush(pen.Color), x, y);
            }
            else
            {
                graphics.DrawEllipse(pen, x - Radius, y - Radius, Radius * 2, Radius * 2);
            }
            
        }
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillEllipse(brush, x - Radius, y - Radius,Radius * 2, Radius * 2);
        }
    }
}

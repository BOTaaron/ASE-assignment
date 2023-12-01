using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Rectangle : Shape
    {

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
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
            graphics.DrawRectangle(pen, x - Width / 2, y - Height / 2, Width, Height);
            }

        }
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillRectangle(brush, x - Width / 2, y - Height / (Width / 2), Width, Height);
        }
    }
}

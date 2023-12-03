using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Circle class that extends the Shape class to draw a circle onto a canvass.
    /// </summary>
    internal class Circle : Shape
    {
        public int Radius { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius">Sets the radius of the circle to be drawn</param>
        public Circle(int radius)
        {
            Radius = radius;
        }

        // overrides the draw method in the Shape class, with x and y parameters the current cursor location
        // takes radius as a single parameter from user input
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics">The image to draw onto</param>
        /// <param name="pen">The pen used to draw hollow shapes</param>
        /// <param name="x">The x (left and right) coordinate to draw on the bitmap</param>
        /// <param name="y">The y (up and down) coordinate to draw on the bitmap</param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics">The image to draw onto</param>
        /// <param name="brush">The brush used to draw solid shapes</param>
        /// <param name="x">The x (left and right) coordinate to draw on the bitmap</param>
        /// <param name="y">The y (up and down) coordinate to draw on the bitmap</param>
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillEllipse(brush, x - Radius, y - Radius,Radius * 2, Radius * 2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Triangle class that extends the shape class to draw a equilateral triangle onto the canvass
    /// </summary>
    public class Triangle : Shape
    {
        public int Sides { get; private set; }

        /// <summary>
        /// Draws an equilateral triangle with all sides the same length onto the canvass
        /// </summary>
        /// <param name="sidesLength">The length of each side of the triangle</param>
        public Triangle(int sidesLength)
        {
            Sides = sidesLength;
        }
        /// <summary>
        /// Draw an outline of a triangle using the formula for an equilateral triangle height
        /// sides × √3 / 2 calculated using Pythagoras theorem.
        /// </summary>
        /// <param name="graphics">The image to draw onto</param>
        /// <param name="pen">The pen used to draw hollow shapes</param>
        /// <param name="x">The x (left and right) coordinate to draw on the bitmap</param>
        /// <param name="y">The y (up and down) coordinate to draw on the bitmap</param>
        public override void Draw(Graphics graphics, Pen pen, int x, int y)
        {
            double height = (Math.Sqrt(3) / 2) * Sides;

            Point vertex1 = new Point(x, y - (int)(height / 2));
            Point vertex2 = new Point(x - Sides / 2, y + (int)(height / 2));
            Point vertex3 = new Point(x + Sides / 2, y + (int)(height / 2));

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(new Point[] {vertex1, vertex2, vertex3 });
                graphics.DrawPath(pen, path);
            }

        }
        /// <summary>
        /// Draw an outline of a triangle using the formula for an equilateral triangle height
        /// sides × √3 / 2 calculated using Pythagoras theorem.
        /// </summary>
        /// <param name="graphics">The image to draw onto</param>
        /// <param name="brush">The brush used to draw solid shapes</param>
        /// <param name="x">The x (left and right) coordinate to draw on the bitmap</param>
        /// <param name="y">The y (up and down) coordinate to draw on the bitmap</param>
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            double height = (Math.Sqrt(3) / 2) * Sides;

            Point vertex1 = new Point(x, y - (int)(height / 2));
            Point vertex2 = new Point(x - Sides / 2, y + (int)(height / 2));
            Point vertex3 = new Point(x + Sides / 2, y + (int)(height / 2));

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(new Point[] { vertex1, vertex2, vertex3 });
                graphics.FillPath(brush, path);
            }
        }
    }
}

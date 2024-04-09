using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class CustomShape : Shape
    {
        public int Sides { get; private set; }
        public int Size { get; private set; }
        /// <summary>
        /// Draws a custom shape defined by the user, in a circular shape but with a custom number of sides
        /// for example 6 sides for a hexagon, 8 sides for a octagon, etc
        /// </summary>
        /// <param name="size">The size of the polygon</param>
        /// <param name="sides">The number of sides, between 3 and 10</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception if user defines more than 10 sides or less than 3</exception>
        public CustomShape(int size, int sides)
        {
            if (sides < 3 || sides > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(sides), "Sides must be between 3 and 10.");
            }

            Size = size;
            Sides = sides;
        }
        /// <summary>
        /// Draw a hollow shape on the bitmap
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="pen">The pen that draws the shape</param>
        /// <param name="x">the x location of the shape to draw</param>
        /// <param name="y">the y location of the shape to draw</param>
        public override void Draw(Graphics graphics, Pen pen, int x, int y)
        {
            // Calculate vertices of the polygon
            Point[] vertices = CalculateVertices(x, y, Size, Sides);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(vertices);
                graphics.DrawPath(pen, path);
            }
        }
        /// <summary>
        /// Draw a solid shape on the bitmap
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="brush">The brush that draws the solid shape</param>
        /// <param name="x">the x location of the shape to draw</param>
        /// <param name="y">the y location of the shame to draw</param>
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            // Calculate vertices of the polygon
            Point[] vertices = CalculateVertices(x, y, Size, Sides);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(vertices);
                graphics.FillPath(brush, path);
            }
        }
        /// <summary>
        /// Calculate the structure of the polygon
        /// </summary>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="size">size of the polygon</param>
        /// <param name="sides">number of sides to the polygon</param>
        /// <returns>returns the array of vertices</returns>
        private Point[] CalculateVertices(int centerX, int centerY, int size, int sides)
        {
            // array to hold the points of the polygon
            Point[] vertices = new Point[sides];
            for (int i = 0; i < sides; i++)
            {
                // calculate the angle for the vertex proportionate to the number of sides. Use 2*PI to represent a circle and divide by the number of sides.
                // adjust x coordinate by cosine of the angle multiplied by size. 
                double angle = 2 * Math.PI / sides * i;
                int x = (int)(centerX + size * Math.Cos(angle));
                int y = (int)(centerY + size * Math.Sin(angle));
                vertices[i] = new Point(x, y);
            }
            return vertices;
        }


    }
}

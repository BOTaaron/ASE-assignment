using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Extends the Shape class to draw a rectangle on the canvass
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Accessors for getting/setting the width of the rectangle
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Accessors for getting/setting the height of the rectangle
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Draw a rectangle using parameters parsed from user input for the size of the shape
        /// </summary>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        /// <summary>
        /// Overrides the draw method in the shape class to draw either a hollow or solid shape onto the bitmap canvass
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="pen">The pen used for drawing</param>
        /// <param name="x">The x (left and right) coordinate to draw the shape from the center point</param>
        /// <param name="y">The y (up and down) coordinate to draw the shape from the center point</param>
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
        /// <summary>
        /// Draws the shape with a solid fill
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="brush">The solid brush used for drawing</param>
        /// <param name="x">The x (left and right) coordinate to draw the shape from the center point</param>
        /// <param name="y">The y (up and down) coordinate to draw the shape from the center point</param>
        public override void Fill(Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillRectangle(brush, x - Width / 2, y - Height / (Width / 2), Width, Height);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    /// <summary>
    /// Defines behaviour for the pen such as position, colour, drawing, and fills. 
    /// </summary>
    internal class PenController
    {  
        public int currentX = 0;
        public int currentY = 0;
        private Canvass canvass;
        private Pen pen;
        private Color penColour;
        private bool shapeFill;
        public Color CurrentPenColor => pen.Color;

        /// <summary>
        /// Default setings for the canvass when the application is launched
        /// </summary>
        /// <param name="canvass">The bitmap canvas that all operations take place on</param>
        public PenController(Canvass canvass)
        {
            this.canvass = canvass;
            // set default pen colour to black
            this.penColour = Color.Black;
            this.pen = new Pen(penColour);
            this.shapeFill = false;
        }
        /// <summary>
        /// Moves the pen from the previous location, represented by currentX and currentY to the new location, represented by a small circle on the bitmap
        /// </summary>
        /// <param name="x">The new x (left/right) coordinate of the pen</param>
        /// <param name="y">The new y (up/down) coordinate of the pen</param>
        public void PositionPen(int x, int y)
        {
            canvass.CursorGraphics.Clear(Color.Transparent);
            canvass.CursorGraphics.DrawEllipse(pen, x - 5, y - 5, 10, 10);
            currentX = x;
            currentY = y;
        }
        /// <summary>
        /// Moves the pen from the previous location, represented by currentX and currentY to the new location represented by a small circle on the bitmap.
        /// Draws a line between the old and new coordinates as it moves
        /// </summary>
        /// <param name="x">The new x (left/right) coordinate of the pen</param>
        /// <param name="y">The new y (left/right) coordinate of the pen</param>
        public void PenDraw(int x, int y)
        {
            canvass.DrawingGraphics.DrawLine(pen, currentX, currentY, x, y); 
            PositionPen(x, y);
            currentX = x;
            currentY = y;    
        }

        /// <summary>
        /// Draws a shape onto the canvass 
        /// </summary>
        /// <param name="shape">The shape to be drawn depending on user ibput</param>
        public void DrawShape(Shape shape)
        {
            shape.ShapeFill = shapeFill;
            shape.Draw(canvass.DrawingGraphics, pen, currentX, currentY);
        }
        /// <summary>
        /// The colour of the pen to be used when drawing on the bitmap
        /// </summary>
        /// <param name="colour">Colour of the pen to be used, depending on user input in the pen command</param>
        public void PenColour(Color colour)
        {
            pen = new Pen(colour);
        }
        /// <summary>
        /// Contains a boolean to set the pen to draw either a solid or hollow shape
        /// </summary>
        /// <param name="fill">Parameter from the pen command to set solid shapes on or off</param>
        public void ShapeFill(bool fill)
        {
            shapeFill = fill;
        }
        
    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    internal class PenController
    {  
        private int currentX = 0;
        private int currentY = 0;
        private readonly Canvass canvass;
        private Pen pen;
        private Color penColour;

        public PenController(Canvass canvass)
        {
            this.canvass = canvass;
            // set default pen colour to black
            this.penColour = Color.Black;
            this.pen = new Pen(penColour);
        }

        public void PositionPen(int x, int y)
        {
            // moves the pen around the bitmap and uses a circle to visually show the location

            canvass.CursorGraphics.Clear(Color.Transparent);
            canvass.CursorGraphics.DrawEllipse(pen, x - 5, y - 5, 10, 10);
            currentX = x;
            currentY = y;          
        }

        public void PenDraw(int x, int y)
        {
            // draw a line and save the updates coordinates to be shared with PositionPen
            canvass.DrawingGraphics.DrawLine(pen, currentX, currentY, x, y); 
            PositionPen(x, y);
            currentX = x;
            currentY = y;    
        }
        // draw a shape onto the canvass with current location of the cursor

        public void DrawShape(Shape shape)
        {
            shape.Draw(canvass.DrawingGraphics, pen, currentX, currentY);
        }
        public void PenColour(Color colour)
        {
            // create new pen that uses colour value from method to define colour of drawing
            pen = new Pen(colour);

            
        }

    }

}

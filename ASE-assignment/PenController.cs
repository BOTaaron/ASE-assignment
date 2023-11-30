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

        public PenController(Canvass canvass)
        {
            this.canvass = canvass;
        }

        public void PositionPen(int x, int y)
        {
            // moves the pen around the bitmap and uses a circle to visually show the location

            canvass.CursorGraphics.Clear(Color.Transparent);
            canvass.CursorGraphics.DrawEllipse(Pens.Black, x - 5, y - 5, 10, 10);
            currentX = x;
            currentY = y;          
        }

        public void PenDraw(int x, int y)
        {
            // draw a line and save the updates coordinates to be shared with PositionPen
            canvass.DrawingGraphics.DrawLine(Pens.Black, currentX, currentY, x, y); 
            PositionPen(x, y);
            currentX = x;
            currentY = y;    
        }
        // draw a shape onto the canvass with current location of the cursor

        public void DrawShape(Shape shape)
        {
            shape.Draw(canvass.DrawingGraphics, currentX, currentY);
        }

    }

}

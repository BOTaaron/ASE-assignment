using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Canvass
    {
        // initialise the bitmaps and graphics 
        private Bitmap drawingCanvass;
        private Bitmap cursorCanvass;
        private Graphics drawingGraphics;
        private Graphics cursorGraphics;

        public Canvass(int width, int height)
        {
            drawingCanvass = new Bitmap(width, height);
            cursorCanvass = new Bitmap(width, height);
            drawingGraphics = Graphics.FromImage(drawingCanvass);
            cursorGraphics = Graphics.FromImage(cursorCanvass);
            
            
            
        }
        public Bitmap CombineCanvass()
        {
            using (Bitmap combined = new Bitmap(drawingCanvass.Width, drawingCanvass.Height)) 
            using (Graphics g = Graphics.FromImage(combined))
            {
                // combine the bitmaps to create a transparent layer that shows only the cursor, 
                // and another bitmap for the drawing
                g.DrawImageUnscaled(drawingCanvass, 0, 0);
                g.DrawImageUnscaled(cursorCanvass, 0, 0);
                return new Bitmap(combined);
            }
            
        }

        public void ClearCanvas()
        {
            // clear both canvases to blank bitmaps
            drawingGraphics.Clear(Color.Gray);
            cursorGraphics.Clear(Color.Transparent);
        }

        public Graphics DrawingGraphics => drawingGraphics;
        public Graphics CursorGraphics => cursorGraphics;
    }
}

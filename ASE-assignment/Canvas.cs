using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Generates the bitmaps used for drawing. Initialises bitmaps outside of local scope and contains 
    /// functions necessary to manipulate them
    /// </summary>
    public class Canvas
    {
        // initialise the bitmaps and graphics 
        private Bitmap drawingCanvass;
        private Bitmap cursorCanvass;
        private Graphics drawingGraphics;
        private Graphics cursorGraphics;
        public Bitmap drawingCanvas { get; set; }

        /// <summary>
        /// Creates the bitmaps and graphics used for drawing inside the 'DrawingPanel' PictureBox control
        /// Takes width and height of the parent contained as parameters to set the bitmap size
        /// </summary>
        /// <param name="width">Width of parent container</param>
        /// <param name="height">Height of parent container</param>
        public Canvas(int width, int height)
        {
            drawingCanvass = new Bitmap(width, height);
            cursorCanvass = new Bitmap(width, height);
            drawingGraphics = Graphics.FromImage(drawingCanvass);
            cursorGraphics = Graphics.FromImage(cursorCanvass);           
        }
        /// <summary>
        /// Combines the transparent bitmap for displaying the cursor with the bitmap used for drawing shapes
        /// allows for drawing without the cursor marking the drawing bitmap so that it may be cleared each time it moves
        /// </summary>
        /// <returns>A combined bitmap to be drawn across in the PictureBox</returns>
        public Bitmap CombineCanvass()
        {
            using (Bitmap combined = new Bitmap(drawingCanvass.Width, drawingCanvass.Height)) 
            using (Graphics g = Graphics.FromImage(combined))
            {             
                g.DrawImageUnscaled(drawingCanvass, 0, 0);
                g.DrawImageUnscaled(cursorCanvass, 0, 0);
                return new Bitmap(combined);
            }
            
        }
        /// <summary>
        /// Clears both bitmaps so that the user can start fresh 
        /// </summary>
        public void ClearCanvas()
        {           
            drawingGraphics.Clear(Color.Gray);
            cursorGraphics.Clear(Color.Transparent);
        }

        /// <summary>
        /// publicly expose the graphics for drawing as a read-only property to be accessed elsewhere in the program 
        /// </summary>
        public Graphics DrawingGraphics => drawingGraphics;
        /// <summary>
        /// publicly expose the graphics for the cursor as a read-only property to be accessed elsewhere in the program
        /// </summary>
        public Graphics CursorGraphics => cursorGraphics;
    }
}

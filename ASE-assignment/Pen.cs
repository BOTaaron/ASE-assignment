using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Pen
    {
        public void PositionPen(Bitmap penCanvass, int x, int y)
        {
            int penSize = 3;

            using (Graphics g = Graphics.FromImage(penCanvass))
            {
                g.Clear(Color.Transparent);
                g.DrawEllipse(Pens.Red, x - penSize / 2, y - penSize / 2, 5, 5);

            }
            
        }

        public Bitmap RefreshCanvass(Bitmap penCanvass, Bitmap drawingCanvass)
        {
            using (Bitmap combinedBitmap = new Bitmap(penCanvass.Width, penCanvass.Height)) 
            using (Graphics g = Graphics.FromImage(penCanvass))
            {
                g.DrawImage(penCanvass, new Point(0,0));
                g.DrawImage(drawingCanvass, new Point(0,0));
            }

            return penCanvass;
        }
    }

}

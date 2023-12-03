using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Base class for shapes, with abstract methods for drawing shapes and solid fills. 
    /// Contains accessor for shapeFill boolean for solid filling the shapes
    /// </summary>
    public abstract class Shape
    {
        
        /// <summary>
        /// Accessor for the boolean to change between pen or brush fill
        /// </summary>
        public bool ShapeFill {  get; set; } = false;
        /// <summary>
        /// Abstract method to draw shape outlines, to be overriden in the class for each specific shape
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="pen">The pen used for drawing on the bitmap</param>
        /// <param name="x">The x (left/right) coordinate to draw the shape</param>
        /// <param name="y">The y (up/down) coordinate to draw the shape</param>
        public abstract void Draw(Graphics graphics, Pen pen, int x, int y);
        /// <summary>
        /// Abstract method to draw solid fill shapes, to be overriden in the class for each specific shape
        /// </summary>
        /// <param name="graphics">The bitmap to draw on</param>
        /// <param name="brush">The brush used for drawing on the bitmap</param>
        /// <param name="x">The x (left/right) coordinate to draw the shape</param>
        /// <param name="y">The y (up/down) coordinate to draw the shape</param>
        public abstract void Fill(Graphics graphics, Brush brush, int x, int y);
    }
}

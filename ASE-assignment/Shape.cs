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
        /// Abstract method to draw shape outlines, to be overriden in the 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public abstract void Draw(Graphics graphics, Pen pen, int x, int y);
        public abstract void Fill(Graphics graphics, Brush brush, int x, int y);
    }
}

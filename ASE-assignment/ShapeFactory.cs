using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Factory method for creating shape objects
    /// </summary>
    internal class ShapeFactory
    {
        /// <summary>
        /// The type of shapes that can be creates
        /// </summary>
        public enum ShapeType
        {
            Circle,
            Rectangle,
            Triangle,
            Custom
        }
        /// <summary>
        /// Create a shape with the specified size from a single parameter
        /// </summary>
        /// <param name="type">The type of shape to create</param>
        /// <param name="parameter">The size parameter for the shape</param>
        /// <returns>A new instance of the specified shape</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid shape is created</exception>
        public static Shape GetShape(ShapeType type, int parameter)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle(parameter);
                case ShapeType.Triangle:
                    return new Triangle(parameter);
                default: throw new ArgumentException("Invalid shape");
            }
        }
        /// <summary>
        /// Create a shape with two parameters for size
        /// </summary>
        /// <param name="type">The type of shape to create</param>
        /// <param name="length">Length of the shape</param>
        /// <param name="width">Width of the shape</param>
        /// <returns>returns a new instance of the specified shape</returns>
        /// <exception cref="ArgumentException">Throws an exception when the wrong parameter is entered</exception>
        public static Shape GetShape(ShapeType type, int length, int width)
        {
            if (type == ShapeType.Rectangle)
            {
                return new Rectangle(length, width);
            }
            else if (type == ShapeType.Custom)
            {
                return new CustomShape(length, width);
            }
            else
            {
                throw new ArgumentException("Invalid parameters");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class ShapeFactory
    {

        public enum ShapeType
        {
            Circle,
            Rectangle,
            Triangle
        }

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

        public static Shape GetShape(ShapeType type, int length, int width)
        {
            if (type == ShapeType.Rectangle)
            {
                return new Rectangle(length, width);
            }
            else
            {
                throw new ArgumentException("Invalid parameters");
            }
        }
    }
}

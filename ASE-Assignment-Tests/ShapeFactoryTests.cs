using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class ShapeFactoryTests
    {
        /// <summary>
        /// Create a circle using the shape factory
        /// </summary>
        [Fact]
        public void GetShape_CreatesCircle_WithSingleParameter()
        {
            // Arrange
            var type = ShapeFactory.ShapeType.Circle;
            int radius = 5;

            // Act
            var shape = ShapeFactory.GetShape(type, radius);

            // Assert
            Assert.IsType<Circle>(shape);
            Assert.Equal(radius, ((Circle)shape).Radius);
        }
        /// <summary>
        /// Create a custom shape with a defined number of sides and size
        /// </summary>
        [Fact]
        public void GetShape_CreatesCustomShape_WithTwoParameters()
        {
            // Arrange
            var type = ShapeFactory.ShapeType.Custom;
            int size = 8;
            int sides = 6; 

            // Act
            var shape = ShapeFactory.GetShape(type, size, sides);

            // Assert
            Assert.IsType<CustomShape>(shape);
            
        }
        /// <summary>
        /// Tests that an exceptrion is thrown when an invalid shape is created
        /// </summary>
        [Fact]
        public void GetShape_ThrowsArgumentException_ForInvalidShape()
        {
            // Arrange
            var invalidType = (ShapeFactory.ShapeType)(-1); 

            // Act & Assert
            Assert.Throws<ArgumentException>(() => ShapeFactory.GetShape(invalidType, 1));
        }
    }
}

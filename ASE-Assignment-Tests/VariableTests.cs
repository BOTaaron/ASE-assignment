using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class VariableTests
    {
        /// <summary>
        /// When creating a variable, test that it can resolve to a value
        /// </summary>
        [Fact]
        public void ResolveVariable_Successfully()
        {
            // Arrange
            var variableManager = new VariableManager();
            var canvas = new Canvas(200, 200); 
            var penController = new PenController(canvas); 
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);

            
            variableManager.DeclareVariable("a=100");

            // Act           
            int resolvedValue = commandProcessor.ResolveParam("a");

            // Assert
            Assert.Equal(100, resolvedValue);
        }
        /// <summary>
        /// Test that expressions work with variables. Create a variable 'count' with a value of 5 and multiply by 10 and save to 'size', then check the value of 'size'
        /// </summary>
        [Fact]
        public void VariableExpressions_Successfully()
        {
            // Arrange
            var variableManager = new VariableManager();
            var canvas = new Canvas(200, 200); // Assuming Canvas is your drawing surface
            var penController = new PenController(canvas); // Assuming PenController manages drawing operations
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);

            variableManager.DeclareVariable("count=5");

            variableManager.DeclareVariable("size=count * 10");

            // Act
            int resolvedValue = commandProcessor.ResolveParam("size");

            // Assert
            Assert.Equal(50, resolvedValue);
        }
    }
}

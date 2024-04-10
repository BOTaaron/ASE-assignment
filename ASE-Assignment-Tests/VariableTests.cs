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
        [Fact]
        public void ResolveParam_ResolvesVariableToIntValue_Successfully()
        {
            // Arrange
            var variableManager = new VariableManager();
            var canvas = new Canvas(200, 200); // Assuming Canvas is your drawing surface
            var penController = new PenController(canvas); // Assuming PenController manages drawing operations
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);

            // First, declare the variable 'a' with a value of 100
            variableManager.DeclareVariable("a=100");

            // Act
            // Use ResolveParam to resolve the variable 'a' to its numeric value
            int resolvedValue = commandProcessor.ResolveParam("a");

            // Assert
            // Verify that 'a' is correctly resolved to 100
            Assert.Equal(100, resolvedValue);
        }
    }
}

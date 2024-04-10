using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class SyntaxCheck
    {
        /// <summary>
        /// Simulate the syntax check by parsing an invalid command and catching the exception. Then, check the exception message has been added to a list that simulates the error log
        /// </summary>
        [Fact]
        public void SyntaxCheck_ShouldGenerateErrorLog_WhenSyntaxErrorOccurs()
        {
            // Arrange
            Canvas canvas = new Canvas(100, 100);
            PenController penController = new PenController(canvas);
            var variableManager = new VariableManager();        
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);
            var parser = new CommandParser(); // Your parser instance

            var errorMessages = new List<string>(); 
            var commands = new List<string> { "invalid command" }; 

            // Act
            foreach (var command in commands)
            {
                try
                {
                    var parsedLine = parser.ParseLine(command);
                    commandProcessor.RunLines(parsedLine);
                }
                catch (Exception ex)
                {
                    errorMessages.Add(ex.Message);
                }
            }

            // Assert
            Assert.NotEmpty(errorMessages); 
        }
    }
}

using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class IfTests
    {
        [Fact]
        public void IfStatement_EvaluatesTrue_Correctly()
        {
            // Arrange
            var variableManager = new VariableManager();
            var canvas = new Canvas(200, 200);
            var penController = new PenController(canvas); 
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);
            var parse = new CommandParser();           
            var parsedLineDeclareA = parse.ParseLine("var a = 5");
            commandProcessor.RunLines(parsedLineDeclareA);
            var parsedLineIf = parse.ParseLine("if a < 10");
            commandProcessor.RunLines(parsedLineIf);
            var parsedLineChangeVariable = parse.ParseLine("var b = 20");
            commandProcessor.RunLines(parsedLineChangeVariable);
            var parsedLineEndIf = parse.ParseLine("endif");
            commandProcessor.RunLines(parsedLineEndIf);

            // Act
            int resolvedValueB = (int)variableManager.GetVariable("b");

            // Assert
            Assert.Equal(20, resolvedValueB);
        }

        [Fact]
        public void IfStatement_EvaluatesFalse_Correctly()
        {
            // Arrange
            var variableManager = new VariableManager();
            var canvas = new Canvas(200, 200);
            var penController = new PenController(canvas);
            var commandProcessor = new CommandProcessor(penController, canvas, variableManager);
            var parse = new CommandParser();
            var parsedLineDeclareA = parse.ParseLine("var a = 15");
            commandProcessor.RunLines(parsedLineDeclareA);
            var parsedLineIf = parse.ParseLine("if a < 10");
            commandProcessor.RunLines(parsedLineIf);
            var parsedLineChangeVariable = parse.ParseLine("var a = 20");
            commandProcessor.RunLines(parsedLineChangeVariable);
            var parsedLineEndIf = parse.ParseLine("endif");
            commandProcessor.RunLines(parsedLineEndIf);

            // Act
            int newA = (int)variableManager.GetVariable("a");

            // Assert
            Assert.Equal(15, newA);
        }

    }
}

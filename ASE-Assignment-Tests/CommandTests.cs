using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASE_assignment;

namespace ASE_Assignment_Tests
{
    public class CommandTests
    {
        /// <summary>
        /// Tests the circle command throws an exception when parameters are incorrectly entered
        /// </summary>
        [Fact]
        public void Circle_InvalidValue()
        {

                Canvas testBitmap = new Canvas(100, 100);
                PenController controller = new PenController(testBitmap);
                CommandParser parse = new CommandParser();
                VariableManager variableManager = new VariableManager();
                CommandProcessor runCommand = new CommandProcessor(controller, testBitmap, variableManager);
            

                // Assert
                var parsedLine = parse.ParseLine("circle 50,50");

                // Act 
                Assert.Throws<SyntaxException>(() => runCommand.RunLines(parsedLine));

        }
        /// <summary>
        /// Tests the rectangle command and throws an exception when parameters are incorrectly entered
        /// </summary>
        [Fact]
        public void Rectangle_InvalidValue()
        {

            Canvas testBitmap = new Canvas(100, 100);
            PenController controller = new PenController(testBitmap);
            CommandParser parse = new CommandParser();
            VariableManager variableManager = new VariableManager();
            CommandProcessor runCommand = new CommandProcessor(controller, testBitmap, variableManager);

            // Assert
            var parsedLine = parse.ParseLine("rectangle invalidVariable,24");

            // Act 
            Assert.Throws<SyntaxException>(() => runCommand.RunLines(parsedLine));

        }
        /// <summary>
        /// Tests the triangle command and throws an exception when parameters are incorrectly entered
        /// </summary>
        [Fact]
        public void Triangle_InvalidValue()
        {

            Canvas testBitmap = new Canvas(100, 100);
            PenController controller = new PenController(testBitmap);
            CommandParser parse = new CommandParser();
            VariableManager variableManager = new VariableManager();
            CommandProcessor runCommand = new CommandProcessor(controller, testBitmap, variableManager);

            // Assert
            var parsedLine = parse.ParseLine("triangle variable");

            // Act 
            Assert.Throws<ArgumentException>(() => runCommand.RunLines(parsedLine));

        }
    }
}

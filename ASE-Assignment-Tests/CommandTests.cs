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

                Canvass testBitmap = new Canvass(100, 100);
                PenController controller = new PenController(testBitmap);
                CommandParser parse = new CommandParser();
                RunCommand runCommand = new RunCommand(controller, testBitmap);

                // Assert
                var parsedLine = parse.ParseLine("circle 50,50");

                // Act 
                Assert.Throws<ArgumentException>(() => runCommand.RunLines(parsedLine));

        }
        /// <summary>
        /// Tests the rectangle command and throws an exception when parameters are incorrectly entered
        /// </summary>
        [Fact]
        public void Rectangle_InvalidValue()
        {

            Canvass testBitmap = new Canvass(100, 100);
            PenController controller = new PenController(testBitmap);
            CommandParser parse = new CommandParser();
            RunCommand runCommand = new RunCommand(controller, testBitmap);

            // Assert
            var parsedLine = parse.ParseLine("rectangle 50,50,100,100");

            // Act 
            Assert.Throws<ArgumentException>(() => runCommand.RunLines(parsedLine));

        }
    }
}

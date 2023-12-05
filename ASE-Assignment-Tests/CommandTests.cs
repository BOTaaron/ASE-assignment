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
        /// Tests that the clear command throws an exception if invalid parameters are entered
        /// </summary>
        [Fact]
        public void CanvassCommand_Test()
        {
            // Arrange
            Canvass testBitmap = new Canvass(100, 100);
            PenController controller = new PenController(testBitmap);
            CommandParser parse = new CommandParser();
            RunCommand runCommand = new RunCommand(controller, testBitmap);

            // Act
            var parsedLine = parse.ParseLine("clear 100");

            // Assert
            Assert.Throws<ArgumentException>(() => runCommand.RunLines(parsedLine));
        }
    }
}

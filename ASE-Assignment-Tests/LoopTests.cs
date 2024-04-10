using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class LoopTests
    {
        [Fact]
        /// <summary>
        /// Tests that the captureCommand flag is correctly set when starting a loop
        /// </summary>
        public void StartLoop_SetsCaptureCommandTrue()
        {
            // Arrange
            var variableManager = new VariableManager();
            var loops = new Loops(variableManager, command => { });

            // Act
            loops.StartLoop("i < 10"); 

            // Assert
            Assert.True(loops.captureCommand);
        }
        /// <summary>
        /// Tests that commands are correctly added to the list when capturing
        /// </summary>
        [Fact]
        public void AddLine_AddsCommandWhenCapturing()
        {
            // Arrange
            var variableManager = new VariableManager();
            Action<Command> dummyExecutor = _ => { };
            var loops = new Loops(variableManager, dummyExecutor);

            loops.StartLoop("i < 10");
            var dummyCommand = new Command(); 

            // Act
            loops.AddLine(dummyCommand);

            // Assert
            Assert.Contains(dummyCommand, loops.commands);
        }
    }
}

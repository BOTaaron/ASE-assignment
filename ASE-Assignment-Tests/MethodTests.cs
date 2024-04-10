using ASE_assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Tests
{
    public class MethodTests
    {
        /// <summary>
        /// Test that a variable value changes when calling the method
        /// </summary>
        [Fact]
        public void MethodExecution_ChangesVariableValue()
        {
            // Arrange
            Canvas testCanvas = new Canvas(100, 100); 
            VariableManager variableManager = new VariableManager();
            PenController penController = new PenController(testCanvas); 
            CommandProcessor commandProcessor = new CommandProcessor(penController, testCanvas, variableManager);
            CommandParser commandParser = new CommandParser(); 

            
            string declareMethodLine = "method testMethod";
            string variableAssignmentLine = "var a = 100";
            string endMethodLine = "endmethod";
            string executeMethodLine = "testMethod";

            // Act 
            commandProcessor.RunLines(commandParser.ParseLine(declareMethodLine));
            commandProcessor.RunLines(commandParser.ParseLine(variableAssignmentLine));
            commandProcessor.RunLines(commandParser.ParseLine(endMethodLine));

            // Before executing the method, 'a' should not exist
            Assert.Throws<KeyNotFoundException>(() => variableManager.GetVariable("a"));

            // Act
            commandProcessor.RunLines(commandParser.ParseLine(executeMethodLine));

            // Assert - Now 'a' should exist and be set to 100
            int resolvedValueA = Convert.ToInt32(variableManager.GetVariable("a"));
            Assert.Equal(100, resolvedValueA);
        }
        /// <summary>
        /// Checks that the variable value does not change value when declaring a method
        /// </summary>
        [Fact]
        public void MethodDeclaration_DoesNotChangeVariableValue()
        {
            // Arrange
            Canvas testCanvas = new Canvas(100, 100);
            VariableManager variableManager = new VariableManager();
            PenController penController = new PenController(testCanvas);
            CommandProcessor commandProcessor = new CommandProcessor(penController, testCanvas, variableManager);
            CommandParser commandParser = new CommandParser();

            
            string preDeclareVariableLine = "var a = 50";
            commandProcessor.RunLines(commandParser.ParseLine(preDeclareVariableLine));

            
            string declareMethodLine = "method testMethod";
            string variableChangeLine = "var a = 100";
            string endMethodLine = "endmethod";

            // Act
            commandProcessor.RunLines(commandParser.ParseLine(declareMethodLine));
            commandProcessor.RunLines(commandParser.ParseLine(variableChangeLine));
            commandProcessor.RunLines(commandParser.ParseLine(endMethodLine));

            // Before executing the method, 'a' should still be 50
            int resolvedValueA = Convert.ToInt32(variableManager.GetVariable("a"));
            Assert.Equal(50, resolvedValueA);

            // Act 
            string executeMethodLine = "testMethod";
            commandProcessor.RunLines(commandParser.ParseLine(executeMethodLine));

            // Assert - Now 'a' should have changed to 100
            resolvedValueA = Convert.ToInt32(variableManager.GetVariable("a"));
            Assert.Equal(100, resolvedValueA);
        }


    }
}

using ASE_assignment;
namespace ASE_Assignment_Tests
{
    public class CommandParserTests
    {
        /// <summary>
        /// Test to ensure the parser correctly handles invalid parameter formats
        /// </summary>
        [Fact]
        public void ParseLine_InvalidParameters()
        {
            // Arrange 
            ASE_assignment.CommandParser parse = new();
            string commandLine = "rectangle 200 100";

            // Act and assert
            Assert.Throws<InvalidOperationException>(() => parse.ParseLine(commandLine));
        }
        /// <summary>
        /// Test to ensure that the parser correctly parses a valid command
        /// </summary>
        [Fact]
        public void ParseLine_ValidInput()
        {
            // Arrange
            ASE_assignment.CommandParser parser = new();
            string commandLine = "drawto 100,150";
            List<string> expectedCommand = new List<string> { "drawto" };
            List<int> expectedParameter = new List<int> { 100, 150 };

            // Act
            Command result = parser.ParseLine(commandLine);

            // Assert
            Assert.Equal(expectedCommand, result.ParsedCommand);
            Assert.Equal(expectedParameter, result.IntParams);
        }
    }
}
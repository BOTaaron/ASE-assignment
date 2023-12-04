
namespace ASE_Assignment_Tests
{
    public class CommandParserTests
    {
        [Fact]
        public void ParseLine_InvalidParameters()
        {
            // Arrange 
            ASE_assignment.CommandParser parse = new();
            string commandLine = "rectangle 200 100";

            // Act and assert
            Assert.Throws<InvalidOperationException>(() => parse.ParseLine(commandLine));
        }
        [Fact]
        public void ParseLine_ParseWhitespace()
        {
            // Arrange
            ASE_assignment.CommandParser parser = new();
            string commandLine = "moveto ten,ten";

            // Act

           // var result = parser.ParseLine(commandLine);

            // Act and assert
            Assert.Throws<FormatException>(() => parser.ParseLine(commandLine));
        }
    }
}
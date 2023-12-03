using ASE_assignment;
using Xunit;
namespace ASE_Assignment_Tests
{
    public class CommandParserTests
    {
        [Fact]
        public void ParseLine_NoInput()
        {
            // Arrange 
            ASE_assignment.CommandParser parse = new();
            string commandLine = "rectangle 200 100";



            // Assert
            Assert.Throws<InvalidOperationException>(() => parse.ParseLine(commandLine));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASE_assignment;

namespace ASE_Assignment_Tests
{
    public class FileManagerTests
    {
        [Fact]
        public void SaveReadFile_Test()
        {
            // Arrange
            FileManager fileManager = new();
            IEnumerable<string> testInput = new[] { "test1", "test2" };
            string path = "test_file.txt";

            // Act
            fileManager.SaveFile(testInput, path);
            string[] fileContent = File.ReadAllLines(path);

            // Assert
            Assert.Equal(testInput, fileContent);
        }
    }
}

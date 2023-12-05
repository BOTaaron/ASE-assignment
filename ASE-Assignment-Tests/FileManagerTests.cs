using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASE_assignment;

namespace ASE_Assignment_Tests
{
    /// <summary>
    /// Tests that a file can be saved and then reads the values to check it matches expected contents
    /// </summary>
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
        /// <summary>
        /// A test to check that text in a .txt file is read correctly. Checks a known file against a List of strings for equality
        /// </summary>
        [Fact]
        public void ReadFile_Test()
        {
            // Arrange
            FileManager fileMananager = new();
            string filePath = "test_read_file.txt";
            var expectedContent = new List<string> { "testvalue 1", "testvalue 2", "pass" };

            // Act
            var result = fileMananager.ReadFile(filePath);

            // Assert
            Assert.Equal(expectedContent, result);
        }
    }


}

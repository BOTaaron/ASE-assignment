using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASE_assignment
{
    /// <summary>
    /// Class that handles behaviour when saving and loading text files
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Loops through lines of text and saves it to the desired file selected in the dialog prompt
        /// </summary>
        /// <param name="userInput">Lines of user input, iterated through and passed in to be saved to a file</param>
        /// <param name="path">The path to save the file, passed in from the dialog box</param>
        public void SaveFile(IEnumerable<string> userInput, string path)
        {           
            // using statement ensures that StreamWriter is disposed when finished with
            using (StreamWriter sr = new StreamWriter(path))
            {
                // iterates through the list of user inputs and writes each line in the path given in the 'path' variable
                foreach (string text in userInput)
                {
                    sr.WriteLine(text);
                }
            }
        }
        /// <summary>
        /// Reads the text in a text file so that it can be inserted into labels and displayed in the form
        /// </summary>
        /// <param name="path">The path of the file to be read</param>
        /// <returns>Returns a list of strings containing each line of user input</returns>
        public List<string> ReadFile(string path)
        {
            // read text inside a file and save it into a List to be returned and displayed using the DisplayFile function
            List<string> commands = new List<string> ();

            using (StreamReader sr = new StreamReader(path))
            {
                string text;
                while ((text = sr.ReadLine()) != null ) 
                {
                    commands.Add(text);
                }
            }
            return commands;
        }
        

        
    }
}

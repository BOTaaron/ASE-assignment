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
    internal class FileManager
    {
        // takes a collection of strings to save user input to a file, and path for save directory and file name
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

        public List<System.Windows.Forms.Label> DisplayFile(string path)
        {
            // call the ReadFile function and pass in the location of the file to be read
            List<string> commands = ReadFile(path);
            List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();
            int position = 0;

            // foreach iterates through the list of lines in the file and adds each one to a label at the line break
            // positions label against left side of panel
            foreach (string command in commands)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                {
                    Text = command,
                    AutoSize = true,
                    Location = new Point(0, position)
                };
                labels.Add(label);
            // position creates the label location directly under the previous one
                position += label.Height;
            }
            

            return labels;
        }

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

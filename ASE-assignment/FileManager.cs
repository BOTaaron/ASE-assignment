using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    internal class FileManager
    {
        public void SaveFile(IEnumerable<string> userInput, string path)
        {
            
            // using statement ensures that StreamWriter is disposed when finished with
            using (StreamWriter sr = new StreamWriter(path))
            {
                  
                foreach (string text in userInput)
                {
                    sr.WriteLine(text);
                }
            }
        }

        public IEnumerable<string> OpenFile(string path)
        {
            List<string> commands = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string text;
                while ((text = sr.ReadLine()) != null)
                {
                    commands.Add(text);
                }

            }

            return commands;
        }
        

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Command
    {
        // accessors for the user input parsed by the CommandParser class
        public List<string> ParsedCommand{ get; set;}
        public List<int> IntParams { get; set; }
        public List<string> StringParam { get; set;}


    }
}

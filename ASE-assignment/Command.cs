using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Command
    {
        public List<string> parsedCommand{ get; set;}
        public List<int> IntParams { get; set; }
        public List<string> StringParam { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Custom exception class to check syntax of commands entered by the user
    /// </summary>
    public class SyntaxException : Exception
    {
        public string Value { get; }
        public SyntaxException(string message, string value)
            : base(message)
        {
            this.Value = value;
        }
    }
}

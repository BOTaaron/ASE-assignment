using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Conditionals
    {
        private VariableManager variableManager;
        private DataTable dataTable = new DataTable();
        // variables to state whether execution is currently inside a conditional block, defaulting to false
        public bool insideConditionalBlock { get; private set; } = false;
        private bool executeBlock = false;

        public Conditionals(VariableManager variableManager)
        {
            this.variableManager = variableManager;
        }

        public void If(string condition)
        {

        }
        public void EndIf()
        {

        }
    }


}

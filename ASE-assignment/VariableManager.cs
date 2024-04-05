using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class VariableManager
    {
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        private DataTable dataTable = new DataTable();

        public void DeclareVariable(string stringParameter)
        {

        }
        private void EvaluateExpression(string expression)
        {
            
        }
        public object GetVariable(string name)
        {
            if (variables.TryGetValue(name, out object value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException($"Variable '{name}' is not declared");
            }
        }
    }
}

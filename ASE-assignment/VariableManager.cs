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

        /// <summary>
        /// Logic for creating a variable and saving it to dictionary along with its value after checking for an expression
        /// </summary>
        /// <param name="stringParameter">The parsed string parameter, passed from CommandParser into CommandProcessor</param>
        /// <exception cref="ArgumentException">Throws exception when variable incorrectly declared</exception>
        public void DeclareVariable(string stringParameter)
        {
            var parts = stringParameter.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid variable declaration");
            }

            string variableName = parts[0].Trim();
            string expression = parts[1].Trim();


            foreach (var variable in variables)
            {
                expression = expression.Replace(variable.Key, variable.Value.ToString());
            }

            object value;
            try
            {
                value = dataTable.Compute(expression, string.Empty);
            }
            catch
            {
                throw new ArgumentException("Expression could not be evaluated");
            }

            variables[variableName] = value;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="expression"></param>
        /// <exception cref="ArgumentException"></exception>
        public void UpdateVariable(string variableName, string expression)
        {
            if (!variables.ContainsKey(variableName))
            {
                throw new ArgumentException($"Variable '{variableName}' does not exist.");
            }

            foreach (var variable in variables)
            {
                expression = expression.Replace(variable.Key, variable.Value.ToString());
            }

            object value;
            try
            {
                value = dataTable.Compute(expression, string.Empty);
            }
            catch
            {
                throw new ArgumentException("Expression could not be evaluated.");
            }

            variables[variableName] = value;
        }
        /// <summary>
        /// Method that publicly returns the variable value
        /// </summary>
        /// <param name="name">The name of the variable of which value is needed</param>
        /// <returns>The value of the provided variable</returns>
        /// <exception cref="KeyNotFoundException">Exception thrown if the variable was not found, like does not exist or spelled wrong</exception>
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
        /// <summary>
        /// Clears stored variables from the dictionary to prevent duplicates when running the code twice
        /// </summary>
        public void ClearVariables()
        {
            variables.Clear();
        }

    }
}

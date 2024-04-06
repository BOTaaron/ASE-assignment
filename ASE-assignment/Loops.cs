using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// 
    /// </summary>
    internal class Loops
    {
        private VariableManager variableManager;
        private DataTable dataTable = new DataTable();

        /// <summary>
        /// Constructor for the Loops class
        /// </summary>
        /// <param name="variableManager">The variable manager that manages the names and values of variables</param>
        public Loops(VariableManager variableManager)
        {
            this.variableManager = variableManager;
        }
        /// <summary>
        /// Evaluates the condition within the loop by iterating over each part and checking the variable exists
        /// </summary>
        /// <param name="condition">The condition for the while loop to run</param>
        /// <returns>A boolean to tell the loop to continue execution</returns>
        /// <exception cref="ArgumentException">Throws an exception if it was now possible to evaluate the expression</exception>
        private bool EvaluateCondition(string condition)
        {
            var parts = condition.Split(new[] { ' ', '+', '-', '*', '/', '<', '>', '=', '!' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                try
                {
                    // get the name of each variable and throw an exception if not found
                    var value = variableManager.GetVariable(part);
                    condition = condition.Replace(part, value.ToString());
                }
                catch
                {
                    throw new ArgumentException("variable parameter not found");
                }
            }

            // try to evaluate the string, throw an exception if unable
            try
            {
                var result = dataTable.Compute(condition, null);
                return Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Failed to evaluate condition: {ex.Message}", ex);
            }
        }
    }
}

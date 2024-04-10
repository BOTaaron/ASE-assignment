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
        private List<Command> commands = new List<Command>();
        public bool captureCommand { get; private set; } = false;
        private string loopCondition;
        private Action<Command> executeCommands;

        /// <summary>
        /// Constructor for the Loops class
        /// </summary>
        /// <param name="variableManager">The variable manager that manages the names and values of variables</param>
        public Loops(VariableManager variableManager, Action<Command> executeCommands)
        {
            this.variableManager = variableManager;
            this.executeCommands = executeCommands;
        }
        /// <summary>
        /// once the loop is started, change the flag to true to capture each line and add to the list
        /// </summary>
        /// <param name="command">The parsed line of commands</param>
        public void StartLoop(string command)
        {
            loopCondition = command;
            commands.Clear();
            captureCommand = true;
           
           
        }
        /// <summary>
        /// Adds each line within the loop body to a list for running later
        /// </summary>
        /// <param name="line">the parsed command line</param>
        public void AddLine(Command line)
        {
            if (captureCommand)
            {
                
                commands.Add(line);                
            }

        }
        /// <summary>
        /// Begin executing the loop until its condition evaluates to true. Commands will be read from the list and ran line by line
        /// </summary>
        /// <exception cref="ArgumentException">Throws an exception if there is no condition to evaluate</exception>
        public void ExecuteLoop()
        {
            if (string.IsNullOrEmpty(loopCondition))
            {
                throw new ArgumentException("Loop condition is not set or is invalid.");
            }
            bool conditionResult = EvaluateCondition(loopCondition);

            while (conditionResult)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    captureCommand = false;
                    executeCommands(commands[i]);
                    captureCommand = true;
                }
                conditionResult = EvaluateCondition(loopCondition);
            }
            commands.Clear();
            loopCondition = null;
            captureCommand = false;
        }

        /// <summary>
        /// Evaluates the condition within the loop by iterating over each part and checking the variable exists
        /// </summary>
        /// <param name="condition">The condition for the while loop to run</param>
        /// <returns>A boolean to tell the loop to continue execution</returns>
        /// <exception cref="ArgumentException">Throws an exception if it was now possible to evaluate the expression</exception>
        private bool EvaluateCondition(string condition)
        {
            var operators = new HashSet<string> { "+", "-", "*", "/", "<", ">", "=", "!" };
            var parts = condition.Split(new[] { ' ', '+', '-', '*', '/', '<', '>', '=', '!' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (decimal.TryParse(part, out _) || operators.Contains(part)) continue;
                try
                {
                    // get the name of each variable and throw an exception if not found
                    var value = variableManager.GetVariable(part);
                    condition = condition.Replace(part, value.ToString());
                }
                catch
                {
                    throw new ArgumentException($"variable parameter {condition} not found");
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

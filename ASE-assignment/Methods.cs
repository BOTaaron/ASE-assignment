using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class Methods
    {
        private VariableManager variableManager;
        private Action<Command> executeCommand;
        private Dictionary<string, List<Command>> methods = new Dictionary<string, List<Command>>();
        private string currentMethodName;
        private bool isCapturing = false;

        /// <summary>
        /// Boolean flag to declare that the method is being captured, inside lines will not run until the method is called
        /// </summary>
        public bool IsCapturing
        {
            get { return isCapturing; }
        }

        public Methods(VariableManager variableManager, Action<Command> executeCommand)
        {
            this.variableManager = variableManager;
            this.executeCommand = executeCommand;
        }

        /// <summary>
        /// Checks a method with the same name does not exist, and creates a list with the name of the method to store method commands
        /// </summary>
        /// <param name="methodName">The name of the method to create</param>
        /// <exception cref="SyntaxException">throws an exception if the method already exists</exception>
        public void MethodDeclaration(string methodName)
        {
            if (methods.ContainsKey(methodName))
            {
                throw new SyntaxException($"A method with the name of {methodName} already exists", methodName);
            }
            currentMethodName = methodName;
            methods[methodName] = new List<Command>(); // Initialize the list of commands for this method
            isCapturing = true;
        }
        /// <summary>
        /// Adds each line between the method declaration and end of method declaration to a list to run later
        /// </summary>
        /// <param name="command">The line of parsed commands</param>
        public void AddCommandToMethod(Command command)
        {
            if (isCapturing && !string.IsNullOrEmpty(currentMethodName))
            {
                methods[currentMethodName].Add(command);
            }
        }
        /// <summary>
        /// Checks whether the command is a method if not found in the list of valid commands by CommandProcessor
        /// </summary>
        /// <param name="methodName">The name of the method to test</param>
        /// <returns>Returns true if the method exists</returns>
        public bool IsMethod(string methodName)
        {
            return methods.ContainsKey(methodName);
        }
        /// <summary>
        /// endmethod command was found, stop capturing lines within the method
        /// </summary>
        public void EndMethodDeclaration()
        {
            currentMethodName = null;
            isCapturing = false;
        }
        /// <summary>
        /// Execute the lines found within the list one by one
        /// </summary>
        /// <param name="methodName">The name of the method to execute</param>
        /// <exception cref="ArgumentException">Throws an exception if the method was not found</exception>
        public void ExecuteMethod(string methodName)
        {
            if (methods.ContainsKey(methodName))
            {
                foreach (var command in methods[methodName])
                {
                    executeCommand(command);
                }
            }
            else
            {
                throw new ArgumentException($"Method '{methodName}' not found");
            }
        }
    }
}

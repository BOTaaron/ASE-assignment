﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    /// <summary>
    /// Class that handles behaviour for the 'if' command, so the user can create conditional statements that only execute when evaluation is true
    /// </summary>
    internal class Conditionals
    {
        private VariableManager variableManager;
        private DataTable dataTable = new DataTable();
        // variables to state whether execution is currently inside a conditional block, defaulting to false
        public bool insideConditionalBlock { get; private set; } = false;
        public bool executeBlock { get; private set; } = false;

        /// <summary>
        /// Constructor for the Conditionals class
        /// </summary>
        /// <param name="variableManager"></param>
        public Conditionals(VariableManager variableManager)
        {
            this.variableManager = variableManager;
        }
        /// <summary>
        /// Removes operators from the string and split at spaces. Uses the DataTable.Compute method to evaluate condition string as a mathematical expression.
        /// Evaluated to a boolean and stored in insideConditionalBlock. 
        /// </summary>
        /// <param name="condition">logical or mathematical expression to be evaluated</param>
        /// <exception cref="ArgumentException">if the condition cannot be evaluated an exception will be thrown</exception>
        public void If(string condition)
        {

            var parts = condition.Split(new[] { ' ', '+', '-', '*', '/', '<', '>', '=', '!' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                try
                {
                    // c
                    object value = variableManager.GetVariable(part);
                    condition = condition.Replace(part, value.ToString());
                }
                catch (KeyNotFoundException)
                {

                }
            }
            try
            {
                executeBlock = Convert.ToBoolean(dataTable.Compute(condition, string.Empty));
                insideConditionalBlock = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to evaluate the condition: " + ex.Message, ex);

            }           
        }
        /// <summary>
        /// Sets the insideConditionBlock flag to false to tell the program the if statement is finished and can continue normal execution
        /// </summary>
        public void EndIf()
        {
            insideConditionalBlock = false;           
        }
    }


}

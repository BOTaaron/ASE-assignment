using System;
using System.Windows.Forms;

namespace ASE_assignment
{
    internal class CommandParser
    {
        
        public void Parser(string commandInput)
        {
            
            bool valid = ValidateSyntax(commandInput);
            if (valid == true)
            {

            }
        }

        public bool ValidateSyntax(string commandInput)
        {

            string[] validCommands = { "moveTo", "drawTo", "clear", "reset", "rectangle", "circle", "triangle", "pen", "fill" };
            bool validation = false;
            if (validation == false)
            {
                MessageBox.Show("Input not recognised, read the documentation for help", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return validation;
        }
    }








}


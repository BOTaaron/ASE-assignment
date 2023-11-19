using System;

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

            return validation;
        }
    }






}


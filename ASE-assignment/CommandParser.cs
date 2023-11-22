using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ASE_assignment
{
    internal class CommandParser
    {

        public void ParseLine(string userInput)
        {  
            // split user input into an array of strings divided by spaces
            string[] line = userInput.Split(' ');

            // first word of the line is to be used as a command, converted to lowercase to prevent user errors
            string command = line[0].ToLower();
            string [] parameters = line.Skip(1).ToArray();
            List<int> intParameters = new List<int>();           

            // check the array is not empty
            if ( line.Length == 0 )
            {
                throw new InvalidOperationException("User input expected");
            }
            else if ( line.Length == 1 )
            {
                switch(command)
                {
                    case "clear":
                       // ClearCanvass();
                        break;
                    case "reset":
                       // ResetPen();
                        break;
                }
            }
            else if ( line.Length == 2 )
            {
                if (command.Equals("fill"))
                {
                    switch(parameters[0])
                    {
                        case "on":
                            //penFill = true; 
                            break;
                        case "off":
                            //penFill = false;
                            break;
                        default:
                            throw new ArgumentException($"Unknown parameter: {parameters[0]}");
                    }
                }
                else if (command.Equals("pen"))
                {
                    switch(parameters[0])
                    {
                        case "red":
                           // PenColour("red");
                            break;
                        case "green":
                           // PenColour("green");
                            break;
                        case "blue":
                           // PenColour("blue");
                            break;
                        default:
                            throw new ArgumentException($"Unknown parameter: {parameters[0]}");
                    }
                }
            }
            else if ( line.Length > 2 ) 
            {
                throw new InvalidOperationException("Too many parameters entered");
            }

        }

    }


        

}


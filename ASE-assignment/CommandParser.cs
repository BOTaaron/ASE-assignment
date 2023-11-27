using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

namespace ASE_assignment
{
    internal class CommandParser
    {

        public Command ParseLine(string userInput)
        {  
            // split user input into an array of strings divided by spaces
            string[] line = userInput.ToLower().Split(' ');

            // first word of the line is to be used as a command, converted to lowercase to prevent user errors

            List<string> command = new List<string>();
            List<int> intParams = new List<int>();
            List<string> stringParams = new List<string>();
             
            // check the array is not empty, else throw an exception
            if ( line.Length == 0 )
            {
                throw new InvalidOperationException("User input expected");
            }
            else if ( line.Length == 1 )
            {
                // if the line array only contains one value, parse it as a command
                command.Add(line[0]);
            }
            else if ( line.Length == 2 )
            {
                command.Add(line[0]);

                if (line[1].Contains(",")) 
                {
                    // if parameters contain a comma delimiter, split at the comma
                    // then, convert to an integer and add them to the appropriate list
                    string[] splitParams = line[1].Split(',');

                    foreach (var param in splitParams)
                    {
                        if (int.TryParse(param, out int integer))
                        {
                            intParams.Add(integer);
                        }
                        else
                        {
                            throw new FormatException($"Invalid format of '{param}'");
                        }
                    }
                    
                } 
                else if (int.TryParse(line[1], out int param))
                {
                    intParams.Add(param);
                }
                else
                {
                    // assume the parameter is a string and add it to a string list
                    stringParams.Add(line[1]);
                }

            }
            else if ( line.Length > 2 ) 
            {
                throw new InvalidOperationException("Too many parameters entered");
            }

            // 
            var parsedCommand = new Command
            {
                ParsedCommand = command,
                IntParams = intParams,
                StringParam = stringParams
            };

            return parsedCommand;

        }

    }


        

}


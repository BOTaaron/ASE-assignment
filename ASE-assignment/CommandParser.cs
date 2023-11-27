﻿using System;
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

           
            // initialise a list to store each part of the line of user input depending on the format of the parameter
            // once parsed, returned and accessed through accessors in Command class
            List<string> command = new List<string>();
            List<int> intParams = new List<int>();
            List<string> stringParams = new List<string>();
             
            // throw an exception if user input is empty
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
                    // statement returns true and runs if parameter is a number, and then gets added to intParams list
                    intParams.Add(param);
                }
                else
                {
                    // assume the parameter is a string and add it to a string list to be checked later
                    stringParams.Add(line[1]);
                }

            }
            else if ( line.Length > 2 ) 
            {
                // command is too long, throw an exception. Can be modified later if processing more complex user inputs
                throw new InvalidOperationException("Too many parameters entered");
            }

            // parsedCommand stores the parsed values and returns them so they can be accessed in the Command class
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


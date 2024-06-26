﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace ASE_assignment
{
    /// <summary>
    /// Parses the command into usable portions. Splits the line at each space and checks the value in each position.
    /// </summary>
    internal class CommandParser
    {

        /// <summary>
        /// Splits the user's input into values and adds it to a list, depending on whether the parameter is a string, integer, or multiple integers
        /// </summary>
        /// <param name="userInput">Line of commands taken from the text box in the form</param>
        /// <returns>Returns a Command object containing three lists, for the command, string parameter, and numberical parameters</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="FormatException"></exception>
        public Command ParseLine(string userInput)
        {

            // removes the line number prefix before parsing each line
            string removedLineNumberInput = userInput.Substring(userInput.IndexOf(':') + 1).Trim();
            // split user input into an array of strings divided by spaces
            string[] line = removedLineNumberInput.Trim().ToLower().Split(' ');

           
            // initialise a list to store each part of the line of user input depending on the format of the parameter
            // once parsed, returned and accessed through accessors in Command class
            List<string> command = new List<string>();
            List<int> intParams = new List<int>();
            List<string> stringParams = new List<string>();
             
            // throw an exception if user input is empty
            if ( line.Length == 0 || line.Equals(""))
            {
                throw new InvalidOperationException("User input expected");
            }
            else if ( line.Length == 1 )
            {
                // if the line array only contains one value, parse it as a command
                command.Add(line[0]);
            }
            else if (line[0] == "method" && line.Length > 1)
            {
                command.Add(line[0]);
                stringParams.Add(line[1]);
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
                            stringParams.Add(param);
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
                bool invalidIntegerParams = line.Skip(1) // Skip the command itself
                    .Any(param => int.TryParse(param, out _)); // Check if any parameter is an integer
                if (line[0] == "var" || line[0] == "if" || line[0] == "while")
                {
                    command.Add(line[0]); // add 'var' or 'if' as the command
                    string expression = string.Join(" ", line.Skip(1)); // rejoin the string's items after removing the command
                    stringParams.Add(expression); // add everything after var to stringParams to be evaluated later
                }
                else if (invalidIntegerParams)
                {
                    throw new InvalidOperationException("Invalid parameter format");
                }
                
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


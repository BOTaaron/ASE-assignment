using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASE_assignment
{
    /// <summary>
    /// Takes the parsed commands as parameters and runs the desired command by calling the correct function
    /// </summary>
    internal class CommandProcessor
    {
        private PenController controller;
        private Canvass canvass;
        private delegate void CommandAction(Command parsedLine);
        private Dictionary<string, CommandAction> validCommands;
        private Conditionals conditionals;
        private VariableManager variableManager;
        private Loops loops;
        
        /// <summary>
        /// Initialise a new instance of the CommandProcessor class
        /// </summary>
        /// <param name="controller">The pen controller, that defines how the pen behaves on the canvas</param>
        /// <param name="canvass">The canvas is the bitmap to be drawn on</param>
        public CommandProcessor(PenController controller, Canvass canvass, VariableManager variableManager)
        {
            this.controller = controller;
            this.canvass = canvass;
            this.variableManager = variableManager;
            conditionals = new Conditionals(variableManager);
            loops = new Loops(variableManager, RunLines);


            validCommands = new Dictionary<string, CommandAction>
            {
                {"moveto", MoveTo},
                {"drawto", DrawTo},
                {"clear", Clear},
                {"reset", Reset},
                {"rectangle", DrawRectangle},
                {"circle", DrawCircle},
                {"triangle", DrawTriangle},
                {"pen" , PenColor},
                {"fill", Fill},
                {"var", Var},
                {"if", If},
                {"endif", EndIf},
                {"while", While}
                // further commands can be added by creating methods and adding to the dictionary
            };
        }

        /// <summary>
        /// Move the pen to the location specified by coordinates in the IntParms
        /// </summary>
        /// <param name="parsedLine">The parsed line containing the command and parameters</param>
        /// <exception cref="ArgumentException">Throws an exception when no coordinates are provided</exception>
        private void MoveTo(Command parsedLine)
        {
            if (parsedLine.IntParams.Count == 2)
            {
                // Positions the pen to the x and y coordinates
                int x = parsedLine.IntParams[0];
                int y = parsedLine.IntParams[1];
                controller.PositionPen(x, y);
            }
            else if (parsedLine.StringParam.Count >= 1)
            {
                // checks if there is a string parameter and tries to resolve it to its variable parameter
                int x = ResolveParam(parsedLine.StringParam.Count > 0 ? parsedLine.StringParam[0] : null);
                int y = ResolveParam(parsedLine.StringParam.Count > 1 ? parsedLine.StringParam[1] : parsedLine.IntParams.Count > 0 ? parsedLine.IntParams[0].ToString() : null);
                controller.PositionPen(x, y);
            }
            else
            {
                throw new SyntaxException($"Not enough arguements provided. MoveTo expects coordinates with a comma delimiter. Provided: {parsedLine.StringParam[0]}", parsedLine.StringParam[0]);
            }

        }
        /// <summary>
        /// Draws a line from the previous location to a new location specified by the coordinates provided
        /// </summary>
        /// <param name="parsedLine">The parsed line containing the command and parameters</param>
        /// <exception cref="ArgumentException">Throws an exception when no coordinates are provided</exception>
        private void DrawTo(Command parsedLine)
        {
            if (parsedLine.IntParams.Count == 2)
            {
                int x = parsedLine.IntParams[0];
                int y = parsedLine.IntParams[1];
                controller.PenDraw(x, y);
            }
            else if (parsedLine.StringParam.Count >= 1)
            {
                // checks if there is a string parameter and tries to resolve it to its variable parameter
                int x = ResolveParam(parsedLine.StringParam.Count > 0 ? parsedLine.StringParam[0] : null);
                int y = ResolveParam(parsedLine.StringParam.Count > 1 ? parsedLine.StringParam[1] : parsedLine.IntParams.Count > 0 ? parsedLine.IntParams[0].ToString() : null);
                controller.PenDraw(x, y);
            }
            else
            {
                throw new SyntaxException($"Not enough arguements provided. DrawTo expects coordinates with a comma delimiter. Provided: {parsedLine.StringParam[0]}", parsedLine.StringParam[0]);
            }

        }
        /// <summary>
        /// Clears the bitmap canvas when the clear command is entered
        /// </summary>
        /// <param name="parsedLine">The parsed line that should contain the clear command</param>
        /// <exception cref="ArgumentException">Throws an exception when clear is combined with an unexpected parameter</exception>
        private void Clear(Command parsedLine)
        {
            if (parsedLine.IntParams.Count == 0 && parsedLine.StringParam.Count == 0)
            {
                canvass.ClearCanvas();
            }
            else
            {

                throw new SyntaxException($"Unexpected parameter entered. Clear takes no parameters.", "");
            }

        }
        /// <summary>
        /// Resets the cursor to the 0,0 coordinate
        /// </summary>
        /// <param name="parsedLine">The parsed line that should contain the reset command</param>
        /// <exception cref="ArgumentException">Throws an exception when reset is combined with an unexpected parameter</exception>
        private void Reset(Command parsedLine)
        {
            if (parsedLine.IntParams.Count == 0 && parsedLine.StringParam.Count == 0)
            {
                controller.PositionPen(0, 0);
            }
            else
            {
                throw new SyntaxException($"Unexpected parameter entered. Reset takes no parameters.", "");
            }

        }
        /// <summary>
        /// Draws a rectangle with a width and height specified by coordinates in IntParams
        /// </summary>
        /// <param name="parsedLine">The parsed line that should contain the rectangle command and a set of coordinates</param>
        /// <exception cref="ArgumentException">Throws an exception if the parameters contain anything aside from two integers</exception>
        private void DrawRectangle(Command parsedLine) 
        {
            if (parsedLine.IntParams.Count == 2)
            {
                controller.DrawShape(new Rectangle(parsedLine.IntParams[0], parsedLine.IntParams[1]));
            }
            else if (parsedLine.StringParam.Count >= 1)
            {
                // checks if there is a string parameter and tries to resolve it to its variable parameter
                int x = ResolveParam(parsedLine.StringParam.Count > 0 ? parsedLine.StringParam[0] : null);
                int y = ResolveParam(parsedLine.StringParam.Count > 1 ? parsedLine.StringParam[1] : parsedLine.IntParams.Count > 0 ? parsedLine.IntParams[0].ToString() : null);
                controller.DrawShape(new Rectangle(x, y));
            }
            else
            {
                throw new SyntaxException($"Invalid parameter entered. Must be either integer coordinates with comma delimiter, or variables", "");
            }

        }
        /// <summary>
        /// Draws a circle from a provided radius
        /// </summary>
        /// <param name="parsedLine">The parsed line that contains the circle command and an integer radius</param>
        /// <exception cref="ArgumentException">Throws an exception if anything but a single integer parameter is provuded</exception>
        private void DrawCircle(Command parsedLine)
        {
            if (parsedLine.IntParams.Count == 1 && parsedLine.StringParam.Count == 0)
            {
                controller.DrawShape(new Circle(parsedLine.IntParams[0]));
            }
            else if (parsedLine.StringParam.Count == 1)               
            {
                string variable = parsedLine.StringParam[0];
                try
                {
                    // if the parameter is a string, check if it matches to a variable and throw exception if not
                    object variableValue = variableManager.GetVariable(variable);
                    if (variableValue is int intValue)
                    {
                        controller.DrawShape(new Circle(intValue));
                    }
                    else
                    {
                        throw new ArgumentException($"Variable '{variable}' is not a single integer value");
                    }
                }
                catch (KeyNotFoundException)
                {
                    throw new ArgumentException($"Variable '{variable}' was not found");
                }

            }
            else
            {
                throw new SyntaxException($"Invalid parameter entered. Must be either integer coordinates with comma delimiter, or variables", "");
            }
        }
        /// <summary>
        /// Creates an equilateral triangle from a provided integer parameter
        /// </summary>
        /// <param name="parsedLine">The parsed line that contains the triangle command and an integer parameter for size</param>
        /// <exception cref="ArgumentException">Throws an exception if any parameter except a single integer is provided</exception>
        private void DrawTriangle(Command parsedLine)
        {
            if (parsedLine.ParsedCommand.Count == 1 && parsedLine.IntParams.Count == 1)
            {
                controller.DrawShape(new Triangle(parsedLine.IntParams[0]));
            }
            else if (parsedLine.StringParam.Count == 1)
            {
                // if the parameter for the triangle is a string, check if it matches a variable and throw an exception if not
                string variable = parsedLine.StringParam[0];
                try
                {
                    object variableValue = variableManager.GetVariable(variable);
                    if (variableValue is int intValue)
                    {
                        controller.DrawShape(new Circle(intValue));
                    }
                    else
                    {
                        throw new ArgumentException($"Variable '{variable}' is not a single integer value");
                    }
                }
                catch (KeyNotFoundException)
                {
                    throw new ArgumentException($"Variable '{variable}' was not found");
                }

            }
            else
            {
                throw new SyntaxException($"Invalid parameter entered. Must be either integer coordinates with comma delimiter, or variables", "");
            }

        }
        /// <summary>
        /// Changes the pen colour based on the parameter colour that was entered
        /// </summary>
        /// <param name="parsedLine">The parsed line that should contain the pen command followed by one of the available colours</param>
        /// <exception cref="ArgumentException">Throws an exception if the colour is not available or the parameter is missing</exception>
        private void PenColor(Command parsedLine)
        {
            if (parsedLine.StringParam.Count > 0)
            {
                var penColour = parsedLine.StringParam[0].ToLower();
                Color colour;
                switch (penColour)
                {
                    case "red":
                        colour = Color.Red;
                        break;
                    case "blue":
                        colour = Color.Blue;
                        break;
                    case "green":
                        colour = Color.Green;
                        break;
                    case "black":
                        colour = Color.Black;
                        break;
                    default:
                       
                        throw new SyntaxException($"Invalid colour. Available: red, blue, green, black. Entered: {parsedLine.StringParam[0]}", parsedLine.StringParam[0]);
                }
                controller.PenColour(colour);
            }
            else
            {
                throw new SyntaxException("Missing colour parameter", "");
            }

        }
        /// <summary>
        /// Enables shape fill to draw solid shapes instead of outlines
        /// </summary>
        /// <param name="parsedLine">The parsed line that contains the fill command followed by 'on' or 'off'</param>
        /// <exception cref="ArgumentException">Throws an exception if an invalid parameter is entered</exception>
        private void Fill(Command parsedLine)
        {
            if (parsedLine.StringParam[0].Equals("on"))
            {
                controller.ShapeFill(true);
            }
            else if (parsedLine.StringParam[0].Equals("off"))
            {
                controller.ShapeFill(false);
            }
            else
            {
                throw new SyntaxException($"Unexpected parameter. Expected on/off. Got: {parsedLine.StringParam[0]}", parsedLine.StringParam[0]);
            }

        }/// <summary>
        /// Calls the If method in the Conditionals class
        /// </summary>
        /// <param name="parsedLine">The parsed line of commands, for the string parameters to be passed in</param>
        private void If(Command parsedLine)
        {

            string stringParam = parsedLine.StringParam[0];
            conditionals.If(stringParam);
            

        }
        /// <summary>
        /// Calls the EndIf method in the Conditionals class
        /// </summary>
        /// <param name="parsedLine">The parsed line of commands, for string parameters to be passed in</param>
        private void EndIf(Command parsedLine)
        {
            conditionals.EndIf();

        }
        /// <summary>
        /// Calls the DeclareVariable method in the VariableManager class to create a new variable
        /// </summary>
        /// <param name="parsedLine"></param>
        private void Var(Command parsedLine)
        {
           string stringParam = parsedLine.StringParam[0];

            variableManager.DeclareVariable(stringParam);

        }
        /// <summary>
        /// Maps valid commands from the validCommands dictionary to their corresponding functions
        /// </summary>
        /// <param name="parsedLine">The parsed line, that contains both a command and the corresponding parameters</param>
        /// <exception cref="ArgumentException">Throws an exception if the command is not found in the validCommand dictionary</exception>
        public void RunLines(Command parsedLine)
        {
            if (parsedLine == null || parsedLine.ParsedCommand.Count == 0)
                throw new SyntaxException($"Command cannot be empty", "");


            string commandName = parsedLine.ParsedCommand[0].ToLower();
            if (commandName == "endloop")
            {
                if (loops.captureCommand)
                {
                    loops.ExecuteLoop();
                    return;
                }
            }

            // Handling direct variable assignment or update
            if (parsedLine.StringParam.Count > 0 && parsedLine.StringParam[0].Contains("=") && !loops.captureCommand)
            {
                string[] parts = parsedLine.StringParam[0].Split('=');
                if (parts.Length == 2)
                {
                    string variableName = parts[0].Trim();
                    string expression = parts[1].Trim();

                    try
                    {
                        // Attempt to get the variable to determine if it needs updating
                        variableManager.GetVariable(variableName);
                        // If no exception is thrown, the variable exists and can be updated
                        variableManager.UpdateVariable(variableName, expression);
                    }
                    catch (KeyNotFoundException)
                    {
                        // Variable does not exist, so declare a new one
                        variableManager.DeclareVariable(parsedLine.StringParam[0]);
                    }
                    return; // Skip further processing
                }
            }


            if (validCommands.TryGetValue(commandName, out CommandAction action) || commandName == "endloop")
            {
                if (commandName == "if" || commandName == "endif")
                {
                    action.Invoke(parsedLine);
                }
                else if (loops.captureCommand && commandName != "while")
                {
                    loops.AddLine(parsedLine);                    
                    return;
                }
                else if (commandName == "endloop")
                {
                    loops.ExecuteLoop();
                    return;
                }
                else if (!conditionals.insideConditionalBlock || conditionals.executeBlock)
                {
                    action.Invoke(parsedLine);
                }            
            }
            else
            {
                throw new ArgumentException($"Unknown command entered: {commandName}");
            }

        }
        /// <summary>
        /// Resolves parameters entered into a command to a variable, eg. when using DrawTo a,100 will match a to the correct value
        /// </summary>
        /// <param name="parameter">The parameters following the command</param>
        /// <returns>An integer value matched to the variable used in parameter</returns>
        /// <exception cref="ArgumentException">Throws exception if the incorrect format of parameter is given</exception>
        private int ResolveParam(string parameter)
        {
            if (parameter == null)
            {
                throw new SyntaxException($"Parameter cannot be null", "");
            }

            if (int.TryParse(parameter, out int param))
            {
                return param;
            }
            try
            {
                object value = variableManager.GetVariable(parameter);
                if (value is int variableValue)
                {
                    return variableValue;
                }
                else
                {
                    throw new SyntaxException($"Variable {parameter} is not an integer", parameter);
                }
            }
            catch (KeyNotFoundException)
            {
                throw new SyntaxException($"Variable {parameter} is not the correct format", parameter);
            }
        }
        public void While(Command parsedLine)
        {


            loops.StartLoop(parsedLine.StringParam[0]);
            
        }
    }
}


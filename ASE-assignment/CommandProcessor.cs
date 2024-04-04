using System;
using System.Collections.Generic;
using System.Drawing;
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

        // Dictionary to map valid commands to their functions
        private Dictionary<string, CommandAction> validCommands;

        /// <summary>
        /// Initialise a new instance of the CommandProcessor class
        /// </summary>
        /// <param name="controller">The pen controller, that defines how the pen behaves on the canvas</param>
        /// <param name="canvass">The canvas is the bitmap to be drawn on</param>
        public CommandProcessor(PenController controller, Canvass canvass)
        {
            this.controller = controller;
            this.canvass = canvass;

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
                {"fill", Fill}
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
                else
                {
                    throw new ArgumentException("Not enough arguements provided");
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
            else
            {
                throw new ArgumentException("Not enough arguements provided");
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
                throw new ArgumentException("Unexpected parameter entered");
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
                throw new ArgumentException("Unexpected parameter entered");
            }

        }
        /// <summary>
        /// Draws a rectangle with a width and height specified by coordinates in IntParams
        /// </summary>
        /// <param name="parsedLine">The parsed line that should contain the rectangle command and a set of coordinates</param>
        /// <exception cref="ArgumentException">Throws an exception if the parameters contain anything aside from two integers</exception>
        private void DrawRectangle(Command parsedLine) 
        {
            if (parsedLine.IntParams.Count == 2 && parsedLine.StringParam.Count == 0)
            {
                controller.DrawShape(new Rectangle(parsedLine.IntParams[0], parsedLine.IntParams[1]));
            }
            else
            {
                throw new ArgumentException("Invalid parameter entered");
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
            else
            {
                throw new ArgumentException("Invalid parameter entered");
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
            else
            {
                throw new ArgumentException("Invalid parameter entered");
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
                        throw new ArgumentException("Invalid colour");
                }
                controller.PenColour(colour);
            }
            else
            {
                throw new ArgumentException("Missing colour parameter");
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
                throw new ArgumentException("Unexpected parameter");
            }

        }
        /// <summary>
        /// Maps valid commands from the validCommands dictionary to their corresponding functions
        /// </summary>
        /// <param name="parsedLine">The parsed line, that contains both a command and the corresponding parameters</param>
        /// <exception cref="ArgumentException">Throws an exception if the command is not found in the validCommand dictionary</exception>
        public void RunLines(Command parsedLine)
        {
            if (parsedLine == null || parsedLine.ParsedCommand.Count == 0)
                throw new ArgumentException("Command cannot be empty");

            string commandName = parsedLine.ParsedCommand[0].ToLower();
            if (validCommands.TryGetValue(commandName, out CommandAction action))
            {
                action.Invoke(parsedLine);
            }
            else
            {
               throw new ArgumentException($"Unknown command entered: {commandName}");
            }
        }
    }
}


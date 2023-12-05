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
    internal class RunCommand
    {
        private PenController controller;
        private Canvass canvass;
        public RunCommand(PenController controller, Canvass canvass)
        {
            this.controller = controller;
            this.canvass = canvass;

        }
        /// <summary>
        /// Takes the parsed line of commands from the accessors in the Command class and call the function depending on the command,
        /// passing in the parameter where necessary. Throws an exception if the value is not valid.
        /// </summary>
        /// <param name="parsedLine">The parsed line of commands from the Command class</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public void RunLines(Command parsedLine)
        {
            // if statements that define behaviour when an expected command is entered
            if (parsedLine.ParsedCommand[0].Equals("moveto"))
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
            else if (parsedLine.ParsedCommand[0].Equals("drawto"))
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
            else if (parsedLine.ParsedCommand[0].Equals("clear"))
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
            else if (parsedLine.ParsedCommand[0].Equals("reset"))
            {
                if (parsedLine.StringParam.Count == 0 && parsedLine.StringParam.Count == 2)
                {
                    controller.PositionPen(0, 0); 
                }
                else
                {
                    throw new ArgumentException("Unexpected parameter entered");
                }
             
            }
            else if (parsedLine.ParsedCommand[0].Equals("rectangle"))
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
            else if (parsedLine.ParsedCommand[0].Equals("circle"))
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
            else if (parsedLine.ParsedCommand[0].Equals("triangle"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("pen"))
            {
                switch(parsedLine.StringParam[0]) 
                {
                    case "red":
                        controller.PenColour(Color.Red);
                        break;
                    case "blue":
                        controller.PenColour(Color.Blue);
                        break;
                    case "green":
                        controller.PenColour(Color.Green);
                        break;
                    case "black":
                        controller.PenColour(Color.Black);
                        break;
                        default: throw new ArgumentException("Invalid colour selected");
                
                }
            }
            else if (parsedLine.ParsedCommand[0].Equals("fill"))
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
            else
            {
                // if command is not from the expected commands, throw an exception (to do later)
                //throw new ArgumentException("Unexpected command entered");
            }

        }
    }
}

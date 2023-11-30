using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class RunCommand
    {
        private PenController controller;
        private Canvass canvass;

        public RunCommand(PenController controller, Canvass canvass)
        {
            this.controller = controller;
            this.canvass = canvass;

        }

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
                canvass.ClearCanvas();

            }
            else if (parsedLine.ParsedCommand[0].Equals("reset"))
            {
                controller.PositionPen(0, 0);
                
            }
            else if (parsedLine.ParsedCommand[0].Equals("run"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("rectangle"))
            {
                controller.DrawShape(new Rectangle(parsedLine.IntParams[0], parsedLine.IntParams[1]));
                
            }
            else if (parsedLine.ParsedCommand[0].Equals("circle"))
            {
                controller.DrawShape(new Circle(parsedLine.IntParams[0]));


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
                
                }
            }
            else if (parsedLine.ParsedCommand[0].Equals("fill"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else
            {
                // if command is not from the expected commands, throw an exception (to do later)
                //throw new NotImplementedException();
            }

        }
    }
}

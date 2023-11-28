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
        Pen penHandler = new Pen();
        public void RunLines(Command parsedLine, Bitmap drawCanvass, Bitmap penCanvass)
        {
            // if statements that define behaviour when an expected command is entered
            if (parsedLine.ParsedCommand[0].Equals("moveto"))
            {

                if (parsedLine.IntParams.Count == 2)
                {
                    int x = parsedLine.IntParams[0];
                    int y = parsedLine.IntParams[1];
                    penHandler.PositionPen(penCanvass, x, y);
                    
                }
                else
                {
                    throw new ArgumentException("Not enough arguements provided");
                }
            }
            else if (parsedLine.ParsedCommand[0].Equals("drawto"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("clear"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("reset"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("run"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("rectangle"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("circle"))
            {
                throw new NotImplementedException("Not implemented");

            }
            else if (parsedLine.ParsedCommand[0].Equals("triangle"))
            {
                throw new NotImplementedException("Not implemented");
            }
            else if (parsedLine.ParsedCommand[0].Equals("pen"))
            {
                throw new NotImplementedException("Not implemented");
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

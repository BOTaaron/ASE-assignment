using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    internal class RunCommand
    {
        public void RunLines(Command parsedLine)
        {
            // if statements that define behaviour when an expected command is entered
            if (parsedLine.ParsedCommand[0].Equals("moveto"))
            {
                

            }
            else if (parsedLine.ParsedCommand.Equals("drawto"))
            {
                throw new NotImplementedException();
            }
            else if (parsedLine.ParsedCommand.Equals("clear"))
            {

            }
            else if (parsedLine.ParsedCommand[0].Equals("reset"))
            {
                Console.WriteLine(parsedLine.ParsedCommand);
                Console.ReadLine();
                throw new ArgumentException("Worked");

            }
            else if (parsedLine.ParsedCommand.Equals("rectangle"))
            {

            }
            else if (parsedLine.ParsedCommand.Equals("circle"))
            {

            }
            else if (parsedLine.ParsedCommand.Equals("triangle"))
            {

            }
            else if (parsedLine.ParsedCommand.Equals("pen"))
            {

            }
            else if (parsedLine.ParsedCommand.Equals("fill"))
            {

            }
            else
            {
                // if command is not from the expected commands, throw an exception (to do later)
                Console.WriteLine(parsedLine.ParsedCommand);
                throw new NotImplementedException();
            }

        }
    }
}

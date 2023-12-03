# ASE Graphical Programming Language

This project is a graphical programming language that allows the user to enter commands into a Windows Form to draw shapes and lines onto a canvass.
The user can enter commands and run them individually with the run button, or type 'run' into the textbox to run all of the commands one after another.

Using the save and load function, all of user input lines can be saved to a text file and loaded later to be ran in the application.

The cursor is represented by a small circle on the bitmap canvass and shapes will be drawn from the cursor with the shape centering over the cursor.

## Commands

**moveto (integer,integer):** Moves the cursor to the coordinates specified by the user

**drawto (integer, integer):** Draws a line from the current cursor location to the coordinates specified by the user

**clear:** Clears the drawing canvass

**reset:** Resets the cursor to the 0,0 position of the canvass

**run:** Runs the commands entered in the left panel, line by line

**rectangle (integer,integer):** Draws a rectangle onto the canvass, using the parameters for width and height

**circle (integer):** Draws a circle onto the canvass, using the integer parameter for the radius of the circle

**pen (red/blue/green/black):** Change the colour of the pen drawing onto the canvass

**fill (on/off):** Fill on to draw solid filled shape, off to draw hollow shape outlines





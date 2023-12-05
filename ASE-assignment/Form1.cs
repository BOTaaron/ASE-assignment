using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    /// <summary>
    /// Create the form for the main application. Contains all the methods for UI functionality such as buttons and panels for displaying the drawing
    /// </summary>
    public partial class Form1 : Form 
    {
        private Canvass canvass;
        private PenController penController;
        private RunCommand runCommand;
        
        /// <summary>
        /// Initialise the form, and create objects required for functionality. Contains event handlers for buttons and set the DrawingPanel image to the combined bitmap 
        /// </summary>
        public Form1()
        {
            
            InitializeComponent();
            canvass = new Canvass(DrawingPanel.Width, DrawingPanel.Height);
            penController = new PenController(canvass);
            runCommand = new RunCommand(penController, canvass);
            DrawingPanel.Image = canvass.CombineCanvass();


            // event handlers for the buttons and text box
            CommandBox.KeyDown += new KeyEventHandler(CommandBox_KeyDown);
            SyntaxButton.Click += new EventHandler(SyntaxButton_Click);
            RunButton.Click += new EventHandler(RunButton_Click);
             
        }
      
        CommandParser parse = new CommandParser();

        /// <summary>
        /// Defines behaviour when the enter/return key is pressed while the textbox is selected. 
        /// If 'run' is entered it will run all of the commands displayed inside the left panel.
        /// If commands are entered it will display them within labels inside the panel
        /// </summary>
        /// <param name="sender">Object that raised the event, in this case TextBox</param>
        /// <param name="e">The event, in this case the Enter/Return key is pressed</param>
        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
           
            // if the user presses enter, call DisplayInput function to place line inside the label for the user to view
            if (e.KeyCode == Keys.Enter)
            {               
                if (CommandBox.Text.ToLower().Equals("run"))
                {
                    RunMultiLines();
                }
                else
                {
                    DisplayInput(CommandBox.Text);
                    CommandBox.Clear();
                }

            }
        }
        /// <summary>
        /// Defines behaviour when the 'run' button is clicked. Parses the command and runs it before refreshing the bitmaps
        /// </summary>
        /// <param name="sender">Object that raised the event, in this case Run button</param>
        /// <param name="e">The event, in this case 'run' button clicked</param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            // Parse the command, and then pass the bitmaps into the RunLines function
            // clears the text box and refreshes the bitmap
            var parsedLine = parse.ParseLine(CommandBox.Text.Trim());
            runCommand.RunLines(parsedLine);
            DrawingPanel.Image = canvass.CombineCanvass();
            DrawingPanel.Refresh();
            CommandBox.Clear();           
        }
        /// <summary>
        /// Iterates through each label contained within the 'CommandPanel', parsing and running each line and refreshing the canvas
        /// </summary>
        private void RunMultiLines()
        {
            foreach (Control control in CommandPanel.Controls)
            {
                if (control is Label label)
                {
                    var parsedLines = parse.ParseLine(label.Text);
                    runCommand.RunLines(parsedLines);
                }
            }
            DrawingPanel.Image = canvass.CombineCanvass();
            DrawingPanel.Refresh();
            CommandBox.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyntaxButton_Click(object sender, EventArgs e)
        {
            // checks syntax is valid when the 'Syntax' button is clicked           
            CommandBox.Clear();
        }


        /// <summary>
        /// Checks that commands are not clearing or infinitely running the program.
        /// Takes user input from the TextBox and adds each line to a label when called, directly below the previous label
        /// </summary>
        /// <param name="line">Text entered by the user into the TextBox when the Enter/Return key is pressed</param>
        private void DisplayInput(string line)
        {
            if (!line.Equals("clear") && !line.Equals("run") && !line.Equals("reset"))
            { 
            Label inputLabel = new Label();
            inputLabel.Text = line;
            CommandPanel.Controls.Add(inputLabel);
            inputLabel.Width = CommandPanel.Width;
            inputLabel.Location = new Point(0, CommandPanel.Controls.Count * inputLabel.Height);                
            }
        }
        /// <summary>
        /// Loop through each label and add the lines to a List. SaveFileDialog prompts user to select a directory
        /// and saves to a directory in a text file when the user clicks 'OK' in the prompt.
        /// </summary>
        /// <param name="sender">The object that raised the event, in this case the 'save' button</param>
        /// <param name="e">The event, in this case the 'save' button being clicked</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();

            // adds text from all labels inside the CommandPanel to a List called userInput
            List<string> userInput = new List<string>();
            string path = null;
            // iterate through all labels in CommandPanel.Controls and add to the userInput list
            foreach (Label textLabels in CommandPanel.Controls)
            {           
                userInput.Add(textLabels.Text);
            }

            // instantiates the SaveFileDIalog class to select a path to save the file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // sets the file name filter so that only text files appear in the option
                sfd.Filter = "txt files (*.txt)|*.txt";
                // restore the directory to the previously selected directory
                sfd.RestoreDirectory = true;

                // when OK is clicked, set the path and filename to save the input
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                     path = sfd.FileName;
                }
                // if cancel is clicked, do nothing
                else 
                {
                    return;
                }
            }
            fileManager.SaveFile(userInput, path);
        }
        /// <summary>
        /// Defines behaviour when the 'open' button is clicked. Calls a dialog box to select the file to open from a list of text files
        /// </summary>
        /// <param name="sender">The object that raised the event, in this case the 'open' button</param>
        /// <param name="e">The event, in this case the button being clicked </param>
         private void OpenButton_Click(object sender, EventArgs e)
         {
            // displays a menu that prompts user to select a file, filtered to .txt files
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt";
                // when user clicks ok in the prompt, displays each line from the file in its own label 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileManager fileManager = new FileManager();
                    List<string> text = fileManager.ReadFile(ofd.FileName);
                    CommandPanel.Controls.Clear();
                    int position = 0;
                    foreach (string line in text)
                    {
                        Label label = new Label
                        {
                            Text = line,
                            AutoSize = true,
                            Location = new Point(0, position)
                        };
                        CommandPanel.Controls.Add(label);
                        position += label.Height;
                    }
                }
            }
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            // adds a scroll bar if the text exceeds the height of the panel
            CommandPanel.AutoScroll = true;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            
        }
    }
}

﻿using System;
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
    public partial class Form1 : Form 
    {
        private Bitmap drawingCanvass;
        private Bitmap errorCanvass;
        private Bitmap penCanvass;
        Pen canvass = new Pen();
        public Form1()
        {
            
            InitializeComponent();
            drawingCanvass = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
            errorCanvass = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
            penCanvass = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
            DrawingPanel.Image = canvass.RefreshCanvass(penCanvass, drawingCanvass);
            // event handlers for the buttons and text box
            CommandBox.KeyDown += new KeyEventHandler(CommandBox_KeyDown);
            SyntaxButton.Click += new EventHandler(SyntaxButton_Click);
            RunButton.Click += new EventHandler(RunButton_Click);

        }

        

        CommandParser parse = new CommandParser();
        RunCommand run = new RunCommand();

        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
           
            // if the user presses enter, call DisplayInput function to place line inside the label for the user to view
            if (e.KeyCode == Keys.Enter)
            {
                parse.ParseLine(CommandBox.Text);
                DisplayInput(CommandBox.Text);
                CommandBox.Clear(); 
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // try to parse the command and run the program when the user clicks the 'Run' button
            var parsedLine = parse.ParseLine(CommandBox.Text);
            run.RunLines(parsedLine, drawingCanvass, penCanvass);
            CommandBox.Clear();
           // DrawingPanel.Refresh();

            
        }
        private void SyntaxButton_Click(object sender, EventArgs e)
        {
            // checks syntax is valid when the 'Syntax' button is clicked           
            CommandBox.Clear();
        }

        private void DisplayInput(string line)
        {
            // Create a label that displays the text the user enters when the enter key is pressed
            // Value is stored in the line variable from the CommandBox.Text input
            // Label width is equal to width of the panel 
            // Point defines the label location, with X (left/right) of 0 and Y (up/down) straight after the previous label 
            // Does not create a label if an empty line is entered

            if (line != "" && !line.Equals("clear") && !line.Equals("run") && !line.Equals("reset"))
            { 
            Label inputLabel = new Label();
            inputLabel.Text = line;
            CommandPanel.Controls.Add(inputLabel);
            inputLabel.Width = CommandPanel.Width;
            inputLabel.Location = new Point(0, CommandPanel.Controls.Count * inputLabel.Height);
                
             }
        }

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
                    List<Label> labels = fileManager.DisplayFile(ofd.FileName);

                    CommandPanel.Controls.Clear();
                    foreach (Label label in labels)
                    {
                        CommandPanel.Controls.Add(label);
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

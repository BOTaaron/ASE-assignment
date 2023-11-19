using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    public partial class Form1 : Form 
    {      
        private int textLocation = 10;
        public Form1()
        {
            
            InitializeComponent();
            // event handlers for the buttons and text box
            CommandBox.KeyUp += new KeyEventHandler(CommandBox_KeyDown);
            SyntaxButton.Click += new EventHandler(SyntaxButton_Click);
            RunButton.Click += new EventHandler(RunButton_Click);
 

            
        }



        CommandParser parse = new CommandParser();


        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
           
            // if the user presses enter, try to parse the command 
            if (e.KeyCode == Keys.Enter)
            {
                parse.Parser(CommandBox.Text);
                DisplayInput(CommandBox.Text);
                CommandBox.Clear();
                
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // try to parse the command and check the syntax when the user clicks the 'Run' button
            parse.Parser(CommandBox.Text);
            CommandBox.Clear();
            
        }

        private void SyntaxButton_Click(object sender, EventArgs e)
        {
            // checks syntax is valid when the 'Syntax' button is clicked
            parse.ValidateSyntax(CommandBox.Text);
            CommandBox.Clear();
        }

        private void DisplayInput(string line)
        {
            //Create a label that displays the text the user enters when the enter key is pressed
            //Value is stored in the line variable from the CommandBox.Text input
            //Label width is equal to width of the panel 
            // Point defines the label location, with X (left/right) of 0 and Y (up/down) straight after the previous label 
            
            if (line != "")
            { 
            Label inputLabel = new Label();
            inputLabel.Text = line;
            CommandPanel.Controls.Add(inputLabel);
            inputLabel.Width = CommandPanel.Width;
            inputLabel.Location = new Point(0, CommandPanel.Controls.Count * inputLabel.Height);
                MessageBox.Show("Invalid Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            CommandPanel.AutoScroll = true;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

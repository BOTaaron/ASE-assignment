namespace ASE_assignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SyntaxButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.CommandPanel = new System.Windows.Forms.Panel();
            this.DrawingPanel = new System.Windows.Forms.PictureBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // SyntaxButton
            // 
            this.SyntaxButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SyntaxButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SyntaxButton.Location = new System.Drawing.Point(384, 848);
            this.SyntaxButton.Name = "SyntaxButton";
            this.SyntaxButton.Size = new System.Drawing.Size(256, 45);
            this.SyntaxButton.TabIndex = 0;
            this.SyntaxButton.Text = "Syntax";
            this.SyntaxButton.UseVisualStyleBackColor = false;
            this.SyntaxButton.Click += new System.EventHandler(this.SyntaxButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(69, 848);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(233, 45);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // CommandBox
            // 
            this.CommandBox.Location = new System.Drawing.Point(69, 757);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(571, 20);
            this.CommandBox.TabIndex = 2;
            this.CommandBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CommandPanel
            // 
            this.CommandPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandPanel.Location = new System.Drawing.Point(41, 39);
            this.CommandPanel.Name = "CommandPanel";
            this.CommandPanel.Size = new System.Drawing.Size(599, 538);
            this.CommandPanel.TabIndex = 5;
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.Color.Gray;
            this.DrawingPanel.Location = new System.Drawing.Point(715, 39);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(784, 640);
            this.DrawingPanel.TabIndex = 6;
            this.DrawingPanel.TabStop = false;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(715, 848);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(256, 45);
            this.OpenButton.TabIndex = 8;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1052, 848);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(256, 45);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1593, 986);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.DrawingPanel);
            this.Controls.Add(this.CommandPanel);
            this.Controls.Add(this.CommandBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.SyntaxButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Graphical Programming Language";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SyntaxButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TextBox CommandBox;
        private System.Windows.Forms.Panel CommandPanel;
        private System.Windows.Forms.PictureBox DrawingPanel;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
    }
}


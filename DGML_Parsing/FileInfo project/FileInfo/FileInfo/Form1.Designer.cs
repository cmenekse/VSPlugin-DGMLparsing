namespace FileInfo
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
            this.browse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Press = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Count = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.typeSelectionBox = new System.Windows.Forms.ComboBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(40, 77);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 0;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Press
            // 
            this.Press.Location = new System.Drawing.Point(171, 77);
            this.Press.Name = "Press";
            this.Press.Size = new System.Drawing.Size(75, 23);
            this.Press.TabIndex = 2;
            this.Press.Text = "Press";
            this.Press.UseVisualStyleBackColor = true;
            this.Press.Click += new System.EventHandler(this.Press_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(366, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(572, 458);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Location = new System.Drawing.Point(409, 12);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(35, 13);
            this.Count.TabIndex = 4;
            this.Count.Text = "Count";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(469, 9);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // typeSelectionBox
            // 
            this.typeSelectionBox.FormattingEnabled = true;
            this.typeSelectionBox.Location = new System.Drawing.Point(92, 165);
            this.typeSelectionBox.Name = "typeSelectionBox";
            this.typeSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.typeSelectionBox.TabIndex = 6;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(112, 217);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 7;
            this.checkButton.Text = "check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 517);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.typeSelectionBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Press);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Press;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox typeSelectionBox;
        private System.Windows.Forms.Button checkButton;
    }
}


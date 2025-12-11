namespace Pilotak
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnF3 = new Button();
            BtnF4 = new Button();
            BtnF5 = new Button();
            BtnF6 = new Button();
            BtnF7 = new Button();
            AnswTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // BtnF3
            // 
            BtnF3.Location = new Point(12, 12);
            BtnF3.Name = "BtnF3";
            BtnF3.Size = new Size(177, 23);
            BtnF3.TabIndex = 0;
            BtnF3.Text = "3. feladat";
            BtnF3.UseVisualStyleBackColor = true;
            BtnF3.Click += BtnF3_Click;
            // 
            // BtnF4
            // 
            BtnF4.Location = new Point(12, 41);
            BtnF4.Name = "BtnF4";
            BtnF4.Size = new Size(177, 23);
            BtnF4.TabIndex = 1;
            BtnF4.Text = "4. feladat";
            BtnF4.UseVisualStyleBackColor = true;
            BtnF4.Click += BtnF4_Click;
            // 
            // BtnF5
            // 
            BtnF5.Location = new Point(12, 70);
            BtnF5.Name = "BtnF5";
            BtnF5.Size = new Size(177, 23);
            BtnF5.TabIndex = 2;
            BtnF5.Text = "5. feladat";
            BtnF5.UseVisualStyleBackColor = true;
            BtnF5.Click += BtnF5_Click;
            // 
            // BtnF6
            // 
            BtnF6.Location = new Point(12, 99);
            BtnF6.Name = "BtnF6";
            BtnF6.Size = new Size(177, 23);
            BtnF6.TabIndex = 3;
            BtnF6.Text = "6. feladat";
            BtnF6.UseVisualStyleBackColor = true;
            BtnF6.Click += BtnF6_Click;
            // 
            // BtnF7
            // 
            BtnF7.Location = new Point(12, 128);
            BtnF7.Name = "BtnF7";
            BtnF7.Size = new Size(177, 23);
            BtnF7.TabIndex = 4;
            BtnF7.Text = "7. feladat";
            BtnF7.UseVisualStyleBackColor = true;
            BtnF7.Click += BtnF7_Click;
            // 
            // AnswTextBox
            // 
            AnswTextBox.Location = new Point(332, 13);
            AnswTextBox.Name = "AnswTextBox";
            AnswTextBox.Size = new Size(456, 354);
            AnswTextBox.TabIndex = 5;
            AnswTextBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AnswTextBox);
            Controls.Add(BtnF7);
            Controls.Add(BtnF6);
            Controls.Add(BtnF5);
            Controls.Add(BtnF4);
            Controls.Add(BtnF3);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnF3;
        private Button BtnF4;
        private Button BtnF5;
        private Button BtnF6;
        private Button BtnF7;
        private RichTextBox AnswTextBox;
    }
}

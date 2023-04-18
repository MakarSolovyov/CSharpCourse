namespace WinFormsApp1
{
    partial class FilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.UpperBoundTextBox = new System.Windows.Forms.TextBox();
            this.LowerBoundTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MotionTypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.FilterButton);
            this.groupBox1.Controls.Add(this.UpperBoundTextBox);
            this.groupBox1.Controls.Add(this.LowerBoundTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MotionTypeCheckedListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(104, 181);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(90, 23);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(6, 181);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(90, 23);
            this.FilterButton.TabIndex = 8;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // UpperBoundTextBox
            // 
            this.UpperBoundTextBox.Location = new System.Drawing.Point(50, 152);
            this.UpperBoundTextBox.Name = "UpperBoundTextBox";
            this.UpperBoundTextBox.Size = new System.Drawing.Size(144, 23);
            this.UpperBoundTextBox.TabIndex = 7;
            // 
            // LowerBoundTextBox
            // 
            this.LowerBoundTextBox.Location = new System.Drawing.Point(50, 123);
            this.LowerBoundTextBox.Name = "LowerBoundTextBox";
            this.LowerBoundTextBox.Size = new System.Drawing.Size(144, 23);
            this.LowerBoundTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coordinate range:";
            // 
            // MotionTypeCheckedListBox
            // 
            this.MotionTypeCheckedListBox.FormattingEnabled = true;
            this.MotionTypeCheckedListBox.Location = new System.Drawing.Point(6, 37);
            this.MotionTypeCheckedListBox.Name = "MotionTypeCheckedListBox";
            this.MotionTypeCheckedListBox.Size = new System.Drawing.Size(188, 58);
            this.MotionTypeCheckedListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Motion type:";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 235);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(1200, 430);
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button ResetButton;
        private Button FilterButton;
        private TextBox UpperBoundTextBox;
        private TextBox LowerBoundTextBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckedListBox MotionTypeCheckedListBox;
        private Label label1;
    }
}
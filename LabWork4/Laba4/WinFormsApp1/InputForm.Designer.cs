namespace WinFormsApp1
{
    partial class InputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxMotionTypes = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.oscilMotionUserControl1 = new WinFormsApp1.OscilMotionUserControl();
            this.uniformAccelMotionUserControl1 = new WinFormsApp1.UniformAccelMotionUserControl();
            this.uniformMotionUserControl1 = new WinFormsApp1.UniformMotionUserControl();
            this.AddRandomObjectButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select motion type:";
            // 
            // ComboBoxMotionTypes
            // 
            this.ComboBoxMotionTypes.FormattingEnabled = true;
            this.ComboBoxMotionTypes.Location = new System.Drawing.Point(12, 27);
            this.ComboBoxMotionTypes.Name = "ComboBoxMotionTypes";
            this.ComboBoxMotionTypes.Size = new System.Drawing.Size(229, 23);
            this.ComboBoxMotionTypes.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.oscilMotionUserControl1);
            this.groupBox1.Controls.Add(this.uniformAccelMotionUserControl1);
            this.groupBox1.Controls.Add(this.uniformMotionUserControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters:";
            // 
            // oscilMotionUserControl1
            // 
            this.oscilMotionUserControl1.Location = new System.Drawing.Point(2, 22);
            this.oscilMotionUserControl1.Name = "oscilMotionUserControl1";
            this.oscilMotionUserControl1.Size = new System.Drawing.Size(224, 237);
            this.oscilMotionUserControl1.TabIndex = 2;
            this.oscilMotionUserControl1.Visible = false;
            // 
            // uniformAccelMotionUserControl1
            // 
            this.uniformAccelMotionUserControl1.Location = new System.Drawing.Point(2, 22);
            this.uniformAccelMotionUserControl1.Name = "uniformAccelMotionUserControl1";
            this.uniformAccelMotionUserControl1.Size = new System.Drawing.Size(224, 237);
            this.uniformAccelMotionUserControl1.TabIndex = 1;
            this.uniformAccelMotionUserControl1.Visible = false;
            // 
            // uniformMotionUserControl1
            // 
            this.uniformMotionUserControl1.Location = new System.Drawing.Point(2, 22);
            this.uniformMotionUserControl1.Name = "uniformMotionUserControl1";
            this.uniformMotionUserControl1.Size = new System.Drawing.Size(224, 237);
            this.uniformMotionUserControl1.TabIndex = 0;
            this.uniformMotionUserControl1.Visible = false;
            // 
            // AddRandomObjectButton
            // 
            this.AddRandomObjectButton.Location = new System.Drawing.Point(12, 332);
            this.AddRandomObjectButton.Name = "AddRandomObjectButton";
            this.AddRandomObjectButton.Size = new System.Drawing.Size(229, 23);
            this.AddRandomObjectButton.TabIndex = 3;
            this.AddRandomObjectButton.Text = "Add a random motion object";
            this.AddRandomObjectButton.UseVisualStyleBackColor = true;
            this.AddRandomObjectButton.Visible = false;
            this.AddRandomObjectButton.Click += new System.EventHandler(this.AddRandomObjectButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 361);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(229, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 390);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(229, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 431);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AddRandomObjectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComboBoxMotionTypes);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(450, 320);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Input";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox ComboBoxMotionTypes;
        private GroupBox groupBox1;
        private Button AddRandomObjectButton;
        private Button OKButton;
        private Button CancelButton;
        private OscilMotionUserControl oscilMotionUserControl1;
        private UniformAccelMotionUserControl uniformAccelMotionUserControl1;
        private UniformMotionUserControl uniformMotionUserControl1;
    }
}
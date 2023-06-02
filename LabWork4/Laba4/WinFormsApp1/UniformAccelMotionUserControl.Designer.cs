namespace WinFormsApp1
{
    partial class UniformAccelMotionUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.initCoordinateValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.speedValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.accelerationValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.initCoordinateValue.Location = new System.Drawing.Point(17, 134);
            this.initCoordinateValue.Name = "textBox3";
            this.initCoordinateValue.Size = new System.Drawing.Size(190, 23);
            this.initCoordinateValue.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Initial coordinate:";
            // 
            // textBox2
            // 
            this.speedValue.Location = new System.Drawing.Point(17, 86);
            this.speedValue.Name = "textBox2";
            this.speedValue.Size = new System.Drawing.Size(190, 23);
            this.speedValue.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Speed:";
            // 
            // textBox1
            // 
            this.timeValue.Location = new System.Drawing.Point(17, 38);
            this.timeValue.Name = "textBox1";
            this.timeValue.Size = new System.Drawing.Size(190, 23);
            this.timeValue.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Acceleration:";
            // 
            // textBox4
            // 
            this.accelerationValue.Location = new System.Drawing.Point(17, 182);
            this.accelerationValue.Name = "textBox4";
            this.accelerationValue.Size = new System.Drawing.Size(190, 23);
            this.accelerationValue.TabIndex = 13;
            // 
            // UniformAccelMotionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.accelerationValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.initCoordinateValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speedValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeValue);
            this.Controls.Add(this.label1);
            this.Name = "UniformAccelMotionUserControl";
            this.Size = new System.Drawing.Size(224, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox initCoordinateValue;
        private Label label3;
        private TextBox speedValue;
        private Label label2;
        private TextBox timeValue;
        private Label label1;
        private Label label4;
        private TextBox accelerationValue;
    }
}

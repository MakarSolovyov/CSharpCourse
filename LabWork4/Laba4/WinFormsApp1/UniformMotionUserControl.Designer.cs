namespace WinFormsApp1
{
    partial class UniformMotionUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.speedValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.initCoordinateValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // textBox1
            // 
            this.timeValue.Location = new System.Drawing.Point(17, 38);
            this.timeValue.Name = "textBox1";
            this.timeValue.Size = new System.Drawing.Size(190, 23);
            this.timeValue.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Speed:";
            // 
            // textBox2
            // 
            this.speedValue.Location = new System.Drawing.Point(17, 86);
            this.speedValue.Name = "textBox2";
            this.speedValue.Size = new System.Drawing.Size(190, 23);
            this.speedValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initial coordinate:";
            // 
            // textBox3
            // 
            this.initCoordinateValue.Location = new System.Drawing.Point(17, 134);
            this.initCoordinateValue.Name = "textBox3";
            this.initCoordinateValue.Size = new System.Drawing.Size(190, 23);
            this.initCoordinateValue.TabIndex = 5;
            // 
            // UniformMotionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.initCoordinateValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speedValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeValue);
            this.Controls.Add(this.label1);
            this.Name = "UniformMotionUserControl";
            this.Size = new System.Drawing.Size(224, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox timeValue;
        private Label label2;
        private TextBox speedValue;
        private Label label3;
        private TextBox initCoordinateValue;
    }
}

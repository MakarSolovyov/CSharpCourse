namespace WinFormsApp1
{
    partial class OscilMotionUserControl
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
            this.initPhaseValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cyclFrequencyValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.amplitudeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.initPhaseValue.Location = new System.Drawing.Point(17, 182);
            this.initPhaseValue.Name = "textBox4";
            this.initPhaseValue.Size = new System.Drawing.Size(190, 23);
            this.initPhaseValue.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Initial phase:";
            // 
            // textBox3
            // 
            this.cyclFrequencyValue.Location = new System.Drawing.Point(17, 134);
            this.cyclFrequencyValue.Name = "textBox3";
            this.cyclFrequencyValue.Size = new System.Drawing.Size(190, 23);
            this.cyclFrequencyValue.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cyclic frequency:";
            // 
            // textBox2
            // 
            this.amplitudeValue.Location = new System.Drawing.Point(17, 86);
            this.amplitudeValue.Name = "textBox2";
            this.amplitudeValue.Size = new System.Drawing.Size(190, 23);
            this.amplitudeValue.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Amplitude:";
            // 
            // textBox1
            // 
            this.timeValue.Location = new System.Drawing.Point(17, 38);
            this.timeValue.Name = "textBox1";
            this.timeValue.Size = new System.Drawing.Size(190, 23);
            this.timeValue.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Time:";
            // 
            // OscilMotionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.initPhaseValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cyclFrequencyValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amplitudeValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeValue);
            this.Controls.Add(this.label1);
            this.Name = "OscilMotionUserControl";
            this.Size = new System.Drawing.Size(224, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox initPhaseValue;
        private Label label4;
        private TextBox cyclFrequencyValue;
        private Label label3;
        private TextBox amplitudeValue;
        private Label label2;
        private TextBox timeValue;
        private Label label1;
    }
}

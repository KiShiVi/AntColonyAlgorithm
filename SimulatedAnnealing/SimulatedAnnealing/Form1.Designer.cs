namespace SimulatedAnnealing
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
            this.p_amountOfNodes = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.p_temp = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.p_minTemp = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.p_startTemp = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_amountOfNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_minTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_startTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // p_amountOfNodes
            // 
            this.p_amountOfNodes.Location = new System.Drawing.Point(12, 12);
            this.p_amountOfNodes.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.p_amountOfNodes.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.p_amountOfNodes.Name = "p_amountOfNodes";
            this.p_amountOfNodes.Size = new System.Drawing.Size(120, 23);
            this.p_amountOfNodes.TabIndex = 0;
            this.p_amountOfNodes.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.p_amountOfNodes.ValueChanged += new System.EventHandler(this.p_amountOfNodes_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(776, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Запуск алгоритма";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 3;
            // 
            // p_temp
            // 
            this.p_temp.DecimalPlaces = 3;
            this.p_temp.Location = new System.Drawing.Point(668, 12);
            this.p_temp.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.p_temp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_temp.Name = "p_temp";
            this.p_temp.Size = new System.Drawing.Size(120, 23);
            this.p_temp.TabIndex = 4;
            this.p_temp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите шаг уменьшении температуры ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Введите до какой температуры выполнять алгоритм";
            // 
            // p_minTemp
            // 
            this.p_minTemp.DecimalPlaces = 3;
            this.p_minTemp.Location = new System.Drawing.Point(668, 41);
            this.p_minTemp.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.p_minTemp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_minTemp.Name = "p_minTemp";
            this.p_minTemp.Size = new System.Drawing.Size(120, 23);
            this.p_minTemp.TabIndex = 8;
            this.p_minTemp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Введите начальную температуру";
            // 
            // p_startTemp
            // 
            this.p_startTemp.DecimalPlaces = 3;
            this.p_startTemp.Location = new System.Drawing.Point(668, 70);
            this.p_startTemp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.p_startTemp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_startTemp.Name = "p_startTemp";
            this.p_startTemp.Size = new System.Drawing.Size(120, 23);
            this.p_startTemp.TabIndex = 11;
            this.p_startTemp.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.p_startTemp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.p_minTemp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p_temp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.p_amountOfNodes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_amountOfNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_temp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_minTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_startTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown p_amountOfNodes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown p_temp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown p_minTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown p_startTemp;
        private System.Windows.Forms.Label label7;
    }
}

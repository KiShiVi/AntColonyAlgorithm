namespace AntColonyAlgorithm
{
    partial class AntColonyAlghoritm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.p_alphaParameter = new System.Windows.Forms.NumericUpDown();
            this.p_betaParameter = new System.Windows.Forms.NumericUpDown();
            this.p_tParameter = new System.Windows.Forms.NumericUpDown();
            this.p_qParameter = new System.Windows.Forms.NumericUpDown();
            this.p_pParameter = new System.Windows.Forms.NumericUpDown();
            this.p_kParameter = new System.Windows.Forms.NumericUpDown();
            this.p_amountOfNodes = new System.Windows.Forms.NumericUpDown();
            this.p_mParameter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.p_applyButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.p_resultBrowser = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.p_alphaParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_betaParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_tParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_qParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_pParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_kParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_amountOfNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // p_alphaParameter
            // 
            this.p_alphaParameter.DecimalPlaces = 2;
            this.p_alphaParameter.Location = new System.Drawing.Point(663, 56);
            this.p_alphaParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_alphaParameter.Name = "p_alphaParameter";
            this.p_alphaParameter.Size = new System.Drawing.Size(120, 20);
            this.p_alphaParameter.TabIndex = 0;
            this.p_alphaParameter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // p_betaParameter
            // 
            this.p_betaParameter.DecimalPlaces = 2;
            this.p_betaParameter.Location = new System.Drawing.Point(1122, 52);
            this.p_betaParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_betaParameter.Name = "p_betaParameter";
            this.p_betaParameter.Size = new System.Drawing.Size(120, 20);
            this.p_betaParameter.TabIndex = 1;
            this.p_betaParameter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // p_tParameter
            // 
            this.p_tParameter.DecimalPlaces = 2;
            this.p_tParameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.p_tParameter.Location = new System.Drawing.Point(1122, 87);
            this.p_tParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_tParameter.Name = "p_tParameter";
            this.p_tParameter.Size = new System.Drawing.Size(120, 20);
            this.p_tParameter.TabIndex = 3;
            this.p_tParameter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // p_qParameter
            // 
            this.p_qParameter.Location = new System.Drawing.Point(663, 91);
            this.p_qParameter.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.p_qParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_qParameter.Name = "p_qParameter";
            this.p_qParameter.Size = new System.Drawing.Size(120, 20);
            this.p_qParameter.TabIndex = 2;
            this.p_qParameter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // p_pParameter
            // 
            this.p_pParameter.DecimalPlaces = 2;
            this.p_pParameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.p_pParameter.Location = new System.Drawing.Point(1122, 127);
            this.p_pParameter.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_pParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.p_pParameter.Name = "p_pParameter";
            this.p_pParameter.Size = new System.Drawing.Size(120, 20);
            this.p_pParameter.TabIndex = 5;
            this.p_pParameter.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // p_kParameter
            // 
            this.p_kParameter.Location = new System.Drawing.Point(663, 131);
            this.p_kParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_kParameter.Name = "p_kParameter";
            this.p_kParameter.Size = new System.Drawing.Size(120, 20);
            this.p_kParameter.TabIndex = 4;
            this.p_kParameter.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // p_amountOfNodes
            // 
            this.p_amountOfNodes.Location = new System.Drawing.Point(105, 51);
            this.p_amountOfNodes.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.p_amountOfNodes.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.p_amountOfNodes.Name = "p_amountOfNodes";
            this.p_amountOfNodes.Size = new System.Drawing.Size(120, 20);
            this.p_amountOfNodes.TabIndex = 7;
            this.p_amountOfNodes.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.p_amountOfNodes.ValueChanged += new System.EventHandler(this.p_amountOfNodes_ValueChanged);
            // 
            // p_mParameter
            // 
            this.p_mParameter.DecimalPlaces = 2;
            this.p_mParameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.p_mParameter.Location = new System.Drawing.Point(663, 169);
            this.p_mParameter.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.p_mParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.p_mParameter.Name = "p_mParameter";
            this.p_mParameter.Size = new System.Drawing.Size(120, 20);
            this.p_mParameter.TabIndex = 6;
            this.p_mParameter.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alpha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Q";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "K";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "m";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1081, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Beta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1081, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "T";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1081, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "p";
            // 
            // p_applyButton
            // 
            this.p_applyButton.Location = new System.Drawing.Point(584, 552);
            this.p_applyButton.Name = "p_applyButton";
            this.p_applyButton.Size = new System.Drawing.Size(689, 23);
            this.p_applyButton.TabIndex = 16;
            this.p_applyButton.Text = "Start alghoritm";
            this.p_applyButton.UseVisualStyleBackColor = true;
            this.p_applyButton.Click += new System.EventHandler(this.p_applyButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Amount of nodes";
            // 
            // p_resultBrowser
            // 
            this.p_resultBrowser.Location = new System.Drawing.Point(584, 195);
            this.p_resultBrowser.Name = "p_resultBrowser";
            this.p_resultBrowser.ReadOnly = true;
            this.p_resultBrowser.Size = new System.Drawing.Size(689, 351);
            this.p_resultBrowser.TabIndex = 19;
            this.p_resultBrowser.Text = "";
            // 
            // AntColonyAlghoritm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1291, 589);
            this.Controls.Add(this.p_resultBrowser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.p_applyButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_amountOfNodes);
            this.Controls.Add(this.p_mParameter);
            this.Controls.Add(this.p_pParameter);
            this.Controls.Add(this.p_kParameter);
            this.Controls.Add(this.p_tParameter);
            this.Controls.Add(this.p_qParameter);
            this.Controls.Add(this.p_betaParameter);
            this.Controls.Add(this.p_alphaParameter);
            this.Name = "AntColonyAlghoritm";
            this.Text = "AntColonyAlghoritm";
            this.Load += new System.EventHandler(this.AntColonyAlghoritm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_alphaParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_betaParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_tParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_qParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_pParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_kParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_amountOfNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown p_alphaParameter;
        private System.Windows.Forms.NumericUpDown p_betaParameter;
        private System.Windows.Forms.NumericUpDown p_tParameter;
        private System.Windows.Forms.NumericUpDown p_qParameter;
        private System.Windows.Forms.NumericUpDown p_pParameter;
        private System.Windows.Forms.NumericUpDown p_kParameter;
        private System.Windows.Forms.NumericUpDown p_amountOfNodes;
        private System.Windows.Forms.NumericUpDown p_mParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button p_applyButton;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox p_resultBrowser;
    }
}


namespace BeeColonies
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
            this.button1 = new System.Windows.Forms.Button();
            this.txb_numberOfPoints = new System.Windows.Forms.TextBox();
            this.txb_numberOfVipPoints = new System.Windows.Forms.TextBox();
            this.txb_numberOfSearchPoints = new System.Windows.Forms.TextBox();
            this.txb_numberOfAdditionalPointsAtVipPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_numberOfAdditionalPointsAtStandardPoints = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_rangeOfValuesX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_polinom = new System.Windows.Forms.TextBox();
            this.txb_minX = new System.Windows.Forms.TextBox();
            this.txb_maxX = new System.Windows.Forms.TextBox();
            this.txb_maxY = new System.Windows.Forms.TextBox();
            this.txb_minY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_rangeOfValuesY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_numberOfIterations = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(614, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Запуск алгоритма";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txb_numberOfPoints
            // 
            this.txb_numberOfPoints.Location = new System.Drawing.Point(17, 44);
            this.txb_numberOfPoints.Name = "txb_numberOfPoints";
            this.txb_numberOfPoints.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfPoints.TabIndex = 1;
            this.txb_numberOfPoints.Text = "15";
            // 
            // txb_numberOfVipPoints
            // 
            this.txb_numberOfVipPoints.Location = new System.Drawing.Point(17, 73);
            this.txb_numberOfVipPoints.Name = "txb_numberOfVipPoints";
            this.txb_numberOfVipPoints.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfVipPoints.TabIndex = 2;
            this.txb_numberOfVipPoints.Text = "4";
            // 
            // txb_numberOfSearchPoints
            // 
            this.txb_numberOfSearchPoints.Location = new System.Drawing.Point(17, 102);
            this.txb_numberOfSearchPoints.Name = "txb_numberOfSearchPoints";
            this.txb_numberOfSearchPoints.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfSearchPoints.TabIndex = 3;
            this.txb_numberOfSearchPoints.Text = "7";
            // 
            // txb_numberOfAdditionalPointsAtVipPoints
            // 
            this.txb_numberOfAdditionalPointsAtVipPoints.Location = new System.Drawing.Point(17, 131);
            this.txb_numberOfAdditionalPointsAtVipPoints.Name = "txb_numberOfAdditionalPointsAtVipPoints";
            this.txb_numberOfAdditionalPointsAtVipPoints.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfAdditionalPointsAtVipPoints.TabIndex = 4;
            this.txb_numberOfAdditionalPointsAtVipPoints.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество точек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество элитных точек";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количство точек поиска";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Количество дополнительных точек у элитных точек";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Количество дополнительных точек у обычных точек";
            // 
            // txb_numberOfAdditionalPointsAtStandardPoints
            // 
            this.txb_numberOfAdditionalPointsAtStandardPoints.Location = new System.Drawing.Point(17, 160);
            this.txb_numberOfAdditionalPointsAtStandardPoints.Name = "txb_numberOfAdditionalPointsAtStandardPoints";
            this.txb_numberOfAdditionalPointsAtStandardPoints.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfAdditionalPointsAtStandardPoints.TabIndex = 9;
            this.txb_numberOfAdditionalPointsAtStandardPoints.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Диапозон поиска для X";
            // 
            // txb_rangeOfValuesX
            // 
            this.txb_rangeOfValuesX.Location = new System.Drawing.Point(17, 247);
            this.txb_rangeOfValuesX.Name = "txb_rangeOfValuesX";
            this.txb_rangeOfValuesX.Size = new System.Drawing.Size(100, 23);
            this.txb_rangeOfValuesX.TabIndex = 11;
            this.txb_rangeOfValuesX.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // txb_polinom
            // 
            this.txb_polinom.Location = new System.Drawing.Point(48, 9);
            this.txb_polinom.Name = "txb_polinom";
            this.txb_polinom.Size = new System.Drawing.Size(402, 23);
            this.txb_polinom.TabIndex = 14;
            this.txb_polinom.Text = "15 * x * y * (1 - x) * (1 - y) * sin(pi * x) * sin(pi * y)";
            this.txb_polinom.TextChanged += new System.EventHandler(this.txb_polinom_TextChanged);
            // 
            // txb_minX
            // 
            this.txb_minX.Location = new System.Drawing.Point(17, 189);
            this.txb_minX.Name = "txb_minX";
            this.txb_minX.Size = new System.Drawing.Size(100, 23);
            this.txb_minX.TabIndex = 15;
            this.txb_minX.Text = "-100";
            // 
            // txb_maxX
            // 
            this.txb_maxX.Location = new System.Drawing.Point(123, 189);
            this.txb_maxX.Name = "txb_maxX";
            this.txb_maxX.Size = new System.Drawing.Size(100, 23);
            this.txb_maxX.TabIndex = 16;
            this.txb_maxX.Text = "100";
            // 
            // txb_maxY
            // 
            this.txb_maxY.Location = new System.Drawing.Point(123, 218);
            this.txb_maxY.Name = "txb_maxY";
            this.txb_maxY.Size = new System.Drawing.Size(100, 23);
            this.txb_maxY.TabIndex = 18;
            this.txb_maxY.Text = "100";
            // 
            // txb_minY
            // 
            this.txb_minY.Location = new System.Drawing.Point(17, 218);
            this.txb_minY.Name = "txb_minY";
            this.txb_minY.Size = new System.Drawing.Size(100, 23);
            this.txb_minY.TabIndex = 17;
            this.txb_minY.Text = "-100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Диапозон координаты Х";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Диапозон координаты Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Диапозон поиска для Y";
            // 
            // txb_rangeOfValuesY
            // 
            this.txb_rangeOfValuesY.Location = new System.Drawing.Point(17, 276);
            this.txb_rangeOfValuesY.Name = "txb_rangeOfValuesY";
            this.txb_rangeOfValuesY.Size = new System.Drawing.Size(100, 23);
            this.txb_rangeOfValuesY.TabIndex = 21;
            this.txb_rangeOfValuesY.Text = "2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(123, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Количество итераций";
            // 
            // txb_numberOfIterations
            // 
            this.txb_numberOfIterations.Location = new System.Drawing.Point(17, 305);
            this.txb_numberOfIterations.Name = "txb_numberOfIterations";
            this.txb_numberOfIterations.Size = new System.Drawing.Size(100, 23);
            this.txb_numberOfIterations.TabIndex = 23;
            this.txb_numberOfIterations.Text = "10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Z =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 415);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txb_numberOfIterations);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txb_rangeOfValuesY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_maxY);
            this.Controls.Add(this.txb_minY);
            this.Controls.Add(this.txb_maxX);
            this.Controls.Add(this.txb_minX);
            this.Controls.Add(this.txb_polinom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_rangeOfValuesX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_numberOfAdditionalPointsAtStandardPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_numberOfAdditionalPointsAtVipPoints);
            this.Controls.Add(this.txb_numberOfSearchPoints);
            this.Controls.Add(this.txb_numberOfVipPoints);
            this.Controls.Add(this.txb_numberOfPoints);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txb_numberOfPoints;
        private System.Windows.Forms.TextBox txb_numberOfVipPoints;
        private System.Windows.Forms.TextBox txb_numberOfSearchPoints;
        private System.Windows.Forms.TextBox txb_numberOfAdditionalPointsAtVipPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_numberOfAdditionalPointsAtStandardPoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_rangeOfValuesX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_polinom;
        private System.Windows.Forms.TextBox txb_minX;
        private System.Windows.Forms.TextBox txb_maxX;
        private System.Windows.Forms.TextBox txb_maxY;
        private System.Windows.Forms.TextBox txb_minY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_rangeOfValuesY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_numberOfIterations;
        private System.Windows.Forms.Label label12;
    }
}

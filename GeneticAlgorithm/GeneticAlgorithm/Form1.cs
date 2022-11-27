using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GeneticAlgorithm.Kernel;

namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amountOfBits = radioButton1.Checked ? 2 : 5;
            GA ga = new GA(
                !radioButton1.Checked,
                (double)numericUpDown1.Value / 100, 
                (double)numericUpDown2.Value / 100, 
                (int)numericUpDown3.Value, 
                (int)numericUpDown4.Value,
                amountOfBits,
                infixPhraseTextBox.Text,double.Parse(textBox1.Text), double.Parse(textBox2.Text));

            ga.FitnessFunction = new GAFunction(GenAlgTestFcn);
            ga.Elitism = true;
            ga.LaunchGA();

            double[] values; double fitness;
            ga.GetBestValues(out values, out fitness);

            label6.Text = "Calculated max values are: \nx_max = " + values[0] + ", \nny_max = " + values[1];
            label7.Text = "f(x_max,y_max) = \nf(" + values[0] + "; " + values[1] + ") = " + fitness;

            ga.FitnessFunction = null;
            ga = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infixPhraseTextBox.Text = "15 * x * y * (1 - x) * (1 - y) * sin(pi * x) * sin(pi * y)";
        }

    }
}

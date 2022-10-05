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
            GA ga = new GA((double)numericUpDown1.Value / 100, 
                (double)numericUpDown2.Value / 100, 
                (int)numericUpDown3.Value, 
                (int)numericUpDown4.Value, 
                2);

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
    }
}

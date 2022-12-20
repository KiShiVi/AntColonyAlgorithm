using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatedAnnealing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x, x1, y, y1;
        Random random = new Random();
        List<List<NumericUpDown>> listOfGraphNodes = new List<List<NumericUpDown>>();

        private void button1_Click(object sender, EventArgs e)
        {
            Annealing annealing = new Annealing(listOfGraphNodes,(double)p_startTemp.Value);
            for (; annealing.temperature > (double)p_minTemp.Value;annealing.temperature -= (double)p_temp.Value)
            {
                annealing.permutation(listOfGraphNodes);
                if (annealing.temperature < 0)
                    annealing.temperature = 1;
                if ((100 * Math.Exp(-(annealing.kL - annealing.L) / annealing.temperature)) > random.Next(1, 100))
                {
                    annealing.kL = annealing.L;
                    annealing.vertexes = annealing.kVertexes;
                }
                else
                {
                    annealing.L = annealing.kL;
                    annealing.kVertexes = annealing.vertexes;
                }
            }
            label3.Text = "Лучшим маршрутом является [ ";
            for(int i = 0; i < annealing.vertexes.Length; i++)
            {
                label3.Text += annealing.vertexes[i] + " ";
            }
            label3.Text += annealing.vertexes[0] + " ";
            label3.Text += "] с длиной маршрута: " + annealing.L;
            label3.Visible = true;
        }


        private void p_amountOfNodes_ValueChanged(object sender, EventArgs e)
        {
            y1 = y;
            for (int i = 0; i < listOfGraphNodes.Count(); i++)
                for (int j = 0; j < listOfGraphNodes[i].Count(); j++)
                    this.Controls.Remove(listOfGraphNodes[i][j]);
            listOfGraphNodes.Clear();
            for (int i = 1; i < p_amountOfNodes.Value; i++)
            {
                x1 = x;
                listOfGraphNodes.Add(new List<NumericUpDown>());
                for (int j = 0; j < p_amountOfNodes.Value - 1; j++)
                {
                    if (i > j)
                    {
                        listOfGraphNodes[i - 1].Add(new NumericUpDown());
                        listOfGraphNodes[i - 1][j].Size = new Size(37, 20);
                        listOfGraphNodes[i - 1][j].Location = new Point(y1, x1);
                        listOfGraphNodes[i - 1][j].Minimum = 1;
                        Controls.Add(listOfGraphNodes[i - 1][j]);
                        x1 += 26;
                    }
                }
                y1 += 43;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 96;
            y = 15;
            p_amountOfNodes_ValueChanged(sender, e);
            label3.Visible = false;
        }
    }
}

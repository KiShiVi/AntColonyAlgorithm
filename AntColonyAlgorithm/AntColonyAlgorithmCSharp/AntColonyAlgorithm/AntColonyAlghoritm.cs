using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AntColonyAlgorithm
{
    public partial class AntColonyAlghoritm : Form
    {
        public AntColonyAlghoritm()
        {
            InitializeComponent();
        }

        int x, x1, y, y1;
        List<List<NumericUpDown>> listOfGraphNodes = new List<List<NumericUpDown>>();

        private void p_applyButton_Click(object sender, EventArgs e)
        {
            p_resultBrowser.Clear();
            Kernel kernel = new Kernel((int)p_amountOfNodes.Value,(float) p_alphaParameter.Value, (float)p_betaParameter.Value,
                (float)p_qParameter.Value, (int)p_tParameter.Value, (int)p_kParameter.Value, (float)p_pParameter.Value,
                (float)p_mParameter.Value);

            for (int i = 1; i < p_amountOfNodes.Value; ++i)
            {
                for (int j = 0; j < p_amountOfNodes.Value - 1; ++j)
                {
                    if (i > j)
                    {
                            kernel.setNodeProperties(i, j, (float)listOfGraphNodes[i - 1][j].Value, true);
                    }
                }
            }
            for (int i = 0; i < p_qParameter.Value; ++i)
            {
                p_resultBrowser.Text += (i + 1) + ": " + kernel.getNextGeneration();
                p_resultBrowser.AppendText(Environment.NewLine);
            }
            //p_resultBrowser.Text += "Best route: " + kernel.getBestRoute();
        }

        

        private void AntColonyAlghoritm_Load(object sender, EventArgs e)
        {
            x = 96;
            y = 15;
            p_amountOfNodes_ValueChanged(sender, e);
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
    }
}

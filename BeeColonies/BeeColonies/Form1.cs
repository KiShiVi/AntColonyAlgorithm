using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeColonies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Colonies colonies = new Colonies(int.Parse(txb_numberOfPoints.Text), double.Parse(txb_minX.Text), double.Parse(txb_maxX.Text),
                double.Parse(txb_minY.Text),double.Parse(txb_maxY.Text),
                txb_polinom.Text, int.Parse(txb_numberOfAdditionalPointsAtVipPoints.Text), int.Parse(txb_numberOfAdditionalPointsAtStandardPoints.Text),
                int.Parse(txb_numberOfVipPoints.Text), int.Parse(txb_numberOfSearchPoints.Text),
                double.Parse(txb_rangeOfValuesX.Text), double.Parse(txb_rangeOfValuesY.Text));
            for (int i = 0; i < int.Parse(txb_numberOfIterations.Text); i++)
                colonies.OneIterationOfTheAlgorithm();
            label7.Text = "Минимум функции равен " + colonies.list[0].z + " при X = " + colonies.list[0].x + "; Y = " + colonies.list[0].y + ";";
            label7.Visible = true;

        }

        private void txb_polinom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

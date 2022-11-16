using System.Drawing;

namespace HammingNeuralNetworks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(pictureBox1.Image)) 
            {
                Pen p = new Pen(Color.Black);
                for (int y = 0; y < pictureBox1.Height; y += 51)
                {
                    g.DrawLine(p, y, 0, y, pictureBox1.Height);
                    g.DrawLine(p, 0, y, pictureBox1.Height, y);
                }
            }
            label1.Visible = false;
        }
        int[,] vector = new int[1,25];
        double[,] matrixHamming = new double[6, 25] { { 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
                { 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1 } };
        double[,] weight = new double[6, 25];
        double Emax = 0.1;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 51;
            int y = e.Y / 51; 
           Graphics g = pictureBox1.CreateGraphics();
           SolidBrush solidBrush;
            if (vector[0,x + y * 5] == 0)
            {
                solidBrush = new SolidBrush(Color.Black);
                vector[0, x + y * 5] = 1;
            }
            else
            {
                solidBrush = new SolidBrush(Color.White);  
                vector[0,x + y * 5] = 0;
            }
            g.FillRectangle(solidBrush, x * 50 + x + 1, y * 50 + y + 1, 50, 50);
        }

        private void btn_hamming_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    weight[i, j] = matrixHamming[i, j] / 2;
                }
            }
            double[] status = new double[6];
            double[] outValue = new double[6];
            for(int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                    status[i] += weight[i, j] * vector[0, j];
                status[i] += 25 / 2;
            }
            for(int i = 0; i< 6; i++)
                if (status[i]<0)
                    outValue[i] = 0;
                else
                    outValue[i] = status[i];
            for (int j = 0; j < 10; j++) 
            {
                double feedbackSynapses = 1.0 / 6.0;
                for( int i = 0; i < 6; i++)
                {
                    status[i] = outValue[i] - feedbackSynapses * (outValue[0] + outValue[1] + outValue[2] + outValue[3] + outValue[4] + outValue[5] - outValue[i]);

                }
                for (int i = 0; i < 6; i++)
                    if (status[i] < 0)
                        outValue[i] = 0;
                    else
                        outValue[i] = status[i];
                int k = 0, cur = 0;
                for( int i = 0; i < 6; i++)
                {
                    if (outValue[i] != 0)
                    {
                        k++;
                        cur = i;
                    }
                }
                if (k == 1)
                {
                    if (outValue[cur] > Emax) 
                    switch (cur)
                    {
                        case 0:
                            label1.Text = "Это буква К";
                            break;
                        case 1:
                            label1.Text = "Это буква В";
                            break;
                        case 2:
                            label1.Text = "Это буква И";
                            break;
                        case 3:
                            label1.Text = "Это буква Т";
                            break;
                        case 4:
                            label1.Text = "Это буква О";
                            break;
                        case 5:
                            label1.Text = "Это буква Д";
                            break;

                    }
                    label1.Visible = true;
                    return;
                }
            }
            label1.Visible = true;
            label1.Text = "Буква не распознана";
        }
    }
}
using System.Drawing;
using System.Runtime.ConstrainedExecution;

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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    matrix.weight[i, j] = matrix.matrixHamming[i, j] / 2;
                }
            }
            label1.Visible = false;
        }

        
        Matrix  matrix = new Matrix();
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 51;
            int y = e.Y / 51; 
           Graphics g = pictureBox1.CreateGraphics();
           SolidBrush solidBrush;
            if (matrix.vector[0,x + y * 5] == -1)
            {
                solidBrush = new SolidBrush(Color.Black);
                matrix.vector[0, x + y * 5] = 1;
            }
            else
            {
                solidBrush = new SolidBrush(Color.White);
                matrix.vector[0,x + y * 5] = -1;
            }
            g.FillRectangle(solidBrush, x * 50 + x + 1, y * 50 + y + 1, 50, 50);
        }

        private void btn_hamming_Click(object sender, EventArgs e)
        {
            Hamming.algorithmHamming(matrix);
            switch (Hamming.letterSearch(matrix))
            {
                case -1:
                    label1.Text = "Буква не распознана";
                    break;
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
        }
    }
}
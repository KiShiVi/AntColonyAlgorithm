using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammingNeuralNetworks
{
    internal class Hamming
    {
        static public void algorithmHamming(Matrix matrix)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                    matrix.status[i] += matrix.weight[i, j] * matrix.vector[0, j];
                matrix.status[i] += 25 / 2;
            }
            for (int i = 0; i < 6; i++)
                if (matrix.status[i] < 0)
                    matrix.outValue[i] = 0;
                else
                    matrix.outValue[i] = matrix.status[i];
        }

        static public int letterSearch(Matrix matrix)
        {
            int k = 0, cur = 0;
            double Emax = 0.1;
            for (int j = 0; j < 10; j++)
            {
                double feedbackSynapses = 1.0 / 6.0;
                for (int i = 0; i < 6; i++)
                {
                    matrix.status[i] = matrix.outValue[i] - feedbackSynapses * (matrix.outValue[0] + matrix.outValue[1] + matrix.outValue[2]
                    + matrix.outValue[3] + matrix.outValue[4] + matrix.outValue[5] - matrix.outValue[i]);

                }
                for (int i = 0; i < 6; i++)
                    if (matrix.status[i] < 0)
                        matrix.outValue[i] = 0;
                    else
                        matrix.outValue[i] = matrix.status[i];
                for (int i = 0; i < 6; i++)
                {
                    if (matrix.outValue[i] != 0)
                    {
                        k++;
                        cur = i;
                    }
                }
                if (k == 1)
                {
                    if (matrix.outValue[cur] > Emax)
                    {
                        matrix.clear();
                        return cur;
                    }

                }
            }
            cur = -1;
            return cur;
        }
    }
}

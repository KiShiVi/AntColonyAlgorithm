using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammingNeuralNetworks
{
    internal class Matrix
    {
        public double[,] weight = new double[6, 25];
        public double[,] matrixHamming = new double[6, 25] {
                { 1, -1, -1, 1, 1, 1,-1, -1, 1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, -1, 1, -1, -1, 1, 1 },
                { 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1 },
                { 1, -1, -1, 1, 1, 1, -1, -1, 1, 1, 1, -1, 1, -1, 1, 1, 1, -1, -1, 1, 1, 1, -1, -1, 1 },
                { 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1 },
                { 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1 },
                { -1, 1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, -1, 1, -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1 } };
        public int[,] vector = new int[1, 25] { { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1} };
        public double[] status = new double[6];
        public double[] outValue = new double[6];
        public void clear()
        {
            for(int i = 0; i < status.Length; i++)
                this.status[i] = 0;
            for(int i = 0; i < outValue.Length; i++)
                this.outValue[i] = 0;
        }
    }
}

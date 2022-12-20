using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SimulatedAnnealing
{
    internal class Annealing
    {
        public int[] vertexes;
        public int[] kVertexes;
        public double temperature;
        public double L,kL;
        public Annealing(List<List<NumericUpDown>> list,double temp)
        {
            Random random = new Random();
            vertexes = new int[list.Count + 1];
            kVertexes = new int[list.Count + 1];
            bool ind = false;
            for (int i = 0; i < vertexes.Length; i++)
            {
                vertexes[i] = random.Next(1, vertexes.Length + 1);
                for (int j = i - 1; j >= 0; j--)
                    if (vertexes[i] == vertexes[j]) ind = true;
                if (ind) i--;
                ind = false;
            }
            temperature = temp;
            determiningTheBestPath(list);
            kL = L;
            kVertexes = vertexes;
        }
        public void permutation(List<List<NumericUpDown>> list)
        {
            Random random = new Random();
            int i = random.Next(0, vertexes.Length - 1);
            int j = i;
            while (i == j)
                j = random.Next(0, vertexes.Length - 1);
            int num = kVertexes[i];
            kVertexes[i] = kVertexes[j];
            kVertexes[j] = num;
            determiningTheBestPath(list);
        }
        private void determiningTheBestPath(List<List<NumericUpDown>> list)
        {
            L= 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (vertexes[i + 1] < vertexes[i])
                    L += (int)list[vertexes[i] - 2][vertexes[i + 1] - 1].Value;
                else
                    L += (int)list[vertexes[i + 1] - 2][vertexes[i] - 1].Value;
            }
            if (vertexes[0] < vertexes[list.Count])
                L += (int)list[vertexes[list.Count] - 2][vertexes[0] - 1].Value;
            else
                L += (int)list[vertexes[0] - 2][vertexes[list.Count] - 1].Value;


        }
    }
}

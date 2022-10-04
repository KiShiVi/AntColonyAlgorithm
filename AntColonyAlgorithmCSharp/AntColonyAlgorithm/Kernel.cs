using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyAlgorithm
{
    internal class Node
    {
        public Node(float in_amountOfPheromone) {        distance = 0;
        amountOfPheromone = in_amountOfPheromone;
        isEdge = true;
        }
        public float distance;
        public float amountOfPheromone;
        public bool isEdge;
    };

    internal class Kernel
    {
        public Kernel(int   amountOfNodes,
                float alpha,
                float beta,
                float q,
                int   t,
                int   k,
                float p,
                float m) {
            m_amountOfNodes  =  amountOfNodes;
            m_alphaParameter =  alpha;
            m_betaParameter  =  beta;
            m_qParameter     =  q;
            m_tParameter     =  t;
            m_kParameter     =  k;
            m_pParameter     =  p;
            m_mParameter     =  m;
            graphNodes = new List<List<Node>>();

            graphNodes.Add(new List<Node>());

            for (int i = 1; i < amountOfNodes; ++i)
            {
                graphNodes.Add(new List<Node>());
                for (int j = 0; j < amountOfNodes - 1; ++j)
                    if (i > j)
                        graphNodes[i].Add(new Node(m_mParameter));
            }
            bestRoute = "";
            bestDistance = 0;
        }
        ~Kernel()
        {
            for (int i = 1; i < m_amountOfNodes; ++i)
                for (int j = 0; j < m_amountOfNodes - 1; ++j)
                    if (i > j)
                         graphNodes[i][j] = null ;
        }
        public void setNodeProperties(int i, int j, float distance, bool isEdge)
        {
            graphNodes[i][j].distance = distance;
            graphNodes[i][j].amountOfPheromone = m_mParameter;
            graphNodes[i][j].isEdge = isEdge;
        }
        public String getNextGeneration()
        {
            Random random = new Random();
            float globalMinimalDistance = 0;
            List<int> globalOptimalRoute = new List<int>();

            float[] allDistances = new float[m_kParameter];
            List<List<int>> allRoutes = new List<List<int>>();

            bool[] availableOfNodes = new bool[m_amountOfNodes];

            for (int k = 0; k < m_kParameter; ++k)
            {
                for (int i = 0; i < m_amountOfNodes; ++i)
                    availableOfNodes[i] = true;

                int currentNode = random.Next() % m_amountOfNodes;
                int startNode = currentNode;
                int amountOfPassedNodes = m_amountOfNodes - 1;
                float summaryDistance = 0;
                List<int> route = new List<int>();
                route.Add(startNode);
                while (amountOfPassedNodes > 0)
                {
                    availableOfNodes[currentNode] = false;
                    float summaryAttraction = 0;

                    float[] attractions = new float[m_amountOfNodes];

                    //calculate summaryAttraction
                    for (int i = 0; i < m_amountOfNodes; ++i)
                    {
                        if (currentNode == i)
                        {
                            attractions[i] = 0;
                            continue;
                        }
                        Node checkingNode = graphNodes[Math.Max(currentNode, i)][Math.Min(currentNode, i)];
                        if (availableOfNodes[i] && checkingNode.isEdge)
                        {
                            attractions[i] =(float)(Math.Pow(checkingNode.amountOfPheromone, m_alphaParameter) * Math.Pow(1.0f / checkingNode.distance, m_betaParameter));
                            summaryAttraction += attractions[i];
                        }
                        else
                        {
                            attractions[i] = 0;
                        }
                    }

                    for (int i = 0; i < m_amountOfNodes; ++i)
                    {
                        attractions[i] = attractions[i] / summaryAttraction;
                    }

                    float randChoiseNode = (float)(random.Next(0,10000) % 100) / 100;
                    float valueForRandChoise = 0;

                    for (int i = 0; i < m_amountOfNodes; ++i)
                    {
                        valueForRandChoise += attractions[i];
                        if (randChoiseNode < valueForRandChoise)
                        {
                            summaryDistance += graphNodes[Math.Max(currentNode, i)][Math.Min(currentNode, i)].distance;
                            route.Add(i);
                            currentNode = i;
                            break;
                        }
                    }

                    attractions = null;
                    amountOfPassedNodes--;
                }
                route.Add(startNode);
                summaryDistance += graphNodes[Math.Max(currentNode, startNode)][Math.Min(currentNode, startNode)].distance;

                allRoutes.Add(route);
                allDistances[k] = summaryDistance;

                if (summaryDistance < globalMinimalDistance || k == 0)
                {
                    globalOptimalRoute = route;
                    globalMinimalDistance = summaryDistance;
                }

                ++m_iterationsCounter;
            }

            for (int i = 1; i < m_amountOfNodes; ++i)
                for (int j = 0; j < m_amountOfNodes - 1; ++j)
                    if (i > j)
                        graphNodes[i][j].amountOfPheromone = (1 - m_pParameter) * graphNodes[i][j].amountOfPheromone;

            for (int i = 0; i < allRoutes.Count; ++i)
                for (int j = 0; j < allRoutes[i].Count() - 1; ++j)
                    graphNodes[Math.Max(allRoutes[i][j], allRoutes[i][j + 1])][Math.Min(allRoutes[i][j], allRoutes[i][j + 1])].amountOfPheromone +=
                    (m_qParameter / allDistances[i]);

            String result = "";
            for (int i = 0; i < globalOptimalRoute.Count() - 1; ++i)
                result += globalOptimalRoute[i] + "-";
            result += (globalOptimalRoute[globalOptimalRoute.Count() - 1]) + " | dist: " + globalMinimalDistance;

            allDistances        = null;
            availableOfNodes    = null;

            if (globalMinimalDistance < bestDistance || bestDistance == 0)
            {
                bestDistance = globalMinimalDistance;
                bestRoute = result;
            }

            return result;
        }
        public String getBestRoute()
        {
            return bestRoute;
        }

	    private String bestRoute;
        private float bestDistance;

        private int   m_amountOfNodes;
        private float m_alphaParameter;
        private float m_betaParameter;
        private float m_qParameter;
        private int   m_tParameter;
        private int   m_kParameter;
        private float m_pParameter;
        private float m_mParameter;

        private int m_iterationsCounter;
        private List<List<Node>> graphNodes;
     
    };
}

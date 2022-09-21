#include "kernel.h"

#include <QtCore/QRandomGenerator>

Kernel::Kernel(int amountOfNodes, float alpha, float beta, float q, int t, int k, float p, float m) :
	m_amountOfNodes(amountOfNodes),
	m_alphaParameter(alpha),
	m_betaParameter(beta),
	m_qParameter(q),
	m_tParameter(t),
	m_kParameter(k),
	m_pParameter(p),
	m_mParameter(m),
	m_iterationsCounter(0)
{
	graphNodes = QList<QList<Node*>>();

    graphNodes.append(QList<Node*>());

    for (int i = 1; i < amountOfNodes; ++i)
    {
        graphNodes.append(QList<Node*>());
        for (int j = 0; j < amountOfNodes - 1; ++j)
            if (i > j)
                graphNodes[i].append(new Node(m_mParameter));
    }
	bestRoute		= "";
	bestDistance	= 0;
}

Kernel::~Kernel()
{
	for (int i = 1; i < m_amountOfNodes; ++i)
		for (int j = 0; j < m_amountOfNodes - 1; ++j)
			if (i > j)
				delete graphNodes[i][j];
}

void Kernel::setNodeProperties(int i, int j, float distance, bool isEdge)
{
	graphNodes[i][j]->distance = distance;
	graphNodes[i][j]->amountOfPheromone = m_mParameter;
	graphNodes[i][j]->isEdge = isEdge;
}

QString Kernel::getNextGeneration()
{
	float gobalMinimalDistance = 0;
	QList<int> globalOptimalRoute;

	float* allDistances = new float[m_kParameter];
	QList<QList<int>> allRoutes;

	bool* availableOfNodes = new bool[m_amountOfNodes];

	for (int k = 0; k < m_kParameter; ++k)
	{
		for (int i = 0; i < m_amountOfNodes; ++i)
			availableOfNodes[i] = true;

		int currentNode = QRandomGenerator::global()->generate() % m_amountOfNodes;
		int startNode = currentNode;
		int amountOfPassedNodes = m_amountOfNodes - 1;
		float summaryDistance = 0;
		QList<int> route;
		route.append(startNode);
		while (amountOfPassedNodes > 0)
		{
			availableOfNodes[currentNode] = false;
			float summaryAttraction = 0;

			float* attractions = new float[m_amountOfNodes];

			//calculate summaryAttraction
			for (int i = 0; i < m_amountOfNodes; ++i)
			{
				if (currentNode == i)
				{
					attractions[i] = 0;
					continue;
				}
				Node* checkingNode = graphNodes[qMax(currentNode, i)][qMin(currentNode, i)];
				if (availableOfNodes[i] && checkingNode->isEdge)
				{
					attractions[i] = powf(checkingNode->amountOfPheromone, m_alphaParameter) * powf(1.0f / checkingNode->distance, m_betaParameter);
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

			float randChoiseNode = ((float)(QRandomGenerator::global()->generate() % 100) / 100);
			float valueForRandChoise = 0;

			for (int i = 0; i < m_amountOfNodes; ++i)
			{
				valueForRandChoise += attractions[i];
				if (randChoiseNode < valueForRandChoise)
				{
					summaryDistance += graphNodes[qMax(currentNode, i)][qMin(currentNode, i)]->distance;
					route.append(i);
					currentNode = i;
					break;
				}
			}

			delete[] attractions;
			amountOfPassedNodes--;
		}
		route.append(startNode);
		summaryDistance += graphNodes[qMax(currentNode, startNode)][qMin(currentNode, startNode)]->distance;

		allRoutes.append(route);
		allDistances[k] = summaryDistance;

		if (summaryDistance < gobalMinimalDistance || k == 0)
		{
			globalOptimalRoute = route;
			gobalMinimalDistance = summaryDistance;
		}

		++m_iterationsCounter;
	}

	for (int i = 1; i < m_amountOfNodes; ++i)
		for (int j = 0; j < m_amountOfNodes - 1; ++j)
			if (i > j)
				graphNodes[i][j]->amountOfPheromone = (1 - m_pParameter) * graphNodes[i][j]->amountOfPheromone;

	for (int i = 0; i < allRoutes.count(); ++i)
		for (int j = 0; j < allRoutes[i].count() - 1; ++j)
			graphNodes[qMax(allRoutes[i][j], allRoutes[i][j + 1])][qMin(allRoutes[i][j], allRoutes[i][j + 1])]->amountOfPheromone += 
			(m_qParameter / allDistances[i]);

	QString result;
	for (int i = 0; i < globalOptimalRoute.count() - 1; ++i)
		result += QString::number(globalOptimalRoute[i]) + "-";
	result += QString::number(globalOptimalRoute[globalOptimalRoute.count() - 1]) + " | dist: " + QString::number(gobalMinimalDistance);

	delete[] allDistances;
	delete[] availableOfNodes;

	if (gobalMinimalDistance < bestDistance || bestDistance == 0)
	{
		bestDistance = gobalMinimalDistance;
		bestRoute = result;
	}

	return result;
}

QString Kernel::getBestRoute()
{
	return bestRoute;
}

#pragma once

#include <QtCore/QList>
#include <QtCore/QString>

class Node
{
public:
	Node(float in_amountOfPheromone) :
		distance(0), amountOfPheromone(in_amountOfPheromone), isEdge(true) {};

	float distance;
	float amountOfPheromone;
	bool isEdge;
};

class Kernel
{
public:
	Kernel(	int		amountOfNodes,
			float	alpha,
			float	beta,
			float	q,
			int		t,
			int		k,
			float	p,
			float	m);

	~Kernel();

	void setNodeProperties(int i, int j, float distance, bool isEdge);
	QString getNextGeneration();

private:
	int		m_amountOfNodes;
	float	m_alphaParameter;
	float	m_betaParameter;
	float	m_qParameter;
	int		m_tParameter;
	int		m_kParameter;
	float	m_pParameter;
	float	m_mParameter;

	int m_iterationsCounter;
	QList<QList<Node*>> graphNodes;
};


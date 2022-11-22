#include "kernel.h"

Kernel::Kernel(QObject *parent)
	: QObject(parent)
{
	m_database = new MathLogic::Matrix(25, 25);
}

Kernel::~Kernel()
{
	delete m_database;
}

void Kernel::updateDatabase(QList<int> newData)
{
	m_correctData.append(newData);

	MathLogic::Matrix a(25, 1);
	MathLogic::Matrix b(1, 25);

	for (int i = 0; i < 25; ++i)
	{
		a.valueOf(i, 0) = newData[i];
		b.valueOf(0, i) = newData[i];
	}

	*m_database = *m_database + (a * b);
}

void Kernel::closeDatabase()
{
	*m_database = *m_database / 25;

	for (int i = 0; i < 25; ++i)
	{
		m_database->valueOf(i, i) = 0;
	}
}

void Kernel::clearDatabase()
{
	m_correctData.clear();
	m_database->clear();
}

QPair<int, int> Kernel::test(QList<int> newData)
{
	MathLogic::Matrix a(25, 1);
	MathLogic::Matrix b(25, 1);

	for (int i = 0; i < 25; ++i)
		a.valueOf(i, 0) = newData[i];

	b = *m_database * a;

	for (int i = 0; i < 25; ++i)
		a.valueOf(i, 0) = sign(a.valueOf(i, 0));

	int coincidence = 0;
	int theBestData = -1;
	int theBestCoincidence = 0;
	for (int i = 0; i < m_correctData.count(); ++i)
	{
		for (int j = 0; j < m_correctData[i].count(); ++j)
		{
			if (a.valueOf(j, 0) == m_correctData[i][j])
				++coincidence;
		}
		if (coincidence > theBestCoincidence)
		{
			theBestCoincidence = coincidence;
			theBestData = i;
		}
		coincidence = 0;
	}

	if (theBestCoincidence < 18)
		return QPair<int, int>(2, -1);
	if (theBestCoincidence < 25)
		return QPair<int, int>(1, theBestData);
	return QPair<int, int>(0, theBestData);
}

int Kernel::sign(float value)
{
	return value > 0 ? 1 : -1;
}

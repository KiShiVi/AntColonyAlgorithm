#pragma once

#include <QObject>
#include "matrix.h"

class Kernel  : public QObject
{
	Q_OBJECT

public:
	Kernel(QObject *parent=nullptr);
	~Kernel();
	void				updateDatabase(QList<int> newData);
	void				closeDatabase();
	void				clearDatabase();
	QPair<int, int>		test(QList<int> newData);

private:
	int					sign(float value);

	QList<QList<int>>	m_correctData;
	MathLogic::Matrix*	m_database;
};

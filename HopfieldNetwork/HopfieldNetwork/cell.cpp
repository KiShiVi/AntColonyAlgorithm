#include "cell.h"

Cell::Cell(QPair<int, int> coords, QWidget *parent)
	: QLabel(parent)
{
	initGui();
	m_coords = coords;
	m_isBlack = false;
	m_enabled = true;
	connect(this, SIGNAL(clicked(Cell*)), this, SLOT(onClicked()));
}

Cell::~Cell()
{}

void Cell::setEnable(bool value)
{
	m_enabled = value;
}

void Cell::setBlacked(bool value)
{
	m_isBlack = value;
}

bool Cell::isEnable()
{
	return m_enabled;
}

bool Cell::isBlacked()
{
	return m_isBlack;
}

void Cell::initGui()
{
	setFixedSize(45, 45);
	setStyleSheet("QLabel{ border: 1px solid black; }");
}

void Cell::mouseReleaseEvent(QMouseEvent* e)
{
	if (e->button() == Qt::LeftButton)
		emit clicked(this);
}

void Cell::onClicked()
{
	if (!m_enabled)
		return;
	if (m_isBlack)
	{
		setStyleSheet("QLabel{ border: 1px solid black; background: rgb(255, 255, 255); }");
		m_isBlack = false;
	}
	else
	{
		setStyleSheet("QLabel{ border: 1px solid black; background: rgb(0, 0, 0); }");
		m_isBlack = true;
	}
}

#pragma once

#include <QLabel>
#include <QMouseEvent>

class Cell : public QLabel
{
	Q_OBJECT

public:
	Cell(QPair<int, int> coords, QWidget *parent = nullptr);
	~Cell();
	void setEnable(bool value);
	void setBlacked(bool value);
	bool isEnable();
	bool isBlacked();

signals:
	void clicked(Cell* sender);

private:
	void initGui();

private slots:
	void onClicked();

private:
	QPair<int, int> m_coords;
	bool m_enabled;
	bool m_isBlack;

protected:
	void mouseReleaseEvent(QMouseEvent* e);
};

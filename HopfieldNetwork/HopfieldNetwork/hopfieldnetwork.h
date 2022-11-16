#pragma once

#include <QtWidgets/QWidget>
#include "kernel.h"

class QLineEdit;
class QPushButton;
class Cell;

class HopfieldNetwork : public QWidget
{
    Q_OBJECT

public:
    HopfieldNetwork(QWidget *parent = nullptr);
    ~HopfieldNetwork();

private:
    void initGui();
    QList<int>  readWorkSpace();

private slots:
    void        onClearButtonclicked();
    void        onOKButtonclicked();
    void        onFinishButtonclicked();
    void        onTestButtonclicked();

private:
    QList<QString>          dataBase;
    QList<QList<Cell*>>     m_cells;
    QLineEdit*              p_resultText;
    QPushButton*            p_okButton;
    QPushButton*            p_clearDBButton;
    QPushButton*            p_finishDBButton;
    QPushButton*            p_testButton;
    Kernel*                 p_kernel;
};

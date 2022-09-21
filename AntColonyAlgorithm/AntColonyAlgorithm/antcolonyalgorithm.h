#pragma once

#include <QtWidgets/QWidget>

class QSpinBox;
class QDoubleSpinBox;
class QGridLayout;
class QLineEdit;
class QTextEdit;
class QProgressBar;

class AntColonyAlgorithm : public QWidget
{
    Q_OBJECT

public:
    AntColonyAlgorithm(QWidget *parent = nullptr);
    ~AntColonyAlgorithm() {};

private:
    void initConnects();

private slots:
    void updateAmountOfInputFields(const int amountOfNodes);
    void onApplyButtonClicked();

private:
    QGridLayout*                graphToolLayout;
    QSpinBox*                   p_amountOfNodes;

    QDoubleSpinBox*             p_alphaParameter; // �������� � ��������
    QDoubleSpinBox*             p_betaParameter;  // �������� � �������� ���������
    QDoubleSpinBox*             p_qParameter;     // ��������� ��� ���������� ������������ �������� �� �����
    QSpinBox*                   p_tParameter;     // ���������� ��������
    QSpinBox*                   p_kParameter;     // ���������� ��������
    QDoubleSpinBox*             p_pParameter;     // �������� ��������� ���������
    QDoubleSpinBox*             p_mParameter;     // ���������� ������������ �������� �� ������

    QProgressBar*               p_progressBar;

    QTextEdit*                  p_resultBrowser;

    QList<QList<QSpinBox*>>     listOfGraphNodes;

};

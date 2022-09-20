#pragma once

#include <QtWidgets/QWidget>

class QSpinBox;
class QGridLayout;
class QLineEdit;
class QTextEdit;

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

private:
    QGridLayout*                graphToolLayout;
    QSpinBox*                   p_amountOfNodes;

    QLineEdit*                  p_alphaParameter; // �������� � ��������
    QLineEdit*                  p_betaParameter;  // �������� � �������� ���������
    QLineEdit*                  p_qParameter;     // ��������� ��� ���������� ������������ �������� �� �����
    QLineEdit*                  p_tParameter;     // ���������� ��������
    QLineEdit*                  p_kParameter;     // ���������� ��������
    QLineEdit*                  p_pParameter;     // �������� ��������� ���������
    QLineEdit*                  p_mParameter;     // ���������� ������������ �������� �� ������

    QTextEdit*                  p_resultBrowser;

    QList<QList<QSpinBox*>>     listOfGraphNodes;

};

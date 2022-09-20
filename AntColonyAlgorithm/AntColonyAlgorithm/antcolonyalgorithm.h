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

    QLineEdit*                  p_alphaParameter; // Влечение к феромону
    QLineEdit*                  p_betaParameter;  // Влечение к короткой дистанции
    QLineEdit*                  p_qParameter;     // Константа для вычисления оставляемого феромона на тропе
    QLineEdit*                  p_tParameter;     // Количество итераций
    QLineEdit*                  p_kParameter;     // Количество муравьев
    QLineEdit*                  p_pParameter;     // Скорость испарения феромонов
    QLineEdit*                  p_mParameter;     // Количество изначального феромона на тропах

    QTextEdit*                  p_resultBrowser;

    QList<QList<QSpinBox*>>     listOfGraphNodes;

};

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

    QDoubleSpinBox*             p_alphaParameter; // Влечение к феромону
    QDoubleSpinBox*             p_betaParameter;  // Влечение к короткой дистанции
    QDoubleSpinBox*             p_qParameter;     // Константа для вычисления оставляемого феромона на тропе
    QSpinBox*                   p_tParameter;     // Количество итераций
    QSpinBox*                   p_kParameter;     // Количество муравьев
    QDoubleSpinBox*             p_pParameter;     // Скорость испарения феромонов
    QDoubleSpinBox*             p_mParameter;     // Количество изначального феромона на тропах

    QProgressBar*               p_progressBar;

    QTextEdit*                  p_resultBrowser;

    QList<QList<QSpinBox*>>     listOfGraphNodes;

};

#include "antcolonyalgorithm.h"

#include <QtWidgets/QGroupBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QSpinBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QProgressBar>

#include "kernel.h"

AntColonyAlgorithm::AntColonyAlgorithm(QWidget *parent)
    : QWidget(parent)
{

    listOfGraphNodes = QList<QList<QSpinBox*>>();

    QHBoxLayout* amountOfNodesToolLayout = new QHBoxLayout();
    p_amountOfNodes = new QSpinBox();
    p_amountOfNodes->setMinimum(3);
    p_amountOfNodes->setMaximum(25);
    p_amountOfNodes->setValue(4);

    amountOfNodesToolLayout->addWidget(p_amountOfNodes);
    amountOfNodesToolLayout->addWidget(new QLabel(" - Amount of nodes"));

    graphToolLayout = new QGridLayout();
    graphToolLayout->setAlignment(Qt::AlignRight);

    QVBoxLayout* graphMultiToolsLayout = new QVBoxLayout();
    graphMultiToolsLayout->addLayout(amountOfNodesToolLayout);
    graphMultiToolsLayout->addSpacing(10);
    graphMultiToolsLayout->addLayout(graphToolLayout);
    graphMultiToolsLayout->addStretch(1);

    p_alphaParameter    = new QDoubleSpinBox();
    p_betaParameter     = new QDoubleSpinBox();
    p_qParameter        = new QDoubleSpinBox();
    p_tParameter        = new QSpinBox();
    p_kParameter        = new QSpinBox();
    p_pParameter        = new QDoubleSpinBox();
    p_mParameter        = new QDoubleSpinBox();

    p_alphaParameter->setMinimum(0);
    p_alphaParameter->setMaximum(99);

    p_betaParameter->setMinimum(0);
    p_betaParameter->setMaximum(99);

    p_qParameter->setMinimum(0);
    p_qParameter->setMaximum(9999);

    p_tParameter->setMinimum(0);
    p_tParameter->setMaximum(99999);

    p_kParameter->setMinimum(0);
    p_kParameter->setMaximum(999);

    p_pParameter->setMinimum(0);
    p_pParameter->setMaximum(1);

    p_mParameter->setMinimum(0);
    p_mParameter->setMaximum(1);

    QGridLayout* parametersGridLayout = new QGridLayout();
    parametersGridLayout->addWidget(p_alphaParameter, 0, 0);
    parametersGridLayout->addWidget(new QLabel(" - Alpha"), 0, 1);
    parametersGridLayout->addWidget(p_betaParameter, 0, 2);
    parametersGridLayout->addWidget(new QLabel(" - Beta"), 0, 3);

    parametersGridLayout->addWidget(p_qParameter, 1, 0);
    parametersGridLayout->addWidget(new QLabel(" - Q"), 1, 1);
    parametersGridLayout->addWidget(p_tParameter, 1, 2);
    parametersGridLayout->addWidget(new QLabel(" - T"), 1, 3);

    parametersGridLayout->addWidget(p_kParameter, 2, 0);
    parametersGridLayout->addWidget(new QLabel(" - K"), 2, 1);
    parametersGridLayout->addWidget(p_pParameter, 2, 2);
    parametersGridLayout->addWidget(new QLabel(" - p"), 2, 3);

    parametersGridLayout->addWidget(p_mParameter, 3, 0);
    parametersGridLayout->addWidget(new QLabel(" - m"), 3, 1);

    p_resultBrowser = new QTextEdit();
    p_resultBrowser->setMinimumWidth(600);
    QPushButton* applyButton = new QPushButton("Start alghoritm");
    connect(applyButton, SIGNAL(clicked()), this, SLOT(onApplyButtonClicked()));

    p_progressBar = new QProgressBar();

    QVBoxLayout* rightSideToolsLayout = new QVBoxLayout();
    rightSideToolsLayout->addLayout(parametersGridLayout);
    //rightSideToolsLayout->addStretch(0);
    rightSideToolsLayout->addWidget(p_resultBrowser);
    rightSideToolsLayout->addWidget(applyButton);
    rightSideToolsLayout->addWidget(p_progressBar);

    QHBoxLayout* mainLayout = new QHBoxLayout();
    mainLayout->addLayout(graphMultiToolsLayout);
    mainLayout->addSpacing(100);
    mainLayout->addLayout(rightSideToolsLayout);

    updateAmountOfInputFields(p_amountOfNodes->value());
    initConnects();
    setLayout(mainLayout);
}

void AntColonyAlgorithm::initConnects()
{
    connect(p_amountOfNodes, SIGNAL(valueChanged(int)), this, SLOT(updateAmountOfInputFields(int)));
}

void AntColonyAlgorithm::updateAmountOfInputFields(const int amountOfNodes)
{
    listOfGraphNodes.clear();
    QLayoutItem* item;
    while (item = graphToolLayout->itemAt(0))
    {
        graphToolLayout->removeItem(item);
        graphToolLayout->removeWidget(item->widget());
        delete item->widget();
        delete item;
        graphToolLayout->update();
    }

    listOfGraphNodes.append(QList<QSpinBox*>());

    for (int i = 1; i < amountOfNodes; ++i)
    {
        listOfGraphNodes.append(QList<QSpinBox*>());
        for (int j = 0; j < amountOfNodes - 1; ++j)
        {
            if (i > j)
            {
                listOfGraphNodes[i].append(new QSpinBox());
                listOfGraphNodes[i][j]->setMinimum(0);
                listOfGraphNodes[i][j]->setMaximum(999);
                listOfGraphNodes[i][j]->setValue(0);
                graphToolLayout->addWidget(listOfGraphNodes[i][j], j, i);
            }
        }
    }
}

void AntColonyAlgorithm::onApplyButtonClicked()
{
    p_progressBar->setValue(0);
    p_resultBrowser->clear();
    Kernel kernel(p_amountOfNodes->value(), p_alphaParameter->value(), p_betaParameter->value(),
        p_qParameter->value(), p_tParameter->value(), p_kParameter->value(), p_pParameter->value(),
        p_mParameter->value());

    for (int i = 1; i < p_amountOfNodes->value(); ++i)
    {
        for (int j = 0; j < p_amountOfNodes->value() - 1; ++j)
        {
            if (i > j)
            {
                if (listOfGraphNodes[i][j]->value() != 0)
                    kernel.setNodeProperties(i, j, listOfGraphNodes[i][j]->value(), true);
                else
                    kernel.setNodeProperties(i, j, 0, false);
            }
        }
    }
    p_progressBar->setMaximum(p_tParameter->value());
    for (int i = 0; i < p_tParameter->value(); ++i)
    {
        p_progressBar->setValue(i);
        p_resultBrowser->append(QString::number(i) + ": " + kernel.getNextGeneration());
    }
    p_resultBrowser->append("Best route: " + kernel.getBestRoute());
    p_progressBar->reset();
}
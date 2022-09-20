#include "antcolonyalgorithm.h"

#include <QtWidgets/QGroupBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QSpinBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QPushButton>

AntColonyAlgorithm::AntColonyAlgorithm(QWidget *parent)
    : QWidget(parent)
{
    listOfGraphNodes = QList<QList<QSpinBox*>>();

    QHBoxLayout* amountOfNodesToolLayout = new QHBoxLayout();
    p_amountOfNodes = new QSpinBox();
    p_amountOfNodes->setMinimum(2);
    p_amountOfNodes->setMaximum(15);
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

    p_alphaParameter    = new QLineEdit();
    p_betaParameter     = new QLineEdit();
    p_qParameter        = new QLineEdit();
    p_tParameter        = new QLineEdit();
    p_kParameter        = new QLineEdit();
    p_pParameter        = new QLineEdit();
    p_mParameter        = new QLineEdit();

    QDoubleValidator*   doubleValidator     = new QDoubleValidator(0, 999, 3);
    QIntValidator*      intValidator        = new QIntValidator(0, 999);
    doubleValidator->setNotation(QDoubleValidator::StandardNotation);

    p_alphaParameter    ->setValidator(doubleValidator);
    p_betaParameter     ->setValidator(doubleValidator);
    p_qParameter        ->setValidator(doubleValidator);
    p_tParameter        ->setValidator(intValidator);
    p_kParameter        ->setValidator(intValidator);
    p_pParameter        ->setValidator(doubleValidator);
    p_mParameter        ->setValidator(doubleValidator);

    QGridLayout* parametersGridLayout = new QGridLayout();
    parametersGridLayout->addWidget(p_alphaParameter, 0, 0);
    parametersGridLayout->addWidget(new QLabel(" - Alpha"), 0, 1);
    parametersGridLayout->addWidget(p_betaParameter, 0, 2);
    parametersGridLayout->addWidget(new QLabel(" - Beta"), 0, 3);

    parametersGridLayout->addWidget(p_qParameter, 1, 0);
    parametersGridLayout->addWidget(new QLabel(" - Q"), 1, 1);
    parametersGridLayout->addWidget(p_tParameter, 1, 2);
    parametersGridLayout->addWidget(new QLabel(" - K"), 1, 3);

    parametersGridLayout->addWidget(p_kParameter, 2, 0);
    parametersGridLayout->addWidget(new QLabel(" - K"), 2, 1);
    parametersGridLayout->addWidget(p_pParameter, 2, 2);
    parametersGridLayout->addWidget(new QLabel(" - p"), 2, 3);

    parametersGridLayout->addWidget(p_mParameter, 3, 0);
    parametersGridLayout->addWidget(new QLabel(" - m"), 3, 1);

    p_resultBrowser = new QTextEdit();
    QPushButton* applyButton = new QPushButton("Start alghoritm");

    QVBoxLayout* rightSideToolsLayout = new QVBoxLayout();
    rightSideToolsLayout->addLayout(parametersGridLayout);
    rightSideToolsLayout->addStretch(0);
    rightSideToolsLayout->addWidget(p_resultBrowser);
    rightSideToolsLayout->addWidget(applyButton);

    QHBoxLayout* mainLayout = new QHBoxLayout();
    mainLayout->addLayout(graphMultiToolsLayout);
    mainLayout->addStretch(0);
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
                graphToolLayout->addWidget(listOfGraphNodes[i][j], amountOfNodes - i, amountOfNodes - j);
            }
        }
    }
}

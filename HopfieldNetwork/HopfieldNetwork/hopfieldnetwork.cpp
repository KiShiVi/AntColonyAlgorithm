#include "hopfieldnetwork.h"
#include "cell.h"

#include <QGridLayout>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QGroupBox>
#include <QPushButton>
#include <QLineEdit>

HopfieldNetwork::HopfieldNetwork(QWidget *parent)
    : QWidget(parent)
{
    initGui();
    p_kernel = new Kernel();
}

HopfieldNetwork::~HopfieldNetwork()
{}

void HopfieldNetwork::initGui()
{
    setMinimumSize(350, 350);

    QGridLayout* workTable = new QGridLayout();
    workTable->setSpacing(0);
    workTable->setContentsMargins(0, 0, 0, 0);

    for (int i = 0; i < 5; ++i)
    {
        m_cells.append(QList<Cell*>());
        for (int j = 0; j < 5; ++j)
        {
            m_cells[i].append(new Cell(QPair<int, int>(i, j)));
            workTable->addWidget(m_cells[i][j], i, j);
        }
    }

    p_resultText    = new QLineEdit();
    p_okButton      = new QPushButton("OK");

    QVBoxLayout* vWorkTableLayout = new QVBoxLayout();
    vWorkTableLayout->addLayout(workTable);
    vWorkTableLayout->addWidget(p_resultText);
    vWorkTableLayout->addWidget(p_okButton);
    vWorkTableLayout->addStretch(10);

    p_clearDBButton      = new QPushButton("Clear database");
    p_finishDBButton     = new QPushButton("Finish database");
    p_testButton         = new QPushButton("Test");

    connect(p_okButton, SIGNAL(clicked()), this, SLOT(onOKButtonclicked()));
    connect(p_finishDBButton, SIGNAL(clicked()), this, SLOT(onFinishButtonclicked()));
    connect(p_testButton, SIGNAL(clicked()), this, SLOT(onTestButtonclicked()));
    connect(p_clearDBButton, SIGNAL(clicked()), this, SLOT(onClearButtonclicked()));

    QVBoxLayout* vToolsLayout = new QVBoxLayout();
    vToolsLayout->addWidget(p_clearDBButton);
    vToolsLayout->addWidget(p_finishDBButton);
    vToolsLayout->addWidget(p_testButton);
    vToolsLayout->addStretch(10);

    QHBoxLayout* mainLayout = new QHBoxLayout();
    mainLayout->addLayout(vWorkTableLayout);
    mainLayout->addLayout(vToolsLayout);
    mainLayout->addStretch(10);
    setLayout(mainLayout);

    p_testButton->setEnabled(false);
    p_finishDBButton->setEnabled(false);
}

QList<int> HopfieldNetwork::readWorkSpace()
{
    QList<int> result;

    for(int i = 0; i < 5; ++i)
        for (int j = 0; j < 5; ++j)
        {
            int temp = m_cells[i][j]->isBlacked() ? 1 : -1;
            result.append(temp);
        }

    return result;
}

void HopfieldNetwork::onClearButtonclicked()
{
    dataBase.clear();
    p_kernel->clearDatabase();
    p_okButton->setEnabled(true);
    p_testButton->setEnabled(false);
    p_finishDBButton->setEnabled(false);
}

void HopfieldNetwork::onOKButtonclicked()
{
    p_kernel->updateDatabase(readWorkSpace());
    dataBase.append(p_resultText->text());
    p_finishDBButton->setEnabled(true);
}

void HopfieldNetwork::onFinishButtonclicked()
{
    p_kernel->closeDatabase();
    p_finishDBButton->setEnabled(false);
    p_okButton->setEnabled(false);
    p_testButton->setEnabled(true);
}

void HopfieldNetwork::onTestButtonclicked()
{
    QPair<int, int> a = p_kernel->test(readWorkSpace());
    p_resultText->clear();
    switch (a.first)
    {
    case 0:
        p_resultText->setText("That's exactly - " + dataBase[a.second]);
        break;
    case 1:
        p_resultText->setText("That's probably - " + dataBase[a.second]);
        break;
    case 2:
        p_resultText->setText("I don't know");
        break;
    default:
        break;
    }
}

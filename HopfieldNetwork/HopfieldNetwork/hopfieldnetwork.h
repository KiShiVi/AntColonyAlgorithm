#pragma once

#include <QtWidgets/QWidget>
#include "ui_hopfieldnetwork.h"

class HopfieldNetwork : public QWidget
{
    Q_OBJECT

public:
    HopfieldNetwork(QWidget *parent = nullptr);
    ~HopfieldNetwork();

private:
    Ui::HopfieldNetworkClass ui;
};

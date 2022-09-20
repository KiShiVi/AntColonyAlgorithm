#include "antcolonyalgorithm.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    AntColonyAlgorithm w;
    w.show();
    return a.exec();
}

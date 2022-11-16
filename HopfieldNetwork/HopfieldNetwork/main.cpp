#include "hopfieldnetwork.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    HopfieldNetwork w;
    w.show();
    return a.exec();
}

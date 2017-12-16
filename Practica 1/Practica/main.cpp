#include "mainwindow.h"
#include <QApplication>

using namespace std;
/*
struct avion
{
    string tipo;
    int pasajero;
    int turno;
    int turno_mantenimiento;
};

struct pasajero
{
    int id;
    int maleta;
    int documento;
    int turno_registro;
};
*/



int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;

    w.show();

    return a.exec();
}

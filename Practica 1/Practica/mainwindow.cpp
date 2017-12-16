#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "lista.h"
#include "cola.h"
#include "listasimple.h"
#include "listadobleordenada.h"
#include "listacircular.h"
#include "pila.h"
#include <fstream>
#include "time.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{
    delete ui;

}

int turnos = -1;
int avion = -1;
int escritorio;
int estaciones;
int turnoActual =0;
bool primeraVez = false;
bool primerAvion = false;
bool arriboavion= false;
int avionesingresados=0;
string mensaj;

ListaDoble aviones;
ListaDoble esperaMantenimiento;
ListaSimple estacion;
Cola espera;
ListaDobleO escritorios;
ListaCircular equipaje;




void InsertarEscritorios()
{


    InsertarLDOO(&escritorios,escritorios.nom,0,0,0);



}

void InsertarEstaciones()
{
    InsertarLS(&estacion,0,0,0);

}

void InsertarColaEspera()
{
    //srand(time(NULL));
    int maleta = 1+(rand()%4);
    //srand(time(NULL));
    int documentos = 1+(rand()%10);
    //srand(time(NULL));
    int turnos = 1+(rand()%3);
    //srand(time(NULL));
    InsertarC(&espera,maleta,documentos,turnos);
}
void InsertarEsperaMantenimiento()
{
    if(aviones.primero != NULL)
    {
    int id_ = aviones.primero->id;
    string tipo_ = aviones.primero->tipo;
    int pasajeros_ = aviones.primero->pasajeros;
    int mantenimiento_ = aviones.primero->mantenimiento;
    EliminarLD(&aviones);

    InsertarLDNodo(&esperaMantenimiento,id_,tipo_,pasajeros_,0,mantenimiento_);
    avionesingresados = avionesingresados +1;
    }
}

void InsertarColaVentanilla()
{

    NodoEscritorios *q = escritorios.primero;
    //NodoPasajeros *p = espera.primero;

    while(espera.primero != NULL)
    {
        if(espera.primero == NULL)
        {
            break;
        }else if(q->siguiente == NULL && q->espera.count == 10)
        {
            break;
        }else
        {
            if(q->espera.count <= 9)
            {
                if(espera.primero != NULL)
                {

                //cout << "contador en la ventanilla: " << q->espera.count << endl;
                int id = espera.primero->id;
                int maleta = espera.primero->maletas;
                int documentos = espera.primero->documentos;
                int turnos = espera.primero->turnos;
                //p = p->siguiente;
                //    PasarCola(&espera,&(q->espera));
                    EliminarC(&espera);

                    for(int i = 0 ; i < maleta ; i++)
                    {
                        InsertarLC(&equipaje,id);
                    }
                    InsertarCNodo(&(q->espera),id,maleta,documentos,turnos);

                }



                //cout << "contador en la cola de espera: " << espera.count << endl;

                if(espera.primero == NULL)
                {
                    break;
                }
            }else
            {
                q = q->siguiente;
            }
        }


    }


}

void ComprobarVentanillas()
{
    NodoEscritorios *q = escritorios.primero;


    while(q != NULL)
    {

        if(q->estado == 1)
        {

            if(q->turnos==0)
            {

                for(int i =0; i<q->revision->maletas;i++)
                {
                    if(equipaje.primero != NULL)
                    {
                        EliminarLC(&equipaje );
                    }else{break;}

                }
                //EliminarLCV(&equipaje,q->idPasajero);
                for(int i =0; i< q->revision->documentos;i++)
                {

                    if(q->documento.primero != NULL)
                    {
                        EliminarP(&(q->documento) );
                    }else {break;}


                }
                //VaciarPila(&(q->documento));

                    //QuitarVentanilla(&(q));
                    delete q->revision;
                    q->turnos = 0;
                    q->estado = 0;
                    q->documentos = 0;
                    q->idPasajero = 0;






            }else
            {

                q->turnos = (q->turnos)-1;
            }


        }else if(q->estado == 0)
        {
            if(q->espera.primero != NULL)
            {

                NodoPasajeros *auxiliar = q->espera.primero;

                if(auxiliar == NULL)
                {

                }
                else if(q->espera.primero != q->espera.ultimo)
                {
                    q->espera.primero = auxiliar->siguiente;
                    q->revision = auxiliar;
                    q->espera.count= (q->espera.count)-1 ;
                }else if(q->espera.primero == q->espera.ultimo)
                {
                    q->espera.ultimo = NULL;
                    //lis->primero = auxiliar->siguiente;
                    q->espera.primero=NULL;
                    q->revision = auxiliar;
                    //lis->primero = NULL;
                    q->espera.count= (q->espera.count)-1;
                }




                q->turnos = q->revision->turnos;
                q->estado = 1;
                q->documentos = q->revision->documentos;
                q->idPasajero = q->revision->id;
                for(int i =0; i< q->revision->documentos ; i++)
                {
                    InsertarP(&(q->documento),q->idPasajero);
                }
                //PasarVentanilla(&(q->espera),&q);

            }


        }
        q = q->siguiente;
    }


}



void ComprobarEstaciones()
{

    NodoMantenimiento *q = estacion.primero;

    //cout << "Afuera" <<endl;
    while(q != NULL)
    {
        //cout << "Adentro" <<endl;
        if(q->estado == 0)
        {
            //cout << "Adentro 2" <<endl;
            if(esperaMantenimiento.primero != NULL)
            {
                q->estado=1;
                q->avion=esperaMantenimiento.primero->id;
                q->turnos = esperaMantenimiento.primero->mantenimiento;
                PasarRevision(&esperaMantenimiento,&estacion);
                //cout << "Estacion vacia cola mant con elementos" <<endl;
            }


        }else if(q->estado == 1)
        {
            //cout << "Adentro 3" <<endl;
            if(q->turnos == 0)
            {
                //cout << "Adentro 4" <<endl;



                    EliminandoRevision(&estacion);
                    avionesingresados = avionesingresados -1;
                    //cout << "Aviones ingresados: "<< avionesingresados <<endl;


                    q->estado=0;
                    q->avion=0;
                    q->turnos = 0;

                    //cout << "Estacion llena cola mant con elementos" <<endl;



            }
            else
            {


                    q->turnos = (q->turnos)-1;


                //cout << "Quitando turnos faltan: "<< q->turnos <<endl;
            }
        }

        q = q->siguiente;
    }
}





void Imprimir()
{
    --turnos;
    ++turnoActual;
    //mensaje = "";
    string mensaje;
    mensaje += "*********Turno ";
    mensaje += std::to_string(turnoActual);
    mensaje += "*************\n";
    if(arriboavion == true)
    {
        mensaje += "Arribo Avion: ";
        mensaje += std::to_string(aviones.ultimo->id);
        mensaje += "\n";
        arriboavion = false;
    }else
    {
        mensaje += "Arribo Avion: Ninguno\n";
    }
    if(aviones.primero != NULL)
    {
        mensaje += "Avion Desabordando: ";
        mensaje += std::to_string(aviones.primero->id);
        mensaje += "\n";
    }else
    {
        mensaje += "Avion Desabordando: Ninguno\n";
    }
    mensaje += "------Escritorios de Registro--------\n";

    NodoEscritorios *m = escritorios.primero;

    while(m != NULL)
    {
        string est ;
        if(m->estado == 0)
        {
             est = "libre";
        }else
        {
            est = "ocupado";
        }
        mensaje += "    Escritorio ";
        mensaje += m->id;
        mensaje += ": ";
        mensaje += est;
        mensaje += "\n";
        mensaje += "    Usuario Atendido: ";
        mensaje += std::to_string(m->idPasajero);
        mensaje += "\n";
        mensaje += "    Turnos Restantes: ";
        mensaje += std::to_string(m->turnos);
        mensaje += "\n";
        mensaje += "    Cantidad de documentos: ";
        mensaje += std::to_string(m->documentos);
        mensaje += "\n";

        m = m->siguiente;

    }

    mensaje += "+++++Estaciones de Servicio++++++\n";



    NodoMantenimiento *n = estacion.primero;

    while(n != NULL)
    {
        string est ;
        if(n->estado == 0)
        {
             est = "libre";
        }else
        {
            est = "ocupado";
        }
        mensaje += "    Estacion ";
        mensaje += std::to_string(n->id);
        mensaje += ": ";
        mensaje += est;
        mensaje += "\n";
        if(n->avion == 0)
        {
            mensaje += "    Avion en Mantenimiento: Ninguno\n";
        }else
        {
            mensaje += "    Avion en Mantenimiento: ";
            mensaje += std::to_string(n->avion);
            mensaje += "\n";
        }

        mensaje += "    Turnos Restantes: ";
        mensaje += std::to_string(n->turnos);
        mensaje += "\n";
        n = n->siguiente;

    }
    if(equipaje.primero != NULL)
    {
        mensaje += "+++++++++++++++++++++++++++++++++\n";
        mensaje += "Cantidad de maletas actualmente en el sistema: ";
        mensaje += std::to_string(equipaje.count);
        mensaje += "\n";
    }else
    {
        mensaje += "+++++++++++++++++++++++++++++++++\n";
        mensaje += "Cantidad de maletas actualmente en el sistema: ";
        mensaje += std::to_string(0);
        mensaje += "\n";
    }

    mensaje += "Turnos Restantes ";
    mensaje += std::to_string(turnos);
    mensaje += "\n";
    mensaje += "**********Fin de Turno ";
    mensaje += std::to_string(turnoActual);
    mensaje += "*************";


    //std:: cout <<mensaje <<endl;

    mensaj = mensaje + "\n"+mensaj;



}

//string txtArchivo;


void GuardandoArchivo(string txtArchivo)
{

    ofstream ar;
    ar.open("C://EDD//grafo.dot",ios::out);
    ar << txtArchivo <<endl;

    ar.close();


    system(" dot -Tjpg C:\\EDD\\grafo.dot -o C:\\EDD\\grafo.jpg ");
}

void CreandoCadena()
{
    string txtArchivo;


    NodoAviones *q = aviones.primero;

    int slash = 92;
    int comilla = 34;
    txtArchivo ="";
    txtArchivo += "digraph Hola{\n";
    txtArchivo += "subgraph cluster_0{\n";
    txtArchivo += "encabezadoAviones[label = DesabordaAviones color = blue style= filled fontcolor = white shape = box];\n";
//aviones
    while(q != NULL)
    {
        if(q->anterior == NULL)
        {
            txtArchivo += "node[shape = record label= ";
            txtArchivo += 34;
            txtArchivo += "Avion: "+std::to_string(q->id)+"";
            txtArchivo += slash;
            txtArchivo += "l Tamaño:"+q->tipo+"";
            txtArchivo += slash;
            txtArchivo += "l Pasajeros: "+to_string(q->pasajeros);
            txtArchivo += slash;
            txtArchivo += "l Turnos: "+to_string(q->desabordaje);
            txtArchivo += 34;
            txtArchivo += "]"+std::to_string(q->id)+";\n";
            txtArchivo += "encabezadoAviones -> "+std::to_string(q->id) +" [color = white];\n";
        }else
        {
            txtArchivo += "node[shape = record label= ";
            txtArchivo += 34;
            txtArchivo += "Avion: "+std::to_string(q->id)+"";
            txtArchivo += slash;
            txtArchivo += "l Tamaño:"+q->tipo+"";
            txtArchivo += slash;
            txtArchivo += "l Pasajeros: "+to_string(q->pasajeros);
            txtArchivo += slash;
            txtArchivo += "l Turnos: "+to_string(q->desabordaje);
            txtArchivo += 34;
            txtArchivo += "]"+std::to_string(q->id)+";\n";


            txtArchivo += std::to_string(q->anterior->id)+" -> "+std::to_string(q->id)+";\n";
            txtArchivo += std::to_string(q->id)+" ->"+std::to_string(q->anterior->id)+";\n";

        }
        q = q->siguiente;
    }
    txtArchivo += "color = blue \n}";


    //cola espera despues de desabordaje
    NodoPasajeros *p = espera.primero;
    txtArchivo += "subgraph cluster_1{\n";
    txtArchivo += "encabezadoDesabordaje[label = ColaPasajeros color = blue style= filled fontcolor = white shape = box];\n";
    int idpa;
    while(p!= NULL)
    {

        if(p == espera.primero)
        {
            txtArchivo += "node[shape = record label= ";
            txtArchivo += comilla;
            txtArchivo += "Pasajero: "+std::to_string(p->id)+"";
            txtArchivo += slash;
            txtArchivo += "l Maletas:"+to_string(p->maletas)+"";
            txtArchivo += slash;
            txtArchivo += "l Documentos: "+to_string(p->documentos)+"";
            txtArchivo += comilla;
            txtArchivo += "]"+std::to_string(p->direccion)+";\n";
            txtArchivo += "encabezadoDesabordaje -> "+std::to_string(p->direccion)+" [color = white];\n";
        }else
        {
            txtArchivo += "node[shape = record label= ";
            txtArchivo += comilla;
            txtArchivo += "Pasajero: "+std::to_string(p->id)+"";
            txtArchivo += slash;
            txtArchivo += "l Maletas:"+to_string(p->maletas)+"";
            txtArchivo += slash;
            txtArchivo += "l Documentos: "+to_string(p->documentos)+"";
            txtArchivo += comilla;
            txtArchivo += "]"+std::to_string(p->direccion)+";\n";
            txtArchivo += std::to_string(idpa)+" -> "+std::to_string(p->direccion)+";\n";
        }
        idpa = p->direccion;
        p=p->siguiente;
    }
    txtArchivo += "color= blue \n}";



    //ventanillas---------------------------------------------------


    txtArchivo += "subgraph cluster_2{\n";
    txtArchivo += "encabezadoVentanilla[label = Ventanillas color = blue style= filled fontcolor = white shape = box];\n";



    NodoEscritorios *e = escritorios.primero;
    NodoDocumentos *d;

    int idEA= e->direccion;
    string est;
    while(e != NULL)
    {
        if(e->estado==0)
        {
            est = "libre";
        }else
        {
            est = "ocupado";
        }




        if(e != escritorios.primero)
        {


            txtArchivo += "node[shape = record label= ";
            txtArchivo += comilla;
            txtArchivo += "Escritorio: ";
            txtArchivo += e->id;
            txtArchivo += "";
            txtArchivo += slash;
            txtArchivo += "l cliente: "+to_string(e->idPasajero)+"";
            txtArchivo += slash;
            txtArchivo += "l estado:"+est+"";
            txtArchivo += slash;
            txtArchivo += "l Documentos:"+to_string(e->documentos)+"";
            txtArchivo += slash;
            txtArchivo += "l Turnos: "+to_string(e->turnos);
            txtArchivo += comilla;
            txtArchivo += "]"+std::to_string(e->direccion)+";\n";
            txtArchivo += to_string(e->direccion)+" -> "+ to_string(idEA)+";\n";
            txtArchivo += to_string(idEA)+" -> "+to_string(e->direccion)+";\n";
            //txtArchivo += "encabezadoVentanilla -> "+to_string(e->direccion)+" [color = white];\n";



        }else
        {
            txtArchivo += "node[shape = record label= ";
            txtArchivo += comilla;
            txtArchivo += "Escritorio: ";
            txtArchivo += e->id;
            txtArchivo += "";
            txtArchivo += slash;
            txtArchivo += "l cliente: "+to_string(e->idPasajero)+"";
            txtArchivo += slash;
            txtArchivo += "l estado:"+est+"";
            txtArchivo += slash;
            txtArchivo += "l Documentos:"+to_string(e->documentos)+"";
            txtArchivo += slash;
            txtArchivo += "l Turnos: "+to_string(e->turnos);
            txtArchivo += comilla;
            txtArchivo += "]"+std::to_string(e->direccion)+";\n";
            //txtArchivo += "encabezadoVentanilla -> "+to_string(e->direccion)+" [color = white];\n";

        }


        d = e->documento.primero;

        if(d != NULL)
        {
            idpa = d->id;
            while(d != NULL)
            {
                if(d != e->documento.primero)
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Documento: "+std::to_string(d->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Pasajero: "+to_string(d->pasajero)+"";
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(d->id)+";\n";
                    txtArchivo += to_string(idpa)+" -> "+ to_string(d->id)+";\n";
                }else
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Documento: "+std::to_string(d->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Pasajero: "+to_string(d->pasajero)+"";
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(d->id)+";\n";
                    txtArchivo += to_string(e->direccion)+" -> "+ to_string(d->id)+";\n";

                }
                idpa = d->id;
                d = d->anterior;
            }

        }


        p = e->espera.primero;

        if(p != NULL)
        {
            idpa = p->id;
            while(p != NULL)
            {
                if(p != e->espera.primero)
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Pasajero: "+std::to_string(p->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Maletas:"+to_string(p->maletas)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Documentos: "+to_string(p->documentos)+"";
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(p->direccion)+";\n";
                    txtArchivo += to_string(idpa)+" -> "+ to_string(p->direccion)+";\n";
                }else
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Pasajero: "+std::to_string(p->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Maletas:"+to_string(p->maletas)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Documentos: "+to_string(p->documentos)+"";
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(p->direccion)+";\n";
                    txtArchivo += to_string(e->direccion)+" -> "+ to_string(p->direccion)+";\n";
                }
                idpa = p->direccion;
                p = p->siguiente;
            }
            //txtArchivo += to_string(idpa)+" -> "+ to_string(e->direccion)+" [color = white];\n";
        }
        //cout << "cola de espera terminado"<<endl;



        idEA = e->direccion;
        e = e->siguiente;
    }
    //cout<<"Termino ventanillas"<<endl;

    txtArchivo += "color=blue\n}";

    //maletas

    txtArchivo += "subgraph cluster_3{\n";
    txtArchivo += "maletas[label = Maletas color = blue style= filled fontcolor = white shape = box];\n";
    if(equipaje.primero == NULL)
    {


    }else
    {
        NodoMaletas *m = equipaje.primero;
        idpa = m->id;
        int pri =idpa;

        while(m != NULL)
        {
            if(m == equipaje.primero)
            {
                txtArchivo += "node[shape = record label= ";
                txtArchivo += comilla;
                txtArchivo += "Maleta: "+std::to_string(m->id)+"";
                txtArchivo += slash;
                txtArchivo += "l Pertenece a:"+to_string(m->pasajeroid)+"";
                txtArchivo += comilla;
                txtArchivo += "]"+std::to_string(m->id)+";\n";
            }else
            {
                txtArchivo += "node[shape = record label= ";
                txtArchivo += comilla;
                txtArchivo += "Maleta: "+std::to_string(m->id)+"";
                txtArchivo += slash;
                txtArchivo += "l Pertenece a:"+to_string(m->pasajeroid)+"";
                txtArchivo += comilla;
                txtArchivo += "]"+std::to_string(m->id)+";\n";
                txtArchivo += std::to_string(idpa)+" -> "+std::to_string(m->id)+";\n";
                txtArchivo += std::to_string(m->id)+" -> "+std::to_string(idpa)+";\n";
            }

            idpa = m->id;
            m = m->siguiente;
            if(m == equipaje.ultimo)
            {
                txtArchivo += std::to_string(pri)+" -> "+std::to_string(idpa)+";\n";
                txtArchivo += std::to_string(idpa)+" -> "+std::to_string(pri)+";\n";
                break;
            }
        }

    }
    txtArchivo += "color = blue\n}";
    //cout << "Termino maletas"<<endl;

    //Mantenimiento


    txtArchivo += "subgraph cluster_4{\n";
    txtArchivo += "manteminiento[label = Mantenimiento color = blue style= filled fontcolor = white shape = box];\n";

    if(estacion.primero == NULL)
    {

    }else
    {
        NodoMantenimiento *s = estacion.primero;
        //string est;
            idpa = s->id;
            while(s != NULL)
            {
                if(s->estado == 0)
                {
                    est ="libre";

                }else
                {
                    est = "ocupado";
                }
                if(s == estacion.primero)
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Estacion: "+std::to_string(s->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Avion:"+to_string(s->avion)+"";
                    txtArchivo += slash;
                    txtArchivo += "l estado:"+est+"";
                    txtArchivo += slash;
                    txtArchivo += "l Turnos: "+to_string(s->turnos);
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(s->id)+";\n";

                }else
                {

                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Estacion: "+std::to_string(s->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Avion:"+to_string(s->avion)+"";
                    txtArchivo += slash;
                    txtArchivo += "l estado:"+est+"";
                    txtArchivo += slash;
                    txtArchivo += "l Turnos: "+to_string(s->turnos);
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(s->id)+";\n";
                    txtArchivo += std::to_string(idpa)+" -> "+std::to_string(s->id)+";\n";
                }
                idpa = s->id;
                s = s->siguiente;
            }
    }
    txtArchivo += "subgraph cluster_5{\n";

    if(esperaMantenimiento.primero == NULL)
    {

    }else
    {
        q = esperaMantenimiento.primero;
            while(q != NULL)
            {
                if(q == esperaMantenimiento.primero)
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += comilla;
                    txtArchivo += "Avion: "+std::to_string(q->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Tamaño:"+q->tipo+"";
                    txtArchivo += slash;
                    txtArchivo += "l Pasajeros: "+to_string(q->pasajeros);
                    txtArchivo += comilla;
                    txtArchivo += "]"+std::to_string(q->id)+";\n";

                }else
                {
                    txtArchivo += "node[shape = record label= ";
                    txtArchivo += 34;
                    txtArchivo += "Avion: "+std::to_string(q->id)+"";
                    txtArchivo += slash;
                    txtArchivo += "l Tamaño:"+q->tipo+"";
                    txtArchivo += slash;
                    txtArchivo += "l Pasajeros: "+to_string(q->pasajeros);
                    txtArchivo += 34;
                    txtArchivo += "]"+std::to_string(q->id)+";\n";
                    txtArchivo += std::to_string(q->anterior->id)+" -> "+std::to_string(q->id)+";\n";
                    txtArchivo += std::to_string(q->id)+" ->"+std::to_string(q->anterior->id)+";\n";

                }
                q = q->siguiente;
            }
    }
    txtArchivo += "color = blue \n}\n";

    //cout<<"termino mantenimiento"<<endl;



    txtArchivo += "color = blue\n}";




    txtArchivo += "\n} ";
    GuardandoArchivo(txtArchivo);

}






void MainWindow::on_btnSiguiente_clicked()
{


    srand(time(NULL));
    string tipo;
    int pasajeros;
    int desabordaje;
    int mantenimiento;
    srand(time(NULL));
    int t = rand()%3;
    if(t == 0)
    {
        tipo = "pequeño";
        srand(time(NULL));
        pasajeros = 5+(rand()%6);
        desabordaje = 1;
        srand(time(NULL));
        mantenimiento = 1+(rand()%3);
    }else if(t == 1)
    {
        tipo = "mediano";
        srand(time(NULL));
        pasajeros = 15+(rand()%6);
        desabordaje = 2;
        srand(time(NULL));
        mantenimiento = 2+(rand()%3);
    }else if(t == 2)
    {
        tipo = "grande";
        srand(time(NULL));
        pasajeros = 30+(rand()%11);
        desabordaje = 3;
        srand(time(NULL));
        mantenimiento = 3+(rand()%4);
    }
//primera interaccion
    if(turnos == -1 && primeraVez == false)
    {
        turnos = (ui->txtTurnos->text()).toInt();

        //insertar escritorios
        escritorio = (ui->txtVentanillas->text()).toInt();
        for(int i = 0 ; i < escritorio ; i++)
        {
            InsertarEscritorios();
        }

        //insertar estaciones
        estaciones = (ui->txtEstaciones->text()).toInt();
        //cout << "Estacion: "<<estaciones;
        for(int i=0; i<estaciones; i++)
        {
            InsertarEstaciones();
        }

        //insertar aviones
        avion = (ui->txtAviones->text()).toInt();

        if(avion >0)
        {


            InsertarLD(&aviones,tipo,pasajeros,desabordaje,mantenimiento);
            arriboavion = true;
            //++avionesingresados;
            --avion;
            //cout << "avion ingresado: " << endl;
        }
        if(aviones.primero !=NULL)
        {
            //cout << "desabordaje: " << aviones.primero->desabordaje <<endl;
            if(aviones.primero->desabordaje == 0)
            {
                //pasajeros en la cola
                for(int i =0; i<aviones.primero->pasajeros;i++)
                {
                    InsertarColaEspera();
                }

                //insertar en las ventanillas

                InsertarColaVentanilla();
                //cout << "insertar cola ventanilla terminado"<<endl;

                //aviones en espara para mantenimiento

                InsertarEsperaMantenimiento();


                primerAvion = true;

            }else
            {
                aviones.primero->desabordaje = (aviones.primero->desabordaje) -1;
            }
        }
        if(primerAvion == true)
        {
            //insertar en las ventanillas

            InsertarColaVentanilla();
            //cout << "insertar cola ventanilla terminado2"<<endl;

            //comporbar ventanillas
            ComprobarVentanillas();
            //cout << "comprobar ventanilla terminado"<<endl;

            //comprobar estaciones de mantenimiento
            ComprobarEstaciones();
            //cout << "comprobar estacion terminado"<<endl;

            primerAvion = true;
        }

        primeraVez = true;



        Imprimir();


        QString e = QString::fromStdString(mensaj);
        ui->consola->setText(e);

        CreandoCadena();
        //GuardandoArchivo();

        QPixmap qp("C:/EDD/grafo.jpg");
        ui->lbImg->setPixmap(qp);






    }else if(turnos > 0 && primeraVez == true) //otras interacciones
    {
        if(avion >0)
        {
            InsertarLD(&aviones,tipo,pasajeros,desabordaje,mantenimiento);
            arriboavion = true;
            //++avionesingresados;
            --avion;
            //cout << "avion ingresado: " << endl;
        }
        if(aviones.primero != NULL)
        {
            //cout << "desabordaje: " << aviones.primero->desabordaje <<endl;
            if(aviones.primero->desabordaje == 0)
            {
                //pasajeros en la cola
                for(int i =0; i<aviones.primero->pasajeros;i++)
                {
                    InsertarColaEspera();
                }

                //insertar en las ventanillas

                InsertarColaVentanilla();
                //cout << "insertar cola ventanilla terminado terminado"<<endl;

                //aviones en espara para mantenimiento

                InsertarEsperaMantenimiento();
/*




                //EliminarLD(&aviones);  */

                primerAvion = true;


            }else
            {
                aviones.primero->desabordaje = (aviones.primero->desabordaje)-1;
            }
        }
        if(primerAvion == true)
        {
            //insertar en las ventanillas

            InsertarColaVentanilla();
            //cout << "insertar cola ventanilla terminado terminado2"<<endl;

            //comporbar ventanillas
            ComprobarVentanillas();
            //cout << "comprobar ventanilla terminado"<<endl;

            //comprobar estaciones de mantenimiento
            ComprobarEstaciones();
            //cout << "comprobar estacion terminado"<<endl;
            primerAvion = true;
        }







    Imprimir();
    QString e = QString::fromStdString(mensaj);
    ui->consola->setText(e);

    CreandoCadena();
    //GuardandoArchivo();


    QPixmap qp("C:/EDD/grafo.jpg");
    ui->lbImg->setPixmap(qp);






    }else
    {

        NodoMaletas *m = equipaje.primero;
        while(m != NULL)
        {
            EliminarLC(&equipaje);
            m = equipaje.primero;
        }
        NodoAviones *a = esperaMantenimiento.primero;
        while(a != NULL)
        {
            EliminarLD(&esperaMantenimiento);
            a = esperaMantenimiento.primero;
        }
        a = aviones.primero;
        while(a != NULL)
        {
            EliminarLD(&aviones);
            a = esperaMantenimiento.primero;
        }
        NodoPasajeros *p = espera.primero;
        while(p != NULL)
        {
            EliminarC(&espera);
            p = espera.primero;
        }
        NodoMantenimiento *e = estacion.primero;
        while(e != NULL)
        {
            EliminarS(&estacion);
            e = estacion.primero;
        }

        NodoEscritorios *w = escritorios.primero;
        NodoDocumentos *d;
        while(w != NULL)
        {
            d = w->documento.primero;
            while(d != NULL)
            {
                EliminarP(&(w->documento));
                d = w->documento.primero;
            }
            p = w->espera.primero;
            while(p != NULL)
            {
                EliminarC(&(w->espera));
                p = w->espera.primero;
            }

            EliminarLDO(&escritorios);
            w = escritorios.primero;
        }

        turnos = -1;
        avion = -1;
        //escritorio;
        //estaciones;
        turnoActual =0;
        primeraVez = false;
        primerAvion = false;
        arriboavion= false;
        avionesingresados=0;
        mensaj ="";
        ui->txtAviones->text() = 1;
        ui->txtEstaciones->text() =1;
        ui->txtTurnos->text() = 1;
        ui->txtVentanillas->text() = 1;
        ui->consola->setText("");






    }







}

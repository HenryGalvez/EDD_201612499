#ifndef LISTASIMPLE_H
#define LISTASIMPLE_H
#include "lista.h"
#include <iostream>
using namespace std;

struct NodoMantenimiento
{
    int id=0;
    int estado=0;
    int avion=0;
    int turnos=0;



    NodoMantenimiento *siguiente;

};

struct ListaSimple
{
    NodoAviones *revisando;
    NodoMantenimiento *primero = NULL;
    NodoMantenimiento *ultimo = NULL;
};


void InsertarLS(ListaSimple *lis,int estado_,int avion_,int turnos_)
{

    NodoMantenimiento *auxiliar = new NodoMantenimiento();
    auxiliar->id = (int)auxiliar;
    auxiliar->estado = estado_;
    auxiliar->avion = avion_;
    auxiliar->turnos = turnos_;
    auxiliar->siguiente = NULL;
    if(lis->primero == NULL && lis->ultimo == NULL)
    {

        lis->primero = auxiliar;
        lis->ultimo = auxiliar;
    }else
    {
        NodoMantenimiento *q =lis->ultimo;
        q->siguiente = auxiliar;
        lis->ultimo = auxiliar;

    }

}

void MostrarS(ListaSimple *lis)
{
    NodoMantenimiento *aux = lis->primero;
    if(lis->primero == NULL)
    {
        std::cout << "La Pila Esta Vacia" << endl;

    }else
    {

        while(aux != NULL)
        {
            std::cout << "id: " << aux->id << endl;
            std::cout << "estado: " << aux->estado << endl;
            std::cout << "aviones: " << aux->avion << endl;
            std::cout << "turnos: " << aux->turnos << endl;
            aux = aux->siguiente;
        }

    }
}
void PasarRevision(ListaDoble *lis,ListaSimple *lsimple)
{

    NodoAviones *aux = lis->primero;
    //NodoAviones *q = lis->ultimo;


    if(lis->primero ==NULL)
    {
        lsimple->revisando = NULL;
    }else if(lis->primero == lis->ultimo)
    {

         lis->primero = NULL;
         lis->ultimo = NULL;
         lsimple->revisando = aux;
         lis->count = (lis->count)-1;

    }
    else
    {
         lis->primero = aux->siguiente;
         lis->primero->anterior = NULL;
         lsimple->revisando = aux;
         lis->count = (lis->count)-1;
    }
}

void EliminandoRevision(ListaSimple *lsimple)
{
    delete lsimple->revisando;
    //lsimple->revisando =NULL;
}

void EliminarS(ListaSimple *lis)
{

    NodoMantenimiento *auxiliar = lis->primero;

    if(lis->primero == NULL && lis->ultimo == NULL)
    {

    }
    else if(lis->primero != lis->ultimo)
    {
        lis->primero = auxiliar->siguiente;
        delete auxiliar;
    }else if(lis->primero == lis->ultimo)
    {
        lis->ultimo = NULL;
        lis->primero = auxiliar->siguiente;
        delete auxiliar;
        lis->primero = NULL;
    }

}

void VaciarListaS(ListaSimple *lis)
{
    NodoMantenimiento *aux = lis->primero;
    NodoMantenimiento *a = aux;
    if(lis->primero == NULL)
    {


    }else
    {

        while(aux != NULL)
        {
            aux = aux->siguiente;
            delete a;
            a = aux;
        }

    }
}

#endif // LISTASIMPLE_H

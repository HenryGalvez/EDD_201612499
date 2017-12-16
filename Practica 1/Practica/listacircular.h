#ifndef LISTACIRCULAR_H
#define LISTACIRCULAR_H
#include <stdlib.h>

struct NodoMaletas
{
    int id;
    int pasajeroid;
    NodoMaletas *siguiente;
    NodoMaletas *anterior;

};

struct ListaCircular
{
    int count =0;
    NodoMaletas *primero = NULL;
    NodoMaletas *ultimo = NULL;
};


void InsertarLC(ListaCircular *lis,int pasajeroid_)
{

    NodoMaletas *auxiliar = new NodoMaletas();
    auxiliar->id = (int)auxiliar;
    auxiliar->pasajeroid = pasajeroid_;
    auxiliar->siguiente = NULL;
    if(lis->primero == NULL && lis->ultimo == NULL)
    {

        lis->primero = auxiliar;
        lis->ultimo = auxiliar;
        lis->primero->anterior = auxiliar;
        lis->primero->siguiente = auxiliar;
        lis->count = (lis->count) +1;
    }else
    {

        lis->ultimo->siguiente = auxiliar;
        auxiliar->anterior = lis->ultimo;
        lis-> ultimo = auxiliar;
        lis->primero->anterior = lis->ultimo;
        lis->ultimo->siguiente = lis->primero;
        lis->count = (lis->count) +1;

    }
}



void MostrarLC(ListaCircular *lis)
{
    NodoMaletas *aux = lis->primero;
    if(lis->primero == NULL)
    {
        std::cout << "La Pila Esta Vacia" << endl;

    }else
    {

        while(aux != NULL)
        {
            std::cout << "id: " << aux->id << endl;
            std::cout << "pasajero: " << aux->pasajeroid << endl;
            aux = aux->siguiente;
            if(aux == lis->ultimo)
            {
                break;
            }
        }

    }
}

void EliminarLC(ListaCircular *lis)
{



    NodoMaletas *auxiliar = lis->primero;

    if(lis->primero == NULL && lis->ultimo == NULL)
    {

    }
    else if(lis->primero != lis->ultimo)
    {

        lis->primero = auxiliar->siguiente;
        lis->primero->anterior = lis->ultimo;
        lis->ultimo->siguiente = lis->primero;
        delete auxiliar;
        lis->count = (lis->count) -1;
    }else if(lis->primero == lis->ultimo)
    {
        lis->ultimo = NULL;
        lis->primero = NULL;
        delete auxiliar;

        lis->count = (lis->count) -1;
    }


}



void VaciarListaC(ListaCircular *lis)
{
    NodoMaletas *aux = lis->primero;
    NodoMaletas *a = aux;
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

#endif // LISTACIRCULAR_H

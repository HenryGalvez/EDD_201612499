#ifndef COLA_H
#define COLA_H
#include <iostream>
#include <stdlib.h>
using namespace std;

struct NodoPasajeros
{
    int id;
    int direccion;
    int maletas;
    int documentos;
    int turnos;
    NodoPasajeros *siguiente;

};

struct Cola
{
    int count = 0;
    NodoPasajeros *primero = NULL;
    NodoPasajeros *ultimo = NULL;
};


void InsertarC(Cola *lis,int maleta_,int documentos_,int turnos_)
{

    NodoPasajeros *auxiliar = new NodoPasajeros();
    auxiliar->id = (int)auxiliar;
    auxiliar->direccion = (int)auxiliar;
    auxiliar->maletas = maleta_;
    auxiliar->documentos = documentos_;
    auxiliar->turnos = turnos_;

    if(lis->primero == NULL && lis->ultimo == NULL)
    {

        lis->primero = auxiliar;
        lis->ultimo = auxiliar;
        lis->count = (lis->count)+1;
    }else
    {
        NodoPasajeros *q =lis->ultimo;
        q->siguiente = auxiliar;
        lis->ultimo = auxiliar;
        lis->count = (lis->count)+1;

    }

}

void PasarCola(Cola *lis, Cola *lo)
{
    NodoPasajeros *aux = lis->primero;
    if(lis->primero == NULL)
    {
    }else
    {
        if(lis->primero != lis->ultimo)
        {
            lis->primero = aux->siguiente;
            lis->count = (lis->count)-1;
            if(lo->primero == NULL && lo->ultimo == NULL)
            {

                lo->primero = aux;
                lo->ultimo = aux;
                aux->siguiente = NULL;
                lo->count = (lo->count)+1;
            }else
            {
                NodoPasajeros *q =lo->ultimo;
                q->siguiente = aux;
                lo->ultimo = aux;
                aux->siguiente = NULL;
                lo->count = (lo->count)+1;

            }
        }else
        {
            lis->primero = NULL;
            lis->ultimo = NULL;
            lis->count = (lis->count)-1;
            if(lo->primero == NULL && lo->ultimo == NULL)
            {

                lo->primero = aux;
                lo->ultimo = aux;
                aux->siguiente = NULL;
                lo->count = (lo->count)+1;
            }else
            {
                NodoPasajeros *q =lo->ultimo;
                q->siguiente = aux;
                lo->ultimo = aux;
                aux->siguiente= NULL;
                lo->count = (lo->count)+1;

            }
        }
    }
}

void InsertarCNodo(Cola *lis,int id_,int maleta_,int documentos_,int turnos_)
{

    NodoPasajeros *auxiliar = new NodoPasajeros();
    auxiliar->id = id_;
    auxiliar->direccion = (int)auxiliar;
    auxiliar->maletas = maleta_;
    auxiliar->documentos = documentos_;
    auxiliar->turnos = turnos_;

    if(lis->primero == NULL && lis->ultimo == NULL)
    {

        lis->primero = auxiliar;
        lis->ultimo = auxiliar;
        lis->count= (lis->count)+1;
    }else
    {
        NodoPasajeros *q =lis->ultimo;
        q->siguiente = auxiliar;
        lis->ultimo = auxiliar;
        lis->count= (lis->count)+1;

    }

}

void MostrarC(Cola *lis)
{
    NodoPasajeros *q = lis->primero;
    if(lis->primero == NULL)
    {
        cout <<"Cola Vacia "<<endl;
    }else
    {
        while(q->siguiente != NULL)
        {
            cout <<"Pasajero id: "<<q->id<<endl;
            cout <<"Pasajero turnos: "<<q->turnos<<endl;
            cout <<"Pasajero maletas: "<<q->maletas<<endl;
            q = q->siguiente;
        }
    }



}

void EliminarC(Cola *lis)
{

    NodoPasajeros *auxiliar = lis->primero;

    if(lis->count == 0)
    {

    }
    else if(lis->primero != lis->ultimo)
    {
        lis->primero = auxiliar->siguiente;
        delete auxiliar;
        lis->count= (lis->count)-1 ;
    }else if(lis->primero == lis->ultimo)
    {
        lis->ultimo = NULL;
        //lis->primero = auxiliar->siguiente;
        lis->primero=NULL;
        delete auxiliar;
        //lis->primero = NULL;
        lis->count= (lis->count)-1;
    }

}

void LimpiarCola(Cola *lis)
{
    NodoPasajeros *q = lis->primero;
    NodoPasajeros *a = q;
    if(lis->primero == NULL)
    {

    }else
    {
        while(q != NULL)
        {
            q = q->siguiente;
            delete a;
            a= q;
        }

    }

}

#endif // COLA_H

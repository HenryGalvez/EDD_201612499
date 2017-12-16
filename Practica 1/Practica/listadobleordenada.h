#ifndef LISTADOBLEORDENADA_H
#define LISTADOBLEORDENADA_H
#include "cola.h"
#include "pila.h"
#include <stdlib.h>
#include <iostream>
using namespace std;

struct NodoEscritorios
{
    char id;
    int estado;
    int documentos;
    int turnos;
    int idPasajero;
    int direccion;
    Cola espera;
    Pila documento;
    NodoPasajeros *revision;
    NodoEscritorios *siguiente;
    NodoEscritorios *anterior;

};

struct ListaDobleO
{

    int nom =65;
    NodoEscritorios *primero;
    NodoEscritorios *ultimo;
};


void InsertarLDO(ListaDobleO *lis,int estado_,int documentos_,int turnos_)
{

    NodoEscritorios *aux = new NodoEscritorios();
    aux->id = lis->nom;
    aux->direccion = (int)aux;
    aux->estado = estado_;
    aux->documentos = documentos_;
    aux->turnos = turnos_;
    aux->siguiente = NULL;
    if(lis->primero == NULL)
    {
        lis->primero = aux;
        lis->ultimo = aux;
        lis->nom =(lis->nom)+1;

    }else
    {
        NodoEscritorios *q;
        q = lis->ultimo;
        q->siguiente = aux;

        aux->anterior = lis->ultimo;
        lis->ultimo = aux;
        lis->nom =(lis->nom)+1;

    }

}

void InsertarLDOO(ListaDobleO *lis,int id_,int estado_,int documentos_,int turnos_)
{

    NodoEscritorios *aux = new NodoEscritorios();
    aux->id = id_;
    aux->direccion = (int)aux;
    aux->estado = estado_;
    aux->documentos = documentos_;
    aux->turnos = turnos_;
    aux->siguiente = NULL;
    if(lis->primero == NULL)
    {
        lis->primero = aux;
        lis->ultimo = aux;
        lis->nom =(lis->nom)+1;

    }else
    {
        NodoEscritorios *q;
        //q= lis->ultimo;
        //q->siguiente = aux;

        if((aux->id) > (lis->ultimo->id))
        {
            q= lis->ultimo;
            q->siguiente = aux;
            aux->anterior =q;
            lis->ultimo = aux;
            lis->nom = (lis->nom)+1;
            cout <<"entro 1"<<endl;
        }else if((aux->id) < (lis->primero->id))
        {
            q= lis->primero;
            q->anterior = aux;
            aux->siguiente = q;
            lis->primero = aux;
            lis->nom = (lis->nom)+1;
            cout<<"entro 2"<<endl;
        }else
        {

/*
            int idActual = q->id;
            int idInsertar = aux->id;
            NodoEscritorios *d = lis->primero;
            q= d->siguiente;
            while(q != NULL)
            {
                if(idActual >= idInsertar)
                {

                    d->siguiente = aux;
                    aux->anterior = d;
                    aux->siguiente = q;
                    q->anterior = aux;
                    lis->nom = (lis->nom)+1;
                    break;
                }
                d = d->siguiente;
                q = q->siguiente;
                idActual= q->id;

            }*/
            NodoEscritorios *d = lis->primero;
                        q= d->siguiente;
                        while(q != NULL)
                        {
                            if(q->id >= aux-> id)
                            {

                                d->siguiente = aux;
                                aux->anterior = d;
                                aux->siguiente = q;
                                q->anterior = aux;
                                lis->nom = (lis->nom)+1;
                                break;
                            }
                            d = d->siguiente;
                            q = q->siguiente;


                        }
            cout << "entro 3" << endl;
        }


    }

}


void MostrarLDO(ListaDobleO *lis)
{
    NodoEscritorios *aux = lis->primero;
    if(lis->primero == NULL)
    {
        std::cout << "La Pila Esta Vacia" << endl;

    }else
    {

        while(aux != NULL)
        {
            std::cout << "id: " << aux->id << endl;
            std::cout << "estado: " << aux->estado << endl;
            std::cout << "documento: " << aux->documentos << endl;
            std::cout << "desabordaje: " << aux->turnos << endl;
            aux = aux->siguiente;
        }

    }
}

void PasarVentanilla(Cola *lis, NodoEscritorios *lo)
{
    NodoPasajeros *auxiliar = lis->primero;

    if(lis->primero == NULL)
    {

    }
    else if(lis->primero != lis->ultimo)
    {
        lis->primero = auxiliar->siguiente;
        lo->revision = auxiliar;
        lis->count= (lis->count)-1 ;
    }else if(lis->primero == lis->ultimo)
    {
        lis->ultimo = NULL;
        //lis->primero = auxiliar->siguiente;
        lis->primero=NULL;
        lo->revision = auxiliar;
        //lis->primero = NULL;
        lis->count= (lis->count)-1;
    }
}

void QuitarVentanilla(ListaDobleO *lo)
{
    delete lo->primero->revision;
    //lo->revision = NULL;

}

void EliminarLDO(ListaDobleO *lis)
{
    NodoEscritorios *aux = lis->primero;
    //NodoAviones *q = lis->ultimo;


    if(lis->primero ==NULL)
    {

    }else if(lis->primero == lis->ultimo)
    {

         lis->primero = NULL;
         lis->ultimo = NULL;
         delete aux;
         lis->nom = (lis->nom)-1;

    }
    else
    {
         lis->primero = aux->siguiente;
         lis->primero->anterior = NULL;
         delete aux;
         lis->nom = (lis->nom)-1;
    }

}

void VaciarListaDO(ListaDobleO *lis)
{
    NodoEscritorios *aux = lis->primero;
    NodoEscritorios *a = aux;
    if(lis->primero == NULL)
    {


    }else
    {

        while(aux != NULL)
        {

            aux = aux->siguiente;
            delete a;
            a = aux;
            lis->nom = (lis->nom)-1;
        }

    }
}

#endif // LISTADOBLEORDENADA_H

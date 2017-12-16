#ifndef LISTA_H
#define LISTA_H
#include <iostream>
#include <QString>

using namespace std;

struct NodoAviones
{
    int id;
    string tipo;
    int desabordaje;
    int pasajeros;
    int mantenimiento;
    NodoAviones *siguiente;
    NodoAviones *anterior;

};

struct ListaDoble
{
    int count =0;
    NodoAviones *primero = NULL;
    NodoAviones *ultimo = NULL;
};


void InsertarLD(ListaDoble *lis,string tipo_,int pasajeros_,int desabordaje_,int mantenimiento_)
{

    NodoAviones *aux = new NodoAviones();
    aux->id = (int)aux;
    aux->tipo = tipo_;
    aux->pasajeros = pasajeros_;
    aux->desabordaje = desabordaje_;
    aux->mantenimiento = mantenimiento_;
    aux->siguiente = NULL;
    if(lis->primero == NULL)
    {
        lis->primero = aux;
        lis->ultimo = aux;
        lis->count = (lis->count)+1;

    }else
    {
        NodoAviones *q;
        q = lis->ultimo;
        q->siguiente = aux;

        aux->anterior = lis->ultimo;
        lis->ultimo = aux;
        lis->count = (lis->count)+1;

    }

}

void InsertarLDNodo(ListaDoble *lis,int id_,string tipo_,int pasajeros_,int desabordaje_,int mantenimiento_)
{

    NodoAviones *aux = new NodoAviones();
    aux->id = id_;
    aux->tipo = tipo_;
    aux->pasajeros = pasajeros_;
    aux->desabordaje = desabordaje_;
    aux->mantenimiento = mantenimiento_;
    aux->siguiente = NULL;
    if(lis->primero == NULL)
    {
        lis->primero = aux;
        lis->ultimo = aux;
        lis->count = (lis->count)+1;

    }else
    {
        NodoAviones *q;
        q = lis->ultimo;
        q->siguiente = aux;

        aux->anterior = lis->ultimo;
        lis->ultimo = aux;
        lis->count = (lis->count)+1;

    }

}

void MostrarLD(ListaDoble *lis)
{
    NodoAviones *aux = lis->primero;
    if(lis->primero == NULL)
    {
        std::cout << "La Pila Esta Vacia" << endl;

    }else
    {

        while(aux != NULL)
        {
            std::cout << "id: " << aux->id << endl;
            std::cout << "tipo: " << aux->tipo << endl;
            std::cout << "pasajeros: " << aux->pasajeros << endl;
            std::cout << "desabordaje: " << aux->desabordaje << endl;
            std::cout << "mantenimiento: " << aux->mantenimiento << endl;
            aux = aux->siguiente;
        }

    }
}

void EliminarLD(ListaDoble *lis)
{


    NodoAviones *aux = lis->primero;
    //NodoAviones *q = lis->ultimo;


    if(lis->primero ==NULL)
    {

    }else if(lis->primero == lis->ultimo)
    {

         lis->primero = NULL;
         lis->ultimo = NULL;
         delete aux;
         lis->count = (lis->count)-1;

    }
    else
    {
         lis->primero = aux->siguiente;
         lis->primero->anterior = NULL;
         delete aux;
         lis->count = (lis->count)-1;
    }





}

void VaciarListaD(ListaDoble *lis)
{
    NodoAviones *aux = lis->primero;
    NodoAviones *a = aux;
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

#endif // LISTA_H

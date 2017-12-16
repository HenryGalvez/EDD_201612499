#ifndef PILA_H
#define PILA_H
#include <stdlib.h>

struct NodoDocumentos
{
    int id;
    int pasajero;
    NodoDocumentos *anterior;

};

struct Pila
{
    NodoDocumentos *primero = NULL;
};


void InsertarP(Pila *lis,int pasajero_)
{

    NodoDocumentos *auxiliar = new NodoDocumentos();
    auxiliar->id = (int)auxiliar;
    auxiliar->pasajero = pasajero_ ;
    if(lis->primero == NULL)
    {

        auxiliar->anterior = lis->primero;
        lis->primero = auxiliar;

    }else
    {

        auxiliar->anterior = lis->primero;
        lis->primero = auxiliar;

    }

}

void MostrarP(Pila *lis)
{
    NodoDocumentos *q = lis->primero;
    if(lis->primero == NULL)
    {
        std::cout<<"La Pila Esta Vacia"<<endl;
    }else
    {
        while(q->anterior != NULL)
        {
            std::cout<<"id: "<<q->id<<endl;
            std::cout<<"id pasajero: "<<q->pasajero<<endl;
            q=q->anterior;
        }
    }


}

void EliminarP(Pila *lis)
{

    NodoDocumentos *auxiliar = lis->primero;

    if(lis->primero == NULL)
    {

    }
    else if(lis->primero != NULL)
    {

        lis->primero = auxiliar->anterior;
        delete auxiliar;
    }

}

void VaciarPila(Pila *lis)
{
    NodoDocumentos *q = lis->primero;

    if(lis->primero == NULL)
    {

    }else
    {
        while(q != NULL)
        {
            EliminarP(lis);
            q = lis->primero;
        }
    }
}


#endif // PILA_H

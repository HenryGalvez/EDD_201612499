#include <stdio.h>
#include <stdlib.h>
#include "listade.h"

int menu()
{
    int a;
    printf("*******Seleccione una opcion: ******\n");
    printf("1. Insertar en la Lista.\n");
    printf("2. Mostrar Datos de la Lista.\n");
    printf("3. Eliminar un dato de la Lista.\n");
    printf("4. Salir de la Aplicacion.\n\n");
    printf("Cual es su Eleccion: ");

    scanf("%d",&a);
    printf("\n\n");
    return a;

}






int main()
{
    ListaD *miLista = malloc(sizeof(ListaD));
    miLista->primero= NULL;
    miLista->ultimo = NULL;
    int eleccion;
    while((eleccion=menu())<5)
    {
        switch (eleccion)
        {
        case 1:

            Insertar(miLista);
            break;
        case 2:
            Mostrar(miLista);
            break;
        case 3:
            Eliminar(miLista);
            break;
        case 4:
            exit(0);
            break;
        default:
            break;

        }
    }

    free(miLista);

    return 0;
}

void Insertar(ListaD *lis)
{
    int dato_;
    printf("\nIngrese un Numero: ");
    scanf("%d",&dato_);
    printf("\n\n");
    Nodo *aux = malloc(sizeof(Nodo));
    aux->dato = dato_;
    aux->siguiente = NULL;
    if(lis->primero == NULL)
    {
        lis->primero = aux;
        lis->ultimo = aux;

    }else
    {
        Nodo *q;
        q = lis->ultimo;
        q->siguiente = aux;

        aux->anterior = lis->ultimo;
        lis->ultimo = aux;

    }

}

void Mostrar(ListaD *lis)
{
    Nodo *aux = lis->primero;
    printf("\n\n\nLos Datos de la Lista son: \n");
    if(lis->primero == NULL)
    {
        printf("\n\ La Pila Esta Vacia\n\n");

    }else
    {

        while(aux != NULL)
        {
            printf("%d\n",aux->dato);
            aux = aux->siguiente;
        }
        printf("\n\n");
    }
}

void Eliminar(ListaD *lis)
{
    int n;
    printf("\n\nQue numero Desea Eliminar: ");
    scanf("%d",&n);
    printf("\n\n");
    Nodo *aux = lis->primero;
    Nodo *q = lis->ultimo;
    Nodo *p = lis->primero;
    while(aux != NULL)
    {
        if(aux->dato == n)
        {
            if(aux == lis->primero && aux == lis->ultimo)
            {
                free(aux);
                lis->primero = NULL;
                lis->ultimo = NULL;

            }
            else if(aux == lis->ultimo)
            {
                q = q->anterior;
                lis->ultimo = aux ->anterior;
                q->siguiente = NULL;
                free(aux);
            }else if(aux == lis->primero)
            {
                lis->primero = aux->siguiente;
                p->anterior = NULL;
                free(aux);
            }else
            {
            Nodo *aux1 = aux ->anterior;
            Nodo *aux2 = aux ->siguiente;

            aux1->siguiente = aux2;
            aux2->anterior = aux1;

            free(aux);
            }

            break;
        }else
        {
            aux = aux->siguiente;
        }
    }

}


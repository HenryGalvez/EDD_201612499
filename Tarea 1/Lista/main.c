#include <stdio.h>
#include <stdlib.h>
#include "ListaDoble.h"

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

Nodo *primero = NULL;
Nodo *ultimo = NULL;



int main()
{
    miLista.primero = NULL;
    miLista.ultimo = NULL;
    int eleccion;
    while((eleccion=menu())<5)
    {
        switch (eleccion)
        {
        case 1:

            Insertar();
            break;
        case 2:
            Mostrar();
            break;
        case 3:
            Eliminar();
            break;
        case 4:
            exit(0);
            break;
        default:
            break;

        }
    }


    return 0;
}

void Insertar()
{
    int dato_;
    printf("\nIngrese un Numero: ");
    scanf("%d",&dato_);
    printf("\n\n");
    Nodo *aux = malloc(sizeof(Nodo));
    aux->dato = dato_;
    aux->siguiente = NULL;
    if(primero == NULL)
    {
        primero = aux;
        ultimo = aux;

    }else
    {

        ultimo->siguiente = aux;
        aux->anterior = ultimo;
        ultimo = aux;

    }

}

void Mostrar()
{
    Nodo *aux = primero;
    printf("\n\n\nLos Datos de la Lista son: \n");
    if(primero == NULL)
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

void Eliminar()
{
    int n;
    printf("\n\nQue numero Desea Eliminar: ");
    scanf("%d",&n);
    printf("\n\n");
    Nodo *aux = primero;
    while(aux != NULL)
    {
        if(aux->dato == n)
        {
            if(aux == primero && aux == ultimo)
            {
                free(aux);
                primero = NULL;
                ultimo = NULL;

            }
            else if(aux == ultimo)
            {
                ultimo = aux ->anterior;
                ultimo->siguiente = NULL;
                free(aux);
            }else if(aux == primero)
            {
                primero = aux->siguiente;
                primero->anterior = NULL;
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

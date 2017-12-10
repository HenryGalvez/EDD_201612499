#ifndef LISTADE_H_INCLUDED
#define LISTADE_H_INCLUDED

typedef struct{
    int dato;
    struct Nodo *siguiente;
    struct Nodo *anterior;
}Nodo;

typedef struct{
    struct Nodo *primero;
    struct Nodo *ultimo;
}ListaD;



void Insertar(ListaD *);
void Mostrar(ListaD *);
void Eliminar(ListaD *);


#endif // LISTADE_H_INCLUDED

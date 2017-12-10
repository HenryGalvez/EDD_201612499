#ifndef LISTADOBLE_H_INCLUDED
#define LISTADOBLE_H_INCLUDED


typedef struct{
    int dato;
    struct Nodo *siguiente;
    struct Nodo *anterior;
}Nodo;

typedef struct{
    struct Nodo *primero;
    struct Nodo *ultimo;
}ListaDooble;

ListaDoble miLista;

void Insertar();
void Mostrar();
void Eliminar();



#endif // LISTADOBLE_H_INCLUDED

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoMatriz
/// </summary>
class NodoMatriz
{
    public string nombre;
    public int movimiento;
    public int alcance;
    public int daño;
    public int vida;
    public string jugador;
    public Byte estado;
    public NodoMatriz siguiente, anterior, arriba, abajo, atras, adelante;
    public string fila, columna;
    public NodoMatriz(string nombre_,string jugador_, string fila_, string columna_,Byte estado_)
    {
        nombre = nombre_;
        jugador = jugador_;
        siguiente = null;
        anterior = null;
        arriba = null;
        abajo = null;
        atras = null;
        adelante = null;
        estado = estado_; 
        fila = fila_;
        columna = columna_;
        if (nombre.Contains("Neosatelite"))
        {
            movimiento = 6;
            alcance = 0;
            daño = 2;
            vida = 10;
        }
        else if (nombre.Contains("Bombardero"))
        {
            movimiento = 7;
            alcance = 0;
            daño = 5;
            vida = 10;
        }
        else if (nombre.Contains("Caza"))
        {
            movimiento = 9;
            alcance = 1;
            daño = 2;
            vida = 20;
        }
        else if (nombre.Contains("Helicopetero"))
        {
            movimiento = 9;
            alcance = 1;
            daño = 3;
            vida = 15;
        }
        else if (nombre.Contains("Fragata"))
        {
            movimiento = 5;
            alcance = 6;
            daño = 3;
            vida = 10;
        }
        else if (nombre.Contains("Crucero"))
        {
            movimiento = 6;
            alcance = 1;
            daño = 3;
            vida = 15;
        }
        else if (nombre.Contains("Submarino"))
        {
            movimiento = 5;
            alcance = 1;
            daño = 2;
            vida = 10;
        }
        else if (nombre.Contains("Base"))
        {
            movimiento = 0;
            alcance = 0;
            daño = 0;
            vida = 1;
        }
    }
}
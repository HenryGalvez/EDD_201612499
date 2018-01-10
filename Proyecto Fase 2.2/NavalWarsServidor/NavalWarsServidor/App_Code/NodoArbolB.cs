using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoArbolB
/// </summary>
class NodoArbolB
{
    public int ataque;
    public int valor;
    public string fila;
    public string columna;
    public string unidadAtacante;
    public int resultado;
    public string unidadAtacada;
    public string emisor;
    public string receptor;
    public string fecha;
    public string tiempoR;
    public Pagina izquiera;
    public Pagina derecha;

    public NodoArbolB(int ataque_,string fila_,string columna_,string uniA,int res,string unAt,string emi,string recep,string fecha_,string tie)
    {
        valor = ataque_;
        ataque = ataque_;
        fila = fila_;
        columna = columna_;
        unidadAtacante = uniA;
        resultado = res;
        unidadAtacada = unAt;
        emisor = emi;
        receptor = recep;
        fecha = fecha_;
        tiempoR = tie;
        izquiera = null;
        derecha = null;
    }
}
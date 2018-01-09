using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Header
/// </summary>
class Header
{
    public string valor;
    public NodoMatriz primero;
    public Header siguiente, anterior;
    public Header(string valor_)
    {
        valor = valor_;
        siguiente = null;
        anterior = null;
        primero = new NodoMatriz("", "", "","",0);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pagina
/// </summary>
class Pagina
{
    public NodoArbolB[] valores;
    public int espaciosO;
    public int id;
    public Pagina(int tamaño)
    {
        valores = new NodoArbolB[tamaño];
        id = 0;
        for (int i = 0; i < tamaño; i++)
        {
            valores[i] = new NodoArbolB(1000000000, "", "", "", 0,"","","","","");
        }
    }
}
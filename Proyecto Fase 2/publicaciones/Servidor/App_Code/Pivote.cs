using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pivote
/// </summary>
class Pivote
{
    public Header columnas, filas;
    public Pivote adelante, atras;
    public int nivel;
    public Pivote(int nivel_)
    {
        nivel = nivel_;
        filas = new Header("fila");
        columnas = new Header("columna");
        adelante = null;
        atras = null;
    }
    
}
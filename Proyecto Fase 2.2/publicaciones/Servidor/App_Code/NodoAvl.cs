using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoAvl
/// </summary>
class NodoAvl
{
    public string Nickname;
    public string Contraseña;
    public string Correo;
    public Byte Conectado;
    public NodoAvl izquiero;
    public NodoAvl derecho;
    public Nodo referencia;
    public ListaDoble juegos;
    public int fe;
    public NodoAvl(string nickname_, string Contraseña_, string Correo_, Byte Conectado_)
    {
        Nickname = nickname_;
        Contraseña = Contraseña_;
        Correo = Correo_;
        Conectado = Conectado_;
        fe = 0;
        juegos = new ListaDoble();
        referencia = null;
        izquiero = null;
        derecho = null;
    }



}
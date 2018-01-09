using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Nodo
/// </summary>
class Nodo
{
    public string Nickname;
    public string Contraseña;
    public string Correo;
    public Byte Conectado;
    public Nodo izquiero;
    public Nodo derecho;
    public ArbolAvl contactos;
    public ListaDoble juegos;

    public Nodo(string nickname_,string Contraseña_,string Correo_,Byte Conectado_)
    {
        Nickname = nickname_;
        Contraseña = Contraseña_;
        Correo = Correo_;
        Conectado = Conectado_;
        juegos = new ListaDoble();
        izquiero = null;
        derecho = null;
        contactos = new ArbolAvl();
    }
}
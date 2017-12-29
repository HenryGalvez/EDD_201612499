﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoJuegos
/// </summary>
 class NodoJuegos
{
    public string NickOponente;
    public int UDesplegadas;
    public int USobrevivientes;
    public int UDestruidas;
    public int id;
    public Byte Gano;
    public NodoJuegos siguiente;
    public NodoJuegos anterior;

    public NodoJuegos(string nickOponente,int desplegadas,int sobrevivientes,int destruidas,Byte gano_,int id_)
    {
        NickOponente = nickOponente;
        UDesplegadas = desplegadas;
        USobrevivientes = sobrevivientes;
        UDestruidas = destruidas;
        Gano = gano_;
        id = id_;
        siguiente = null;
        anterior = null;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaDoble
/// </summary>
 class ListaDoble
{
    public NodoJuegos primero;
    public NodoJuegos ultimo;
    public int countganados;
    public int count;
    public int ids;
    public double porcentaje;
    public int udestru;
    public NodoJuegos mayor,menor;
    

    public ListaDoble()
    {
        primero = null;
        ultimo = null;
        mayor = null;
        menor = null;
        count = 0;
        ids = 1;
        porcentaje = 0;
        udestru = 0;
        countganados = 0;
    }

    public void InsertarLD(string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_,int ataque)
    {

        NodoJuegos aux = new NodoJuegos(nickOponente, desplegadas, sobrevivientes, destruidas, gano_,ids,ataque);
        
        if (primero == null)
        {
            primero = aux;
            ultimo = aux;
            count++;
            ids++;
            if (gano_ == 1)
            {
                countganados = countganados+1;
            }
        }
        else
        {
            ultimo.siguiente = aux;

            aux.anterior = ultimo;
            ultimo = aux;
            count++;
            ids++;
            if (gano_ == 1)
            {
                countganados = countganados + 1;
            }

        }


        


    }

    public NodoJuegos Buscar(int id)
    {
        NodoJuegos aux = primero;
        while (aux != null)
        {
            if (id == aux.id)
            {
                break;
            }
            aux = aux.siguiente;
        }
        return aux;
    }

    public void Eliminar(int id)
    {
        
        if (primero != null)
        {
            if (primero == ultimo)
            {
                primero = null;
                ultimo = null;
            }
            else if (id == primero.id)
            {
                NodoJuegos am = primero.siguiente;
                primero.siguiente = null;
                am.anterior = null;
                primero = am;

            }
            else if (id == ultimo.id)
            {
                NodoJuegos am = ultimo.anterior;
                ultimo.anterior = null;
                am.siguiente = null;
                ultimo = am;

            }
            else
            {
                NodoJuegos aux = primero;
                while (aux != null)
                {
                    if (id == aux.id)
                    {
                        NodoJuegos an = aux.anterior;
                        NodoJuegos si = aux.siguiente;
                        an.siguiente = si;
                        si.anterior = an;
                        aux.siguiente = null;
                        aux.anterior = null;
                        break;
                    }
                    aux = aux.siguiente;
                }
            }
            
        }
        

    }

    public void CalcularPorcentajeUnidades()
    {
        NodoJuegos aux = primero;
        int total = 0;
        int unidades = 0;
        while (aux != null)
        {
            total += aux.UDesplegadas;
            unidades += aux.UDestruidas;
            aux = aux.siguiente;
        }

        if (total != 0)
        {
            porcentaje = (Convert.ToDouble(unidades) / Convert.ToDouble(total)) * 100;
        }
        else
        {
            porcentaje = 0;
        }
        
    }

    public void CalcularUnidadesDestruidas()
    {
        NodoJuegos aux = primero;
        
        int unidades = 0;
        while (aux != null)
        {
            
            unidades += aux.UDestruidas;
            aux = aux.siguiente;
        }

        udestru = unidades;

    }

    public void ObtenerMayor()
    {
        NodoJuegos aux = primero;
        NodoJuegos ret = primero;

        
        while (aux != null)
        {
            if (aux.ataques > ret.ataques)
            {
                ret = aux;
            }
            aux = aux.siguiente;
        }

        mayor = ret;

    }

    public void ObtenerMenor()
    {
        NodoJuegos aux = primero;
        NodoJuegos ret = primero;


        while (aux != null)
        {
            if (aux.ataques < ret.ataques)
            {
                ret = aux;
            }
            aux = aux.siguiente;
        }

        menor = ret;

    }


}
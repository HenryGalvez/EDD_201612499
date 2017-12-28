using System;
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
    public double porcentaje;

    public ListaDoble()
    {
        primero = null;
        ultimo = null;
        count = 0;
        porcentaje = 0;
        countganados = 0;
    }

    public void InsertarLD(string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_)
    {

        NodoJuegos aux = new NodoJuegos(nickOponente, desplegadas, sobrevivientes, destruidas, gano_);
        
        if (primero == null)
        {
            primero = aux;
            ultimo = aux;
            count++;
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
            if (gano_ == 1)
            {
                countganados = countganados + 1;
            }

        }


        


    }

    public void CalcularPorcentajeUnidades(ListaDoble o)
    {
        NodoJuegos aux = o.primero;
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
            porcentaje = (unidades / total) * 100;
        }
        else
        {
            porcentaje = 0;
        }
        
    }


}
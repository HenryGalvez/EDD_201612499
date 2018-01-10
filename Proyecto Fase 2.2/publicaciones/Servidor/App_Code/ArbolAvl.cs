using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolAvl
/// </summary>
class ArbolAvl
{
    public NodoAvl primero;
    public int count;
    public ArbolAvl()
    {
        primero = null;
    }

    public void GenerarGrafo()
    {
        //cou = 0;
        string texto = "";

        texto += "digraph{" + Environment.NewLine;

        texto += ArbolGrafo(primero);





        texto += "}";

        GrabarArchivo(texto);

        System.Diagnostics.ProcessStartInfo psi;


        {
            psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg "+ @"C:\EDD\avl\grafoavl.dot" + " -o "+ @"C:\EDD\avl\grafoavl.jpg ");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            psi.CreateNoWindow = false;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();

        }





    }




    public string ArbolGrafo(NodoAvl guia)
    {
        string txt = "";
        if (guia != null)
        {
            //if (guia.izquiero != null)
            {
                if (guia.referencia == null)
                {
                    txt += "node[shape = record label = " + '"' + "Usuario: " + guia.Nickname;
                    txt += "\\" + "l" + "Factor de Equlibrio: " + guia.fe;
                    txt += "\\" + "l" + "Contraseña: " + guia.Contraseña;
                    txt += "\\" + "l" + "Correo: " + guia.Correo;
                    if (guia.Conectado == 0)
                    {
                        txt += "\\" + "l" + "Desconectado" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Conectado" + '"';
                    }
                }
                else
                {
                    txt += "node[shape = record label = " + '"' + "Usuario: " + guia.referencia.Nickname;
                    
                    txt += "\\" + "l" + "Contraseña: " + guia.referencia.Contraseña;
                    txt += "\\" + "l" + "Correo: " + guia.referencia.Correo;
                    if (guia.referencia.Conectado == 0)
                    {
                        txt += "\\" + "l" + "Desconectado" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Conectado" + '"';
                    }
                }


                txt += "]" + guia.Nickname + ";" + Environment.NewLine;

            }


            txt += ArbolGrafo(guia.izquiero);
            if (guia.izquiero != null)
            {
                txt += guia.Nickname + " -> " + guia.izquiero.Nickname + ";" + Environment.NewLine;
            }
            

            txt += ArbolGrafo(guia.derecho);
            if (guia.derecho != null)
            {
                txt += guia.Nickname + " -> " + guia.derecho.Nickname + ";" + Environment.NewLine;
            }


        }
        return txt;

    }


    public void GrabarArchivo(string dato)
    {
        string nombreArchivo = @"C:\EDD\avl";
        string archivoN = "grafoavl.dot";

        string carpetafinal = Path.Combine(nombreArchivo, archivoN);



        // data a ser guardada

        //try
        {

            // data a ser guardada

            StreamWriter writer = new StreamWriter(carpetafinal);


            {

                writer.Write(dato);
            }

            writer.Close();
        }
        //catch
        {
            //Console.WriteLine("Error");
        }
    }

    public NodoAvl ExisteNick(NodoAvl guia, string nick)
    {
        
        if (guia != null)
        {
            if (string.Compare(nick, guia.Nickname, true) < 0)
            {
                if (guia.izquiero != null)
                {
                    return ExisteNick(guia.izquiero, nick);
                }
                else
                {
                    return null;
                }

            }
            else if (string.Compare(nick, guia.Nickname, true) > 0)
            {
                if (guia.derecho != null)
                {
                    return ExisteNick(guia.derecho, nick);
                }
                else
                {
                    return null;
                }

            }
            else
            {
               
                return guia;
            }
        }
        else
        {
            
            return null;
        }




    }

    public void Insertar(NodoAvl av)
    {
        NodoAvl insert = av;
        if (primero != null)
        {
            primero = InsertarAVL(primero, insert);
        }
        else
        {
            primero = insert;
            ++count;
        }
    }



    public NodoAvl InsertarAVL(NodoAvl guia, NodoAvl insert)
    {
        NodoAvl aux = guia;
        if (string.Compare(insert.Nickname, guia.Nickname) < 0)
        {
            if (guia.izquiero != null)
            {
                guia.izquiero = InsertarAVL(guia.izquiero, insert);
                if (Math.Abs((ObtenerFactorEquilibrio(guia.izquiero) - ObtenerFactorEquilibrio(guia.derecho))) == 2)
                {
                    if (string.Compare(insert.Nickname, guia.izquiero.Nickname) < 0)
                    {
                        aux = SimpleDerecha(guia);
                    }
                    else
                    {
                        aux = DobleIzquierda(guia);
                    }
                }
            }
            else
            {
                guia.izquiero = insert;
                ++count;
            }
        }
        else if (string.Compare(insert.Nickname, guia.Nickname) > 0)
        {
            if (guia.derecho != null)
            {
                guia.derecho = InsertarAVL(guia.derecho, insert);
                if (Math.Abs((ObtenerFactorEquilibrio(guia.izquiero) - ObtenerFactorEquilibrio(guia.derecho))) == 2)
                {
                    if (string.Compare(insert.Nickname, guia.derecho.Nickname) > 0)
                    {
                        aux = SimpleIzquierda(guia);
                    }
                    else
                    {
                        aux = DobleDerecha(guia);
                    }
                }
            }
            else
            {
                guia.derecho = insert;
                ++count;
            }
        }


        if (guia.derecho == null && guia.izquiero != null)
        {
            guia.fe = guia.izquiero.fe + 1;
        }
        else if (guia.derecho != null && guia.izquiero == null)
        {
            guia.fe = guia.derecho.fe + 1;
        }
        else
        {
            guia.fe = Math.Max(ObtenerFactorEquilibrio(guia.derecho), ObtenerFactorEquilibrio(guia.izquiero)) + 1;
        }

        return aux;
    }


    public int ObtenerFactorEquilibrio(NodoAvl guia)
    {
        if (guia != null)
        {
            return guia.fe;
        }
        else
        {
            return -1;
        }

    }

    public NodoAvl SimpleDerecha(NodoAvl guia)
    {
        NodoAvl aux = guia.izquiero;
        guia.izquiero = aux.derecho;
        aux.derecho = guia;

        
        guia.fe = Math.Max(ObtenerFactorEquilibrio(guia.izquiero), ObtenerFactorEquilibrio(guia.derecho)) + 1;
        aux.fe = Math.Max(ObtenerFactorEquilibrio(aux.izquiero), ObtenerFactorEquilibrio(aux.derecho)) + 1;
        return aux;

    }


    public NodoAvl SimpleIzquierda(NodoAvl guia)
    {
        NodoAvl aux = guia.derecho;
        guia.derecho = aux.izquiero;
        aux.izquiero = guia;

        
        guia.fe = Math.Max(ObtenerFactorEquilibrio(guia.izquiero), ObtenerFactorEquilibrio(guia.derecho)) + 1;
        aux.fe = Math.Max(ObtenerFactorEquilibrio(aux.izquiero), ObtenerFactorEquilibrio(aux.derecho)) + 1;
        return aux;

    }


    public NodoAvl DobleDerecha(NodoAvl guia)
    {
        guia.derecho = SimpleDerecha(guia.derecho);
        NodoAvl aux = SimpleIzquierda(guia);
        return aux;
    }

    public NodoAvl DobleIzquierda(NodoAvl guia)
    {
        guia.izquiero = SimpleIzquierda(guia.izquiero);
        NodoAvl aux = SimpleDerecha(guia);
        return aux;
    }

    public NodoAvl Irizquierda(NodoAvl guia)
    {
        NodoAvl aux1 = guia;
        NodoAvl aux2 = guia;
        NodoAvl aux3 = guia.derecho;
        while (aux3 != null)
        {
            aux1 = aux2;
            aux2 = aux3;
            aux3 = aux3.izquiero;
        }
        if (aux2 != guia.derecho)
        {
            aux1.izquiero = aux2.derecho;
            aux2.derecho = guia.derecho;
        }
        //Orden(aux1);
        return aux2;
    }

    public NodoAvl Orden(NodoAvl guia)
    {

        NodoAvl a = guia.derecho;
        if (a.derecho != null && a.derecho.derecho != null)
        {
            NodoAvl s = guia.derecho.derecho;
            if (s.izquiero != null)
            {
                guia.derecho = DobleDerecha(guia.derecho);
            }
            else
            {
                guia.derecho = SimpleIzquierda(guia.derecho);
                guia.fe = Math.Max(ObtenerFactorEquilibrio(guia.izquiero), ObtenerFactorEquilibrio(guia.derecho)) + 1;
            }
        }
        return null;
    }

    public Boolean Eliminar(string n)
    {
        NodoAvl aux = primero;
        NodoAvl super = primero;
        Boolean hijoIzq = true;
        while (aux.Nickname != n)
        {
            super = aux;
            if (string.Compare(n,aux.Nickname) < 0)
            {
                hijoIzq = true;
                aux = aux.izquiero;
            }
            else
            {
                hijoIzq = false;
                aux = aux.derecho;
            }
            if (aux == null)
            {
                return false;
            }
        }

        if (aux.izquiero == null && aux.derecho == null)
        {
            if (aux == primero)
            {
                primero = null;
            }
            else if (hijoIzq == true)
            {
                super.izquiero = null;
            }
            else
            {
                super.derecho = null;
            }
        }
        else if (aux.derecho == null)
        {
            if (aux == primero)
            {
                primero = aux.izquiero;
            }
            else if (hijoIzq == true)
            {
                super.izquiero = aux.izquiero;
            }
            else
            {
                super.derecho = aux.izquiero;
            }
        }
        else if (aux.izquiero == null)
        {
            if (aux == primero)
            {
                primero = aux.derecho;
            }
            else if (hijoIzq == true)
            {
                super.izquiero = aux.derecho;
            }
            else
            {
                super.derecho = aux.izquiero;
            }
        }
        else
        {
            NodoAvl a = Irizquierda(aux);
            if (aux == primero)
            {
                primero = a;
            }
            else if (hijoIzq == true)
            {
                super.izquiero = a;
            }
            else
            {
                super.derecho = a;
            }
            a.izquiero = aux.izquiero;
            if (Math.Abs((ObtenerFactorEquilibrio(a.izquiero) - ObtenerFactorEquilibrio(a.derecho))) == 2)
            {
                Orden(a);
            }


        }
        //Recorrer(aux);
        count--;
        return true;


    }

}
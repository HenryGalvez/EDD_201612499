using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolBinario
/// </summary>
class ArbolBinario
{
    public Nodo primero;
    public int altura;
    public int nodosHojas;
    public int nodosRamas;
    public ArbolBinario()
    {
        primero = null;
        altura = 0;
        nodosHojas = 0;
        nodosRamas = 0;
    }


    public void PreOrden(Nodo guia)
    {
        if (guia != null)
        {
            Console.WriteLine(guia.Nickname);
            PreOrden(guia.izquiero);
            PreOrden(guia.derecho);
        }
    }

    public void PostOrden(Nodo guia)
    {
        if (guia != null)
        {
            PostOrden(guia.izquiero);
            PostOrden(guia.derecho);
            Console.WriteLine(guia.Nickname);
        }
    }


    

    


    string s;
    

    public string MostrarTop10Usuarios()
    {
        
        s = "NickName\t\tContraseña\t\tJuegos Ganados\t\tCorreo" + Environment.NewLine;
        EnOrden(primero);
        string retorno = "";
        string line = "";
        int count=0;
        StringReader f = new StringReader(s);
        while ((line = f.ReadLine()) != null && count <12)
        {
            retorno += line;
            retorno += Environment.NewLine;
            count++;
        }
        
        return retorno;
    }
    public void EnOrden(Nodo guia)
    {
        
        if (guia != null)
        {
            
            EnOrden(guia.derecho);
            if (guia.juegos.countganados != 0)
            {
                s += guia.Nickname + "\t\t" + guia.Contraseña + "\t\t" + guia.juegos.countganados + "\t\t" + guia.Correo + Environment.NewLine;
                
            }
            EnOrden(guia.izquiero);

        }

    }

    public string MostrarTop10Porcentaje()
    {
        
        s = "NickName\t\tContraseña\t\tPorcentaje Destruidos\t\tCorreo" + Environment.NewLine;
        EnOrdenInverso(primero);

        string retorno = "";
        string line = "";
        int count = 0;
        StringReader f = new StringReader(s);
        while ((line = f.ReadLine()) != null && count < 12)
        {
            retorno += line;
            retorno += Environment.NewLine;
            count++;
        }

        return retorno;
        
    }
    public void EnOrdenInverso(Nodo guia)
    {

        if (guia != null)
        {
            guia.juegos.CalcularPorcentajeUnidades();
            EnOrdenInverso(guia.derecho);
            
            if (guia.juegos.porcentaje != 0)
            {
                
                s += guia.Nickname + "\t\t" + guia.Contraseña + "\t\t" + guia.juegos.porcentaje + "% \t\t" + guia.Correo + Environment.NewLine;
                
                
            }
            EnOrdenInverso(guia.izquiero);

        }

    }



    public int EsMenorNick(string nick1, string nick2)
    {
        int iteracion;
        int retorno = 0;
        Boolean pass = false;
        if (nick1.Length <= nick2.Length)
        {
            iteracion = nick1.Length;
        }
        else
        {
            iteracion = nick2.Length;
        }


        for (int i = 0; i < iteracion; i++)
        {
            if (Convert.ToInt32(nick1[i]) < Convert.ToInt32(nick2[i]))
            {
                retorno = 0;
                pass = true;
                break;
            }
            else
            {
                retorno = 1;
                pass = true;
                break;
            }
        }

        if (nick1.Length > nick2.Length && pass == false)
        {
            retorno = 3;
        }

        return retorno;
    }

    public Boolean Insertar(Nodo guia, string nick,string pass, string correo, Byte estado)
    {
        if (primero != null)
        {
            
            if (string.Compare(nick, guia.Nickname) < 0)
            {
                if (guia.izquiero != null)
                {
                    Insertar(guia.izquiero, nick, pass, correo, estado);
                }
                else
                {
                    guia.izquiero = new Nodo(nick, pass, correo, estado);
                    
                    return true;
                }
            }
            else if (string.Compare(nick, guia.Nickname) > 0)
            {
                if (guia.derecho != null)
                {
                    Insertar(guia.derecho, nick, pass, correo, estado);
                }
                else
                {
                    guia.derecho = new Nodo(nick, pass, correo, estado);
                    
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            primero = new Nodo(nick, pass, correo, estado);
            
            return true;
        }
        return false;
    }

    

    

    public int Eliminar(Nodo guia,string nick)
    {
        int opcion = -1;
        if (guia != null)
        {
            if (nick.Equals(primero.Nickname))
            {
                Nodo a = Irizquierda(primero.derecho);
                Eliminar(primero, a.Nickname);
                guia.Nickname = a.Nickname;
                guia.Contraseña = a.Contraseña;
                guia.Correo = a.Correo;
                guia.Conectado = a.Conectado;
            }
            if (string.Compare(nick, guia.Nickname) < 0)
            {
                if (guia.izquiero != null)
                {
                    opcion = Eliminar(guia.izquiero, nick);
                    if (opcion == 0)
                    {
                        guia.izquiero = null;
                    }
                    else if (opcion == 1)
                    {
                        guia.izquiero = guia.izquiero.izquiero;
                    }
                    else if (opcion == 2)
                    {
                        guia.izquiero = guia.izquiero.derecho;
                    }
                    else if (opcion == 3)
                    {
                        Nodo a = Irizquierda(guia.derecho);
                        Eliminar(primero, a.Nickname);
                        guia.Nickname = a.Nickname;
                        guia.Contraseña = a.Contraseña;
                        guia.Correo = a.Correo;
                        guia.Conectado = a.Conectado;
                        
                    }

                }
                
            }
            else if (string.Compare(nick, guia.Nickname) > 0)
            {
                if (guia.derecho != null)
                {
                    opcion = Eliminar(guia.derecho, nick);
                    if (opcion == 0)
                    {
                        guia.derecho = null;
                    }
                    else if (opcion == 1)
                    {
                        guia.derecho = guia.derecho.izquiero;
                    }
                    else if (opcion == 2)
                    {
                        guia.derecho = guia.derecho.derecho;
                    }
                    else if (opcion == 3)
                    {
                        Nodo a = Irizquierda(guia.derecho);
                        Eliminar(primero, a.Nickname);
                        guia.Nickname = a.Nickname;
                        guia.Contraseña = a.Contraseña;
                        guia.Correo = a.Correo;
                        guia.Conectado = a.Conectado;
                    }
                }
                
            }
            else
            {
                if (guia.izquiero == null && guia.derecho == null)
                {
                    return 0;
                }
                else if (guia.izquiero != null && guia.derecho == null)
                {
                    return 1;
                }
                else if (guia.izquiero == null && guia.derecho != null)
                {
                    return 2;
                }
                else if (guia.izquiero != null && guia.derecho != null)
                {
                    return 3;
                }
            }
        }

        return -1;
    }

    public int Hojas()
    {
        nodosHojas = 0;
        procesoHojas(primero);
        return nodosHojas;
    }

    public void procesoHojas(Nodo guia)
    {
        if (guia != null)
        {
            if(guia.izquiero == null & guia.derecho == null)
            {
                nodosHojas++;
            }
            procesoHojas(guia.izquiero);
            procesoHojas(guia.derecho);
        }
    }


    public int Rama()
    {
        nodosRamas = 0;
        procesoRama(primero);
        return nodosRamas;
    }

    public void procesoRama(Nodo guia)
    {
        
        if (guia != null)
        {

            if (guia.izquiero != null || guia.derecho != null)
            {
                nodosRamas++;
            }
            procesoRama(guia.izquiero);
            procesoRama(guia.derecho);
        }
        
    }

    public int Altura()
    {
        altura = 0;
        procesoAltura(primero, 1);
        return altura;
    }

    private void procesoAltura(Nodo guia, int coun)
    {
        if (guia != null)
        {
            procesoAltura(guia.izquiero, coun + 1);
            if (coun > altura)
            {
                altura = coun;
            }
            procesoAltura(guia.derecho, coun + 1);
        }
    }


    public Nodo Irizquierda(Nodo guia)
    {
        if (guia.izquiero != null)
        {
            return Irizquierda(guia.izquiero);
        }
        else
        {
            return guia;
        }
        
    }

    


    static int cou;
    public void GenerarGrafo(Nodo guia)
    {
        cou = 0;
        string texto = "";

        texto += "digraph{" + Environment.NewLine;
        
            texto += ArbolGrafo(guia);
        
        
        


        texto += "}";

        GrabarArchivo(texto);

        System.Diagnostics.ProcessStartInfo psi;

        
        {
            psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg C:\\EDD\\grafo.dot -o C:\\EDD\\grafo.jpg ");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            psi.CreateNoWindow = false;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();

        }
        

        


    }

    public void GenerarGrafoEspejo(Nodo guia)
    {
        cou = 0;
        string texto = "";

        texto += "digraph{" + Environment.NewLine;

        texto += ArbolGrafoEspejo(guia);





        texto += "}";

        string nombreArchivo = @"C:\EDD";
        string archivoN = "grafoespejo.dot";

        string carpetafinal = Path.Combine(nombreArchivo, archivoN);



        // data a ser guardada

        //try
        {

            // data a ser guardada

            StreamWriter writer = new StreamWriter(carpetafinal);


            {

                writer.Write(texto);
            }

            writer.Close();
        }
        //catch
        {
            //Console.WriteLine("Error");
        }

        System.Diagnostics.ProcessStartInfo psi;


        {
            psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg C:\\EDD\\grafoespejo.dot -o C:\\EDD\\grafoespejo.jpg ");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            psi.CreateNoWindow = false;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();

        }





    }

    public string ArbolGrafo(Nodo guia)
    {
        string txt = "";
        if (guia != null)
        {
            //if (guia.izquiero != null)
            {
                txt += "node[shape = record label = " + '"' + "Usuario: " + guia.Nickname;
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
                txt += "]" + guia.Nickname + ";" + Environment.NewLine;
                
            }
            
            
            txt += ArbolGrafo(guia.izquiero);
            if (guia.izquiero != null)
            {
                txt += guia.Nickname + " -> " + guia.izquiero.Nickname + ";" + Environment.NewLine;
            }
            NodoJuegos aux = guia.juegos.primero;

            while (aux != null)
            {
                if (aux.anterior != null)
                {
                    txt += "node[shape = record label = " + '"' + "Id: " + aux.id;
                    txt += "\\" + "l" + "Oponente: " + aux.NickOponente;
                    txt += "\\" + "l" + "U Desplegadas: " + aux.UDesplegadas;
                    txt += "\\" + "l" + "U Sobrevivientes: " + aux.USobrevivientes;
                    txt += "\\" + "l" + "U Destruidas: " + aux.UDestruidas;
                    if (aux.Gano == 0)
                    {
                        txt += "\\" + "l" + "Partida Perdida" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Partida Ganada" + '"';
                    }
                    txt += "]" + aux.NickOponente + cou + ";" + Environment.NewLine;
                    txt += aux.anterior.NickOponente + (cou - 1) + " -> " + aux.NickOponente + cou + ";" + Environment.NewLine;
                    cou++;
                }
                else
                {
                    txt += "node[shape = record label = " + '"' + "Id: " + aux.id;
                    txt += "\\" + "l" + "Oponente: " + aux.NickOponente;
                    txt += "\\" + "l" + "U Desplegadas: " + aux.UDesplegadas;
                    txt += "\\" + "l" + "U Sobrevivientes: " + aux.USobrevivientes;
                    txt += "\\" + "l" + "U Destruidas: " + aux.UDestruidas;
                    if (aux.Gano == 0)
                    {
                        txt += "\\" + "l" + "Partida Perdida" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Partida Ganada" + '"';
                    }
                    txt += "]" + aux.NickOponente + cou + ";" + Environment.NewLine;
                    txt += guia.Nickname + " -> " + aux.NickOponente + cou + ";" + Environment.NewLine;
                    cou++;
                }

                aux = aux.siguiente;
            }

            txt += ArbolGrafo(guia.derecho);
            if (guia.derecho != null)
            {
                txt += guia.Nickname + " -> " + guia.derecho.Nickname + ";" + Environment.NewLine;
            }


        }
        return txt;

    }


    public string ArbolGrafoEspejo(Nodo guia)
    {
        string txt = "";
        if (guia != null)
        {
            //if (guia.izquiero != null)
            {
                txt += "node[shape = record label = " + '"' + "Usuario: " + guia.Nickname;
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
                txt += "]" + guia.Nickname + ";" + Environment.NewLine;

            }

            
            txt += ArbolGrafoEspejo(guia.derecho);
            if (guia.derecho != null)
            {
                txt += guia.Nickname + " -> " + guia.derecho.Nickname + ";" + Environment.NewLine;
            }


            NodoJuegos aux = guia.juegos.primero;

            while (aux != null)
            {
                if (aux.anterior != null)
                {
                    txt += "node[shape = record label = " + '"' + "Id: " + aux.id;
                    txt += "\\" + "l" + "Oponente: " + aux.NickOponente;
                    txt += "\\" + "l" + "U Desplegadas: " + aux.UDesplegadas;
                    txt += "\\" + "l" + "U Sobrevivientes: " + aux.USobrevivientes;
                    txt += "\\" + "l" + "U Destruidas: " + aux.UDestruidas;
                    if (aux.Gano == 0)
                    {
                        txt += "\\" + "l" + "Partida Perdida" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Partida Ganada" + '"';
                    }
                    txt += "]" + aux.NickOponente + cou + ";" + Environment.NewLine;
                    txt += aux.anterior.NickOponente + (cou - 1) + " -> " + aux.NickOponente + cou + ";" + Environment.NewLine;
                    cou++;
                }
                else
                {
                    txt += "node[shape = record label = " + '"' + "Id: " + aux.id;
                    txt += "\\" + "l" + "Oponente: " + aux.NickOponente;
                    txt += "\\" + "l" + "U Desplegadas: " + aux.UDesplegadas;
                    txt += "\\" + "l" + "U Sobrevivientes: " + aux.USobrevivientes;
                    txt += "\\" + "l" + "U Destruidas: " + aux.UDestruidas;
                    if (aux.Gano == 0)
                    {
                        txt += "\\" + "l" + "Partida Perdida" + '"';
                    }
                    else
                    {
                        txt += "\\" + "l" + "Partida Ganada" + '"';
                    }
                    txt += "]" + aux.NickOponente + cou + ";" + Environment.NewLine;
                    txt += guia.Nickname + " -> " + aux.NickOponente + cou + ";" + Environment.NewLine;
                    cou++;
                }

                aux = aux.siguiente;
            }


            txt += ArbolGrafoEspejo(guia.izquiero);
            if (guia.izquiero != null)
            {
                txt += guia.Nickname + " -> " + guia.izquiero.Nickname + ";" + Environment.NewLine;
            }


        }
        return txt;

    }

    public void GrabarArchivo(string dato)
    {
        string nombreArchivo = @"C:\EDD";
        string archivoN = "grafo.dot";

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

    public Nodo ExisteNick(Nodo guia,string nick)
    {
        Nodo aux = new Nodo("", "", "", 0);
        if (guia != null)
        {
            if (string.Compare(nick, guia.Nickname,true) < 0)
            {
                if (guia.izquiero != null)
                {
                   return ExisteNick(guia.izquiero, nick);
                }

            }
            else if (string.Compare(nick, guia.Nickname,true) > 0)
            {
                if (guia.derecho != null)
                {
                    return ExisteNick(guia.derecho, nick);
                }
                
            }
            else
            {
                aux = guia;
                return aux;
            }
        }
        
        aux = null;
        return aux;
        
        
    }

    public void Modificar(string antes,string nickname,string pass,string correo, Byte estado)
    {

        Nodo aux = ExisteNick(primero,antes);
        if (aux != null)
        {
            Eliminar(primero, antes);
            
            InsertarNodo(primero, nickname,pass,correo,estado,aux.juegos);
        }
        
    }
    public Boolean InsertarNodo(Nodo guia, string nick, string pass, string correo, Byte estado,ListaDoble juego)
    {
        if (primero != null)
        {

            if (string.Compare(nick, guia.Nickname) < 0)
            {
                if (guia.izquiero != null)
                {
                    Insertar(guia.izquiero, nick, pass, correo, estado);
                }
                else
                {
                    guia.izquiero = new Nodo(nick, pass, correo, estado);
                    guia.izquiero.juegos = juego;

                    return true;
                }
            }
            else if (string.Compare(nick, guia.Nickname) > 0)
            {
                if (guia.derecho != null)
                {
                    Insertar(guia.derecho, nick, pass, correo, estado);
                }
                else
                {
                    guia.derecho = new Nodo(nick, pass, correo, estado);
                    guia.derecho.juegos = juego;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            primero = new Nodo(nick, pass, correo, estado);
            primero.juegos = juego;
            return true;
        }
        return false;
    }


    public void InsertarJuego(Nodo guia,string nickBase, string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_)
    {
        if (guia != null)
        {
            if (guia.Nickname.Equals(nickBase))
            {
                guia.juegos.InsertarLD(nickOponente, desplegadas, sobrevivientes, destruidas, gano_);
                
                return;
            }

            InsertarJuego(guia.izquiero, nickBase, nickOponente, desplegadas, sobrevivientes, destruidas, gano_);
            
            InsertarJuego(guia.derecho, nickBase, nickOponente, desplegadas, sobrevivientes, destruidas, gano_);
        }
    }
}
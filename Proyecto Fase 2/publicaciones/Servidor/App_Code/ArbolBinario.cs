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


    public void PreOrden(Nodo guia,TablaHash ins)
    {
        if (guia != null)
        {
            ins.Insertar(guia);
            PreOrden(guia.izquiero,ins);
            PreOrden(guia.derecho,ins);
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
    

    public string MostrarTop10UsuariosJG()
    {
        
        s = "NickName\t\tJuegos Ganados" + Environment.NewLine;
        ArbolBinario aux = new ArbolBinario();
        EnOrden(primero, aux);
        EnOrdenC(aux.primero);
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

        return retorno; ;
    }
    public void EnOrden(Nodo guia,ArbolBinario aux)
    {
        
        if (guia != null)
        {
            
            EnOrden(guia.derecho,aux);
            if (guia.juegos.countganados != 0)
            {
                //if (aux.primero != null)
                {
                    aux.InsertarTop10(aux.primero, "" + guia.juegos.countganados, guia.Nickname);
                }
                //else
                //{
                //    aux.primero = new Nodo(""+guia.juegos.countganados, guia.Nickname,"",0);
                //}
                
            }
            
            EnOrden(guia.izquiero,aux);

        }

    }

    public Boolean InsertarTop10(Nodo guia,string dato,string nick)
    {
        if (primero != null)
        {

            if (Convert.ToDouble(dato) < Convert.ToDouble(guia.Nickname))
            {
                if (guia.izquiero != null)
                {
                    InsertarTop10(guia.izquiero, dato, nick);
                }
                else
                {
                    guia.izquiero = new Nodo(dato, nick, "", 0);

                    return true;
                }
            }
            else if (Convert.ToDouble(dato) > Convert.ToDouble(guia.Nickname))
            {
                if (guia.derecho != null)
                {
                    InsertarTop10(guia.derecho, dato, nick);
                }
                else
                {
                    guia.derecho = new Nodo(dato, nick, "", 0);

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
            primero = new Nodo(dato, nick, "", 0);

            return true;
        }
        return false;
    }

    public string MostrarTop10UsuariosContactos()
    {

        s = "NickName\t\tContactos" + Environment.NewLine;
        ArbolBinario aux = new ArbolBinario();
        EnOrdenCCon(primero, aux);
        EnOrdenC(aux.primero);
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
    public void EnOrdenCCon(Nodo guia,ArbolBinario aux)
    {

        if (guia != null)
        {

            EnOrdenCCon(guia.derecho,aux);
            if (guia.contactos.count != 0)
            {
                if (aux.primero != null)
                {
                    aux.InsertarTop10(aux.primero, "" + guia.contactos.count, guia.Nickname);
                }
                else
                {
                    aux.primero = new Nodo(""+guia.contactos.count, guia.Nickname, "", 0);
                }
                
            }
            
            EnOrdenCCon(guia.izquiero,aux);

        }

    }
    public void EnOrdenC(Nodo guia)
    {

        if (guia != null)
        {

            EnOrdenC(guia.derecho);
            //if (guia.contactos.count != 0)
            {
                s += guia.Contraseña + "\t\t" + guia.Nickname + Environment.NewLine;

            }
            EnOrdenC(guia.izquiero);

        }

    }


    public string MostrarTop10Porcentaje()
    {
        
        s = "NickName\t\tPorcentaje Destruidos (%)" + Environment.NewLine;
        ArbolBinario aux = new ArbolBinario();
        EnOrdenInverso(primero, aux);
        EnOrdenC(aux.primero);

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
    public void EnOrdenInverso(Nodo guia,ArbolBinario aux)
    {

        if (guia != null)
        {
            guia.juegos.CalcularPorcentajeUnidades();
            EnOrdenInverso(guia.derecho,aux);
            if (guia.juegos.porcentaje != 0)
            {
                //if (aux.primero != null)
                {
                    aux.InsertarTop10(aux.primero, ""+guia.juegos.porcentaje, guia.Nickname);
                }
                //else
                //{
                //    aux.primero = new Nodo(guia.juegos.porcentaje + "", guia.Nickname, "", 0);
                //}
                
            }
            
            EnOrdenInverso(guia.izquiero,aux);

        }

    }


    public string MostrarTop10UDestruidas()
    {

        s = "NickName\t\tPorcentaje Destruidos" + Environment.NewLine;
        ArbolBinario aux = new ArbolBinario();
        EnOrdenInversoD(primero, aux);
        EnOrdenC(aux.primero);

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
    public void EnOrdenInversoD(Nodo guia, ArbolBinario aux)
    {

        if (guia != null)
        {
            guia.juegos.CalcularUnidadesDestruidas();
            EnOrdenInversoD(guia.derecho, aux);
            if (guia.juegos.udestru != 0)
            {
                //if (aux.primero != null)
                {
                    aux.InsertarTop10(aux.primero, "" + guia.juegos.udestru, guia.Nickname);
                }
                //else
                //{
                //    aux.primero = new Nodo(guia.juegos.porcentaje + "", guia.Nickname, "", 0);
                //}

            }

            EnOrdenInversoD(guia.izquiero, aux);

        }

    }


    public string JuegoMayor()
    {
        s = "NickName Usuario\\tNickName Oponente\t\tNo Ataques" + Environment.NewLine;

        NodoJuegos we = new NodoJuegos("", 0, 0, 0, 0, 0, 0);
        string nom = "";

        EnOrdeMayor(primero, ref we,ref nom);
        

        if (we != null)
        {
            s += " " + nom + " " + we.NickOponente + " " + we.ataques +Environment.NewLine;
        }
        string retorno = s;
        return retorno;
    }
    
    public void EnOrdeMayor(Nodo guia, ref NodoJuegos ret,ref string nom)
    {

        if (guia != null)
        {
            if (guia.juegos != null)
            {
                guia.juegos.ObtenerMayor();
            }
            
            EnOrdeMayor(guia.derecho, ref ret,ref nom);
            if (guia.juegos != null && guia.juegos.mayor != null && guia.juegos.mayor.ataques > ret.ataques)
            {

                ret = guia.juegos.mayor;
                nom = guia.Nickname;

            }

            EnOrdeMayor(guia.izquiero,ref ret, ref nom);

        }

    }


    public string JuegoMenor()
    {
        s = "NickName Usuario\\tNickName Oponente\t\tNo Ataques" + Environment.NewLine;
        NodoJuegos we = new NodoJuegos("",0,0,0,0,0,0);
        string nom = "";

        EnOrdeMenor(primero, ref we,ref nom);
        

        if (we != null)
        {
            s += " " + nom + " " + we.NickOponente + " " + we.ataques + Environment.NewLine;
        }
        string retorno = s;
        return retorno;
    }

    public void EnOrdeMenor(Nodo guia, ref NodoJuegos ret,ref string nom)
    {

        if (guia != null)
        {
            if (guia.juegos != null)
            {
                guia.juegos.ObtenerMenor();
            }

            EnOrdeMenor(guia.derecho, ref ret,ref nom);
            if (guia.juegos != null && guia.juegos.menor != null && guia.juegos.menor.ataques < ret.ataques)
            {

                ret = guia.juegos.menor;
                nom = guia.Nickname;
            }

            EnOrdeMenor(guia.izquiero, ref ret,ref nom);

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

    /*
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
    }*/
    public Nodo Irizquierda(Nodo guia)
    {
        Nodo aux1 = guia;
        Nodo aux2 = guia;
        Nodo aux3 = guia.derecho;
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
        return aux2;
    }

    public Boolean Eliminar(string n)
    {
        Nodo aux = primero;
        Nodo super = primero;
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
        Nodo ad = new Nodo(aux.Nickname, aux.Contraseña, aux.Correo, aux.Conectado);
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
            Nodo a = Irizquierda(aux);
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
        }
        //Recorrer(aux);
        EliminarReferencias(ad);
        return true;


    }
    public void EliminarReferencias(Nodo e)
    {
        Recorrer(primero, e);
    }

    public void Recorrer(Nodo guia, Nodo e)
    {
        if (guia != null)
        {
            Recorrer(guia.izquiero, e);
            BuscarContacto(guia.contactos.primero, e);
            Recorrer(guia.derecho, e);
        }
    }

    public void BuscarContacto(NodoAvl guia,Nodo e)
    {
        if (guia != null)
        {
            if (string.Compare(e.Nickname, guia.Nickname) < 0)
            {
                BuscarContacto(guia.izquiero, e);
            }
            else if (string.Compare(e.Nickname, guia.Nickname) < 0)
            {
                BuscarContacto(guia.derecho, e);
            }
            else
            {
                guia.Conectado = e.Conectado;
                guia.Contraseña = e.Contraseña;
                guia.Correo = e.Correo;
                guia.referencia = null;
            }
            
        }
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
            psi = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + " dot -Tjpg C:\\EDD\\grafoespejo.dot -o C:\\EDD\\grafoespejo.jpg ");
            
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
                aux = guia;
                return aux;
            }
        }
        else
        {
            aux = null;
            return aux;
        }
        
        
        
        
    }

    public void Modificar(string antes,string nickname,string pass,string correo, Byte estado)
    {

        Nodo aux = ExisteNick(primero,antes);
        if (aux != null)
        {
            Eliminar(antes);
            
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


    public void InsertarJuego(Nodo guia,string nickBase, string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_,int ataque)
    {
        if (guia != null)
        {
            if (guia.Nickname.Equals(nickBase))
            {
                guia.juegos.InsertarLD(nickOponente, desplegadas, sobrevivientes, destruidas, gano_,ataque);
                
                return;
            }

            InsertarJuego(guia.izquiero, nickBase, nickOponente, desplegadas, sobrevivientes, destruidas, gano_,ataque);
            
            InsertarJuego(guia.derecho, nickBase, nickOponente, desplegadas, sobrevivientes, destruidas, gano_,ataque);
        }
    }
}
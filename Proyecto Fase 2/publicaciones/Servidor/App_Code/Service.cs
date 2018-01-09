using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://henry.cccc/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


public class Service : System.Web.Services.WebService
{
    public Service() {


    }



    static ArbolBinario arbol = new ArbolBinario();

    static Matriz matriz = new Matriz();
    static Matriz matrizDestruido = new Matriz();

    static TablaHash tabH = new TablaHash(43);

    string nick = "Admin", pass = "admin";
    static int Univel0 = 10;
    static int Univel1 = 10;
    static int Univel2 = 10;
    static int Univel3 = 10;
    static int TamX = 25;
    static int TamY = 25;
    static int Tiempo = 15;
    static int modo = 2;
    static string primerJugador = "";
    static string segundoJugador = "";
    static Boolean primerReady = false;
    static Boolean segundoReady = false;
    static string msj = "";
    static string msjFinal = "";
    static Boolean finalizar = false;
    static Boolean ac = false;
    static int turno = 1;
    static Boolean p1 = true;
    static Boolean p2 = false;
    

    [WebMethod]
    public int getTurno()
    {
        return turno;
    }

    [WebMethod]
    public void FinTurno(int player)
    {
        if (player == 1)
        {
            p1 = true;
            p2 = false;
            turno++;
        }
        else
        {
            p2 = true;
            p1 = false;
            turno++;
        }
        
    }

    [WebMethod]
    public int Turno()
    {
        if (p1 == true && p2 == false)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    
    [WebMethod]
    public void setMsjFinal(string ac_)
    {
        msjFinal = ac_;
    }

    [WebMethod]
    public string getMsjFinal()
    {
        return msjFinal;
    }

    [WebMethod]
    public void setFinalizar(Boolean ac_)
    {
        finalizar = ac_;
    }

    [WebMethod]
    public Boolean getFinalizar()
    {
        return finalizar;
    }

    [WebMethod]
    public void setActualizar(Boolean ac_)
    {
        ac = ac_;
    }

    [WebMethod]
    public Boolean getActualizar()
    {
        return ac;
    }

    [WebMethod]
    public string ObtenerMensaje()
    {
        return msj;
    }

    [WebMethod]
    public void MansarMensaje(string msj_)
    {
        msj = msj_;
    }

    [WebMethod]
    public Boolean LoginAdmin(string nick_, string pass_)
    {
        if (nick.Equals(nick_) && pass.Equals(pass_))
        {
            return true;
        }
        else return false;

    }

    [WebMethod]
    public Boolean Login(string nick_, string pass)
    {
        return false;
    }

    [WebMethod]
    public void Agregar(string nick, string pass, string correo, Byte estado)
    {
        arbol.Insertar(arbol.primero, nick, pass, correo, estado);
    }

    [WebMethod]
    public void AgregarJuego(string nickBase, string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_)
    {
        arbol.InsertarJuego(arbol.primero, nickBase, nickOponente, desplegadas, sobrevivientes, destruidas, gano_);
    }

    [WebMethod]
    public string MostrarDatosUsuario(String nick)
    {
        string retornar = "";
        Nodo ap = arbol.ExisteNick(arbol.primero, nick);
        if (ap != null)
        {
            retornar += ap.Nickname + "\n";
            retornar += ap.Contraseña + "\n";
            retornar += ap.Correo + "\n";
            retornar += ap.Conectado;
        }
        return retornar;
    }

    [WebMethod]
    public void EliminarUsuario(string nick)
    {
        arbol.Eliminar(nick);
    }

    [WebMethod]
    public void Mostrar()
    {
        arbol.GenerarGrafoEspejo(arbol.primero);
        arbol.GenerarGrafo(arbol.primero);

    }

    [WebMethod]
    public void MostrarTableros(string opcion)
    {

        matriz.GenerarGrafo(matriz.primero.atras.filas, TamX, TamY, "matrizNivel0" + opcion, opcion);
        matriz.GenerarGrafo(matriz.primero.filas, TamX, TamY, "matrizNivel1" + opcion, opcion);
        matriz.GenerarGrafo(matriz.primero.adelante.filas, TamX, TamY, "matrizNivel2" + opcion, opcion);
        matriz.GenerarGrafo(matriz.primero.adelante.adelante.filas, TamX, TamY, "matrizNivel3" + opcion, opcion);

        matrizDestruido.GenerarGrafo(matrizDestruido.primero.atras.filas, TamX, TamY, "matrizNivel0Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.filas, TamX, TamY, "matrizNivel1Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.adelante.filas, TamX, TamY, "matrizNivel2Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.adelante.adelante.filas, TamX, TamY, "matrizNivel3Destruido" + opcion, opcion);


    }

    [WebMethod]
    public string RetornarCandena(string ruta)
    {
        try
        {
            Byte[] ims = System.IO.File.ReadAllBytes(@ruta);
            return "data:image/jpg;base64," + Convert.ToBase64String(ims);
        }
        catch (Exception ewe)
        {
            return "";
        }

        //Byte[] ims = System.IO.File.ReadAllBytes(@ruta);
        //return "data:image/jpg;base64," + Convert.ToBase64String(ims);

    }

    [WebMethod]
    public int NodosHojas()
    {
        return arbol.Hojas();
    }


    [WebMethod]
    public int NodosRama()
    {
        return arbol.Rama();
    }


    [WebMethod]
    public int Altura()
    {
        return arbol.Altura();
    }

    [WebMethod]
    public void Modificar(string antes, string nick, string pass, string correo, Byte estado)
    {
        arbol.Modificar(antes, nick, pass, correo, estado);
    }

    [WebMethod]
    public void EliminarListaJuegos(string usuario, int id)
    {
        Nodo ap = arbol.ExisteNick(arbol.primero, usuario);

        if (ap != null)
        {
            ap.juegos.Eliminar(id);
        }

    }

    [WebMethod]
    public void ModificarListaJuegos(string usuario, int id, string nickOponente, int desplegadas, int sobrevivientes, int destruidas, Byte gano_)
    {
        Nodo ap = arbol.ExisteNick(arbol.primero, usuario);
        NodoJuegos mod;
        if (ap != null)
        {
            mod = ap.juegos.Buscar(id);
        }
        else
        {
            mod = null;
        }

        if (mod != null)
        {
            if (nickOponente != "")
            {
                mod.NickOponente = nickOponente;
            }
            if (desplegadas >= 0)
            {
                mod.UDesplegadas = desplegadas;
            }
            if (sobrevivientes >= 0)
            {
                mod.USobrevivientes = sobrevivientes;
            }
            if (destruidas >= 0)
            {
                mod.UDestruidas = destruidas;
            }

            if (gano_ >= 0)
            {
                mod.Gano = gano_;
            }
        }
    }


    [WebMethod]
    public string Top10Usuarios()
    {
        return arbol.MostrarTop10UsuariosJG();

    }

    [WebMethod]
    public string Top10UsuariosContactos()
    {
        return arbol.MostrarTop10UsuariosContactos();

    }

    [WebMethod]
    public string Top10Porcentaje()
    {
        return arbol.MostrarTop10Porcentaje();
    }

    [WebMethod]
    public int Atacar(int nivel, string unidad, string fila, string columna, int nivelA)
    {
        if (nivel == 0)
        {
            if (nivelA == 0)
            {
                return matriz.Atacar(matriz.primero.atras, unidad, fila, columna, matriz.primero.atras);
            }
            else if (nivelA == 1)
            {
                return matriz.Atacar(matriz.primero.atras, unidad, fila, columna, matriz.primero);
            }
            else if (nivelA == 2)
            {
                return matriz.Atacar(matriz.primero.atras, unidad, fila, columna, matriz.primero.adelante);
            }
            else if (nivelA == 3)
            {
                return matriz.Atacar(matriz.primero.atras, unidad, fila, columna, matriz.primero.adelante.adelante);
            }
            else
            {
                return -1;
            }

        }
        else if (nivel == 1)
        {
            if (nivelA == 0)
            {
                return matriz.Atacar(matriz.primero, unidad, fila, columna, matriz.primero.atras);
            }
            else if (nivelA == 1)
            {
                return matriz.Atacar(matriz.primero, unidad, fila, columna, matriz.primero);
            }
            else if (nivelA == 2)
            {
                return matriz.Atacar(matriz.primero, unidad, fila, columna, matriz.primero.adelante);
            }
            else if (nivelA == 3)
            {
                return matriz.Atacar(matriz.primero, unidad, fila, columna, matriz.primero.adelante.adelante);
            }
            else
            {
                return -1;
            }
        }
        else if (nivel == 2)
        {
            if (nivelA == 0)
            {
                return matriz.Atacar(matriz.primero.adelante, unidad, fila, columna, matriz.primero.atras);
            }
            else if (nivelA == 1)
            {
                return matriz.Atacar(matriz.primero.adelante, unidad, fila, columna, matriz.primero);
            }
            else if (nivelA == 2)
            {
                return matriz.Atacar(matriz.primero.adelante, unidad, fila, columna, matriz.primero.adelante);
            }
            else if (nivelA == 3)
            {
                return matriz.Atacar(matriz.primero.adelante, unidad, fila, columna, matriz.primero.adelante.adelante);
            }
            else
            {
                return -1;
            }
        }
        else if (nivel == 3)
        {
            if (nivelA == 0)
            {
                return matriz.Atacar(matriz.primero.adelante.adelante, unidad, fila, columna, matriz.primero.atras);
            }
            else if (nivelA == 1)
            {
                return matriz.Atacar(matriz.primero.adelante.adelante, unidad, fila, columna, matriz.primero);
            }
            else if (nivelA == 2)
            {
                return matriz.Atacar(matriz.primero.adelante.adelante, unidad, fila, columna, matriz.primero.adelante);
            }
            else if (nivelA == 3)
            {
                return matriz.Atacar(matriz.primero.adelante.adelante, unidad, fila, columna, matriz.primero.adelante.adelante);
            }
            else
            {
                return -1;
            }
        }
        else
        {
            return -1;
        }

    }

    [WebMethod]
    public int Mover(int nivel, string unidad, string filaA, string colA, string fila, string columna)
    {
        if (nivel == 0)
        {
            return matriz.CambiarPosicion(matriz.primero.atras, unidad, fila, columna);
        }
        else if (nivel == 1)
        {
            return matriz.CambiarPosicion(matriz.primero, unidad, fila, columna);
        }
        else if (nivel == 2)
        {
            return matriz.CambiarPosicion(matriz.primero.adelante, unidad, fila, columna);
        }
        else if (nivel == 3)
        {
            return matriz.CambiarPosicion(matriz.primero.adelante.adelante, unidad, fila, columna);
        }
        else
        {
            return -1;
        }

    }

    [WebMethod]
    public Boolean EsBase(string fila, string columna)
    {
        int a = matriz.EsBase(fila, columna);
        if (a == 0)
        {
            finalizar = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    

    [WebMethod]
    public void VerificarUnidades()
    {
        int a = matriz.VerificarUnidades(primerJugador, segundoJugador);
        if (a == 2)
        {
            finalizar = true;
            msjFinal = "El jugador " + segundoJugador + " ha GANADO LA PARTIDA" + Environment.NewLine + "PARTIDA FINALIZADA";
        }
        else if (a == 1)
        {
            finalizar = true;
            msjFinal = "El jugador " + primerJugador + " ha GANADO LA PARTIDA" + Environment.NewLine + "PARTIDA FINALIZADA";
        }
        else
        {
            msjFinal = "";
        }
    }

    [WebMethod]
    public void VerificarEmpate()
    {
        int a = matriz.VerificarUnidades(primerJugador, segundoJugador);
        if (a == 2)
        {
            finalizar = true;
            msjFinal = "El jugador " + segundoJugador + " ha GANADO LA PARTIDA" + Environment.NewLine + "PARTIDA FINALIZADA";
        }
        else if (a == 1)
        {
            finalizar = true;
            msjFinal = "El jugador " + primerJugador + " ha GANADO LA PARTIDA" + Environment.NewLine + "PARTIDA FINALIZADA";
        }
        else if (a == 0)
        {
            finalizar = true;
            msjFinal = "Ningun Jugador ha Ganado Partida Empatada" + Environment.NewLine + "PARTIDA FINALIZADA";
        }
        else
        {
            msjFinal = "";
        }

    }

    [WebMethod]
    public int InsertarUnidadesMatriz(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        if (nivel == 0)
        {
            if (matriz.submarino <= Univel0)
            {
                matriz.submarino = matriz.submarino + 1;
                return matriz.Insertar(matriz.primero.atras, tipo, jugador, fila, columna, estado);

            }
            else
            {
                return 1;
            }

        }
        else if (nivel == 1)
        {
            if ((matriz.fragata + matriz.crucero) <= Univel1)
            {
                if (tipo.Contains("Fragata"))
                {
                    matriz.fragata = matriz.fragata + 1;
                }
                else if (tipo.Contains("Crucero"))
                {
                    matriz.crucero = matriz.crucero + 1;
                }
                return matriz.Insertar(matriz.primero, tipo, jugador, fila, columna, estado);
                
            }
            else
            {
                return 1;
            }

        }
        else if (nivel == 2)
        {
            if ((matriz.bombardero + matriz.caza + matriz.helicoptero) <= Univel2)
            {
                if (tipo.Contains("Bombardero"))
                {
                    matriz.bombardero = matriz.bombardero + 1;
                }
                else if (tipo.Contains("Caza"))
                {
                    matriz.caza = matriz.caza + 1;
                }
                else if (tipo.Contains("Helicoptero"))
                {
                    matriz.helicoptero = matriz.helicoptero + 1;
                }
                return matriz.Insertar(matriz.primero.adelante, tipo, jugador, fila, columna, estado);
                
            }
            else
            {
                return 1;
            }

        }
        else if (nivel == 3)
        {
            if (matriz.neosatelite <= Univel3)
            {
                matriz.neosatelite = matriz.neosatelite + 1;
                Pivote ae = matriz.primero.adelante;
                return matriz.Insertar(ae.adelante, tipo, jugador, fila, columna, estado);
                
            }
            else
            {
                return 1;
            }

        }
        else
        {
            return -1;
        }


    }


    [WebMethod]
    public void InsertarUnidadesMatrizDestruido(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        if (nivel == 0)
        {
            if (matrizDestruido.submarino <= Univel0)
            {
                matrizDestruido.Insertar(matrizDestruido.primero.atras, tipo, jugador, fila, columna, estado);
                matrizDestruido.submarino = matrizDestruido.submarino + 1;
            }

        }
        else if (nivel == 1)
        {
            if ((matrizDestruido.fragata + matrizDestruido.crucero) <= Univel1)
            {
                matrizDestruido.Insertar(matrizDestruido.primero, tipo, jugador, fila, columna, estado);
                if (tipo.Contains("Fragata"))
                {
                    matrizDestruido.fragata = matrizDestruido.fragata + 1;
                }
                else if (tipo.Contains("Crucero"))
                {
                    matrizDestruido.crucero = matrizDestruido.crucero + 1;
                }
            }

        }
        else if (nivel == 2)
        {
            if ((matrizDestruido.bombardero + matrizDestruido.caza + matrizDestruido.helicoptero) <= Univel2)
            {
                matrizDestruido.Insertar(matrizDestruido.primero.adelante, tipo, jugador, fila, columna, estado);
                if (tipo.Contains("Bombardero"))
                {
                    matrizDestruido.bombardero = matrizDestruido.bombardero + 1;
                }
                else if (tipo.Contains("Caza"))
                {
                    matrizDestruido.caza = matrizDestruido.caza + 1;
                }
                else if (tipo.Contains("Helicoptero"))
                {
                    matrizDestruido.helicoptero = matrizDestruido.helicoptero + 1;
                }
            }

        }
        else if (nivel == 3)
        {
            if (matrizDestruido.neosatelite <= Univel3)
            {
                Pivote ae = matrizDestruido.primero.adelante;
                matrizDestruido.Insertar(ae.adelante, tipo, jugador, fila, columna, estado);
                matrizDestruido.neosatelite = matrizDestruido.neosatelite + 1;
            }

        }


    }

    [WebMethod]
    public void ConfigurarParametros(int Un0, int Un1, int Un2, int Un3, int tiempo, int tx, int ty, int mod)
    {
        if (Un0 > -1)
        {
            Univel0 = Un0;
        }

        if (Un1 > -1)
        {
            Univel1 = Un1;
        }
        if (Un2 > -1)
        {
            Univel2 = Un2;
        }
        if (Un3 > -1)
        {
            Univel3 = Un3;
        }
        if (tiempo > -1)
        {
            Tiempo = tiempo;
        }
        if (tx > -1)
        {
            TamX = tx;
        }
        if (ty > -1)
        {
            TamY = ty;
        }if (mod > 0)
        {
            modo = mod;
        }



    }

    [WebMethod]
    public string ObtenerUnivel0()
    {
        string retorno = "" + Univel0.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerUnivel1()
    {
        string retorno = "" + Univel1.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerUnivel2()
    {
        string retorno = "" + Univel2.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerUnivel3()
    {
        string retorno = "" + Univel3.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerTiempo()
    {
        string retorno = "" + Tiempo.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerTamX()
    {
        string retorno = "" + TamX.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerTamY()
    {
        string retorno = "" + TamY.ToString();
        return retorno;
    }

    [WebMethod]
    public int ObtenerModo()
    {
        return modo;
    }


    [WebMethod]
    public int ConfigurarJugadores(string usuario)
    {
        if (primerJugador.Equals(""))
        {
            primerJugador = usuario;
            return 1;
        }
        else if (segundoJugador.Equals(""))
        {
            segundoJugador = usuario;
            return 2;
        }
        else
        {
            return -1;
        }
    }

    [WebMethod]
    public void EliminarUnidades(string unidad, int nivel)
    {
        if (nivel == 0)
        {
            matriz.EliminarA(matriz.primero.atras,unidad);
        }
        else if (nivel == 1)
        {
            matriz.EliminarA(matriz.primero, unidad);
        }
        else if (nivel == 2)
        {
            matriz.EliminarA(matriz.primero.adelante, unidad);
        }
        else if (nivel == 3)
        {
            matriz.EliminarA(matriz.primero.adelante.adelante, unidad);
        }

    }

    [WebMethod]
    public void SetReady(string usuario)
    {
        if (usuario.Equals(primerJugador))
        {
            primerReady = true;
        }
        else if (usuario.Equals(segundoJugador))
        {
            segundoReady = true;
        }
    }


    [WebMethod]
    public Boolean ComenzarJuego()
    {
        if (primerReady == true && segundoReady == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    [WebMethod]
    public void VaciarMatrices()
    {
        matriz.Vaciar();
        matrizDestruido.Vaciar();
    }

    [WebMethod]
    public void ImportarUsuariosHash()
    {
        tabH = new TablaHash(43);
        arbol.PreOrden(arbol.primero, tabH);
        tabH.GenerarGrafo();
    }

    [WebMethod]
    public void MostrarTablaHash()
    {
        //tabH = new TablaHash(43);
        //arbol.PreOrden(arbol.primero, tabH);
        tabH.GenerarGrafo();
    }

    [WebMethod]
    public void InsertarTablaHash(string antes, string nick, string pass, string correo, Byte estado)
    {
        Nodo aux = new Nodo(nick, pass, correo, estado);
        tabH.Insertar(aux);
    }

    [WebMethod]
    public void ModificarTablaHash(string antes, string nick, string pass, string correo, Byte estado)
    {
        Nodo aux = new Nodo(nick, pass, correo, estado);
        tabH.Modificar(aux);
    }

    [WebMethod]
    public void EliminarTablaHash(string n)
    {
        tabH.Eliminar(n);
    }

    [WebMethod]
    public void InsertarContacto(string usuario, string nick, string pass, string correo)
    {
        Nodo aux = arbol.ExisteNick(arbol.primero, nick);
        Nodo aux2 = arbol.ExisteNick(arbol.primero, usuario);
        if (aux == null)
        {

            if (aux2 != null)
            {
                aux2.contactos.Insertar(new NodoAvl(nick, pass, correo, 0));
            }
        }
        else
        {
            NodoAvl aux3 = new NodoAvl(nick, "", "", 0);
            aux3.referencia = aux;
            if (aux2 != null)
            {
                aux2.contactos.Insertar(aux3);
            }

        }
    }
    [WebMethod]
    public void EliminarAvl(string usuariob, string usuarioe)
    {
        Nodo a = arbol.ExisteNick(arbol.primero, usuariob);
        if (a != null)
        {
            a.contactos.Eliminar(usuarioe);
        }
    }


    [WebMethod]
    public string RetornarDatosContacto(string usuariob, string usuarioe)
    {
        string s = "";
        Nodo a = arbol.ExisteNick(arbol.primero, usuariob);
        if (a != null)
        {
            NodoAvl d = a.contactos.ExisteNick(a.contactos.primero,usuarioe);
            if (d != null && d.referencia == null)
            {
                s += d.Nickname + Environment.NewLine;
                s += d.Contraseña + Environment.NewLine;
                s += d.Correo + Environment.NewLine;

            }
            else if (d != null && d.referencia != null)
            {
                s += d.referencia.Nickname + Environment.NewLine;
                s += d.referencia.Contraseña + Environment.NewLine;
                s += d.referencia.Correo + Environment.NewLine;
            }
        }
        return s;
    }

    [WebMethod]
    public void ModificarAvl(string usuario,string usuarioa, string nick, string pass, string correo)
    {
        Nodo a = arbol.ExisteNick(arbol.primero, usuario);
        if (a != null)
        {
            NodoAvl e = a.contactos.ExisteNick(a.contactos.primero,usuarioa);
            
            if (e != null && e.referencia == null)
            {
                NodoAvl ins = new NodoAvl(e.Nickname, e.Contraseña, e.Correo, e.Conectado);
                
                if (nick != "")
                {
                    ins.Nickname = nick;
                }
                if (pass != "")
                {
                    ins.Contraseña = pass;
                }
                if (correo != "")
                {
                    ins.Correo = correo;
                }
                
                a.contactos.Eliminar(usuarioa);
                a.contactos.Insertar(ins);
            }
            else if (e != null && e.referencia != null)
            {
                NodoAvl ins = new NodoAvl(e.Nickname,e.Contraseña,e.Correo,e.Conectado);
                if (nick != "")
                {
                    
                    ins.Nickname = nick;
                }
                if (pass != "")
                {
                    ins.Contraseña = pass;
                }
                if (correo != "")
                {
                    ins.Correo = correo;
                }
                arbol.Modificar(usuarioa, nick, pass, correo, e.referencia.Conectado);
                ins.referencia = arbol.ExisteNick(arbol.primero,nick);
                a.contactos.Eliminar(usuarioa);
                a.contactos.Insertar(ins);
            }
        }
    }

    [WebMethod]
    public int RetornarTamañoAvl(string nick)
    {
        Nodo aux = arbol.ExisteNick(arbol.primero, nick);
        if (aux != null)
        {
            return aux.contactos.count;
        }
        else
        {
            return -1;
        }
    }

    [WebMethod]
    public void MostrarAvl(string nick)
    {
        Nodo aux = arbol.ExisteNick(arbol.primero,nick);
        if (aux != null)
        {
            aux.contactos.GenerarGrafo();
        }
    }

}
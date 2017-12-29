using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://henry.cccc/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


public class Service : System.Web.Services.WebService
{
    public Service () {

        
    }

    

    static ArbolBinario arbol = new ArbolBinario();
    
    static Matriz matriz = new Matriz();
    static Matriz matrizDestruido = new Matriz();
    string nick = "Admin",pass = "admin";
    static int Univel0 = 10;
    static int Univel1 = 10;
    static int Univel2 = 10;
    static int Univel3 = 10;
    static int TamX = 25;
    static int TamY = 25;
    static int Tiempo = 15;
    static string primerJugador = "";
    static string segundoJugador = "";
    static Boolean primerReady = false;
    static Boolean segundoReady = false;

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
    public void Agregar(string nick,string pass,string correo,Byte estado)
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
        string retornar ="";
        Nodo ap = arbol.ExisteNick(arbol.primero,nick);
        if (ap != null)
        {
            retornar += ap.Nickname + "\n";
            retornar += ap.Contraseña + "\n";
            retornar += ap.Correo+"\n";
            retornar += ap.Conectado;
        }
        return retornar;
    }

    [WebMethod]
    public void EliminarUsuario(string nick)
    {
        arbol.Eliminar(arbol.primero, nick);
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
        
        matriz.GenerarGrafo(matriz.primero.atras.filas, TamX, TamY, "matrizNivel0" + opcion,opcion);
        matriz.GenerarGrafo(matriz.primero.filas, TamX, TamY, "matrizNivel1" + opcion, opcion);
        matriz.GenerarGrafo(matriz.primero.adelante.filas, TamX, TamY, "matrizNivel2" + opcion, opcion);
        matriz.GenerarGrafo(matriz.primero.adelante.adelante.filas, TamX, TamY, "matrizNivel3" + opcion, opcion);

        matrizDestruido.GenerarGrafo(matrizDestruido.primero.atras.filas, TamX, TamY, "matrizNivel0Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.filas, TamX, TamY, "matrizNivel1Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.adelante.filas, TamX, TamY, "matrizNivel2Destruido" + opcion, opcion);
        matrizDestruido.GenerarGrafo(matrizDestruido.primero.adelante.adelante.filas, TamX, TamY, "matrizNivel3Destruido" + opcion, opcion);


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
    public void Modificar(string antes, string nick, string pass,string correo, Byte estado)
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
        return arbol.MostrarTop10Usuarios();
        
    }

    [WebMethod]
    public string Top10Porcentaje()
    {
        return arbol.MostrarTop10Porcentaje();
    }


    

    [WebMethod]
    public void InsertarUnidadesMatriz(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        if (nivel == 0)
        {
            if (matriz.submarino <= Univel0)
            {
                matriz.Insertar(matriz.primero.atras, tipo, jugador, fila, columna, estado);
                matriz.submarino = matriz.submarino + 1;
            }
            
        }
        else if (nivel == 1)
        {
            if ((matriz.fragata + matriz.crucero) <= Univel1)
            {
                matriz.Insertar(matriz.primero, tipo, jugador, fila, columna, estado);
                if (tipo.Contains("Fragata"))
                {
                    matriz.fragata = matriz.fragata + 1;
                }
                else if (tipo.Contains("Crucero"))
                {
                    matriz.crucero = matriz.crucero + 1;
                }
            }
            
        }
        else if (nivel == 2)
        {
            if ((matriz.bombardero + matriz.caza + matriz.helicoptero) <= Univel2)
            {
                matriz.Insertar(matriz.primero.adelante, tipo, jugador, fila, columna, estado);
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
            }
            
        }
        else if (nivel == 3)
        {
            if (matriz.neosatelite <= Univel3)
            {
                Pivote ae = matriz.primero.adelante;
                matriz.Insertar(ae.adelante, tipo, jugador, fila, columna, estado);
                matriz.neosatelite = matriz.neosatelite + 1;
            }
            
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
    public void ConfigurarParametros(int Un0, int Un1, int Un2, int Un3, int tiempo,int tx,int ty)
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
        }
        
        
        
    }

    [WebMethod]
    public string ObtenerUnivel0()
    {
        string retorno = ""+Univel0.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerUnivel1()
    {
        string retorno = ""+Univel1.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerUnivel2()
    {
        string retorno = ""+Univel2.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerUnivel3()
    {
        string retorno = ""+Univel3.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerTiempo()
    {
        string retorno = ""+Tiempo.ToString();
        return retorno;
    }

    [WebMethod]
    public string ObtenerTamX()
    {
        string retorno = ""+TamX.ToString();
        return retorno;
    }
    [WebMethod]
    public string ObtenerTamY()
    {
        string retorno = ""+TamY.ToString();
        return retorno;
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
    public void EliminarUnidades(string fila,string columna,int nivel)
    {
        if (nivel == 0)
        {
            matriz.Eliminar(matriz.primero.atras, fila, columna);
        }
        else if (nivel == 1)
        {
            matriz.Eliminar(matriz.primero, fila, columna);
        }
        else if (nivel == 2)
        {
            matriz.Eliminar(matriz.primero.adelante, fila, columna);
        }
        else if (nivel == 3)
        {
            matriz.Eliminar(matriz.primero.adelante.adelante, fila, columna);
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

}
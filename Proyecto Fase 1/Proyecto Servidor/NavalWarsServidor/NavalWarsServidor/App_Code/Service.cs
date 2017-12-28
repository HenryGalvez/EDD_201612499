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
    /*static Matriz matrizNivel0 = new Matriz();
    static Matriz matrizNivel1 = new Matriz();
    static Matriz matrizNivel2 = new Matriz();
    static Matriz matrizNivel3 = new Matriz();



    static Matriz matrizNivel0Destruidas = new Matriz();
    static Matriz matrizNivel1Destruidas = new Matriz();
    static Matriz matrizNivel2Destruidas = new Matriz();
    static Matriz matrizNivel3Destruidas = new Matriz();*/
    static Matriz matriz = new Matriz();
    string nick = "Admin",pass = "admin";
    static int Univel0 = 0;
    static int Univel1 = 0;
    static int Univel2 = 0;
    static int Univel3 = 0;
    static int TamX = 25;
    static int TamY = 25;
    static int Tiempo = 0;

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
    public void MostrarTableros()
    {
        
        matriz.GenerarGrafo(matriz.primero.atras.filas, TamX, TamY, "matrizNivel0");
        matriz.GenerarGrafo(matriz.primero.filas, TamX, TamY, "matrizNivel1");
        matriz.GenerarGrafo(matriz.primero.adelante.filas, TamX, TamY, "matrizNivel2");
        matriz.GenerarGrafo(matriz.primero.adelante.adelante.filas, TamX, TamY, "matrizNivel3");
        

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
    public string Top10Usuarios()
    {
        return arbol.MostrarTop10Usuarios();
        
    }

    [WebMethod]
    public string Top10Porcentaje()
    {
        return arbol.MostrarTop10Porcentaje();
    }


    /*[WebMethod]
    public void InsertarUnidadesNivel0(string jugador,string tipo,string fila,string columna,Byte estado,int nivel)
    {
        
        matrizNivel0.Insertar(matrizNivel0.primero,tipo, jugador, fila, columna, estado);
        
    }

    [WebMethod]
    public int InsertarUnidadesNivel1(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
        matrizNivel1.Insertar(matrizNivel1.primero, tipo, jugador, fila, columna, estado);
        return matrizNivel1.count;
    }
    [WebMethod]
    public void InsertarUnidadesNivel2(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
        matrizNivel2.Insertar(matrizNivel2.primero, tipo, jugador, fila, columna, estado);
        
    }
    [WebMethod]
    public void InsertarUnidadesNivel3(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
        matrizNivel3.Insertar(matrizNivel3.primero, tipo, jugador, fila, columna, estado);

    }
    [WebMethod]
    public void InsertarUnidadesNivel0Destruidas(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
         matrizNivel0Destruidas.Insertar(matrizNivel0Destruidas.primero, tipo, jugador, fila, columna, estado);
       
    }
    [WebMethod]
    public void InsertarUnidadesNivel1Destruidas(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
         matrizNivel1Destruidas.Insertar(matrizNivel1Destruidas.primero, tipo, jugador, fila, columna, estado);
         
    }
    [WebMethod]
    public void InsertarUnidadesNivel2Destruidas(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        
        matrizNivel2Destruidas.Insertar(matrizNivel2Destruidas.primero, tipo, jugador, fila, columna, estado);
        
    }
    [WebMethod]
    public void InsertarUnidadesNivel3Destruidas(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        matrizNivel3Destruidas.Insertar(matrizNivel3Destruidas.primero, tipo, jugador, fila, columna, estado);
       
    }*/

    [WebMethod]
    public void InsertarUnidadesMatriz(string jugador, string tipo, string fila, string columna, Byte estado, int nivel)
    {
        if (nivel == 0)
        {
            matriz.Insertar(matriz.primero.atras, tipo, jugador, fila, columna, estado);
        }
        else if (nivel == 1)
        {
            matriz.Insertar(matriz.primero, tipo, jugador, fila, columna, estado);
        }
        else if (nivel == 2)
        {
            matriz.Insertar(matriz.primero.adelante, tipo, jugador, fila, columna, estado);
        }
        else if (nivel == 3)
        {
            Pivote ae= matriz.primero.adelante;
            matriz.Insertar(ae.adelante, tipo, jugador, fila, columna, estado);
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


}
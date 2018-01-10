using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Matriz
/// </summary>
class Matriz
{
    public Pivote primero;
    public int count;
    public int neosatelite;
    public int bombardero;
    public int caza;
    public int helicoptero;
    public int fragata;
    public int crucero;
    public int submarino;
    public string nombreD;
    

    public Matriz()
    {
        primero = new Pivote(1);
        nombreD = "";
        neosatelite = 1;
        bombardero = 1;
        caza = 1;
        helicoptero = 1;
        fragata = 1;
        crucero = 1;
        submarino = 1;
        
        count = 0;
        Pivote a = new Pivote(0);
        Pivote c = new Pivote(2);
        Pivote d = new Pivote(3);
        primero.atras = a;
        a.adelante = primero;

        primero.adelante = c;
        c.atras = primero;

        c.adelante = d;
        d.atras = c;
    }


    public void InsertarHeaderColumnas(Pivote piv,string columna)
    {
        Header aux = piv.columnas;
        if (aux.siguiente != null)
        {
            aux = aux.siguiente;
            while (aux != null)
            {
                if (string.Compare(columna, aux.valor, true) < 0)
                {
                    Header aux2 = aux.anterior;
                    Header ingresar = new Header(columna);
                    aux2.siguiente = ingresar;
                    ingresar.anterior = aux2;

                    ingresar.siguiente = aux;
                    aux.anterior = ingresar;
                    break;

                }
                else if (string.Compare(columna, aux.valor, true) > 0)
                {
                    if (aux.siguiente != null)
                    {
                        aux = aux.siguiente;
                    }
                    else
                    {
                        Header sd = new Header(columna);
                        aux.siguiente = sd;
                        sd.anterior = aux;
                        break;
                    }

                }
                else if (string.Compare(columna, aux.valor, true) == 0)
                {
                    break;
                }

            }
        }
        else
        {
            Header d = new Header(columna);
            aux.siguiente = d;
            d.anterior = aux;
        }




    }

    public void InsertarHeaderFilas(Pivote piv,string fila)
    {
        Header aux = piv.filas;
        if (aux.siguiente != null)
        {
            aux = aux.siguiente;
            while (aux != null)
            {
                if (Convert.ToInt32(fila) < Convert.ToInt32(aux.valor))
                {
                    Header aux2 = aux.anterior;
                    Header ingresar = new Header(fila);
                    aux2.siguiente = ingresar;
                    ingresar.anterior = aux2;

                    ingresar.siguiente = aux;
                    aux.anterior = ingresar;
                    break;

                }
                else if (Convert.ToInt32(fila) > Convert.ToInt32(aux.valor))
                {
                    if (aux.siguiente != null)
                    {
                        aux = aux.siguiente;
                    }
                    else
                    {
                        Header sd = new Header(fila);
                        aux.siguiente = sd;
                        sd.anterior = aux;
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
        }
        else
        {
            Header d = new Header(fila);
            aux.siguiente = d;
            d.anterior = aux;
        }
    }

    public Header Encabezados(Header guia, string valor)
    {
        if (guia != null && guia.valor != valor)
        {
            return Encabezados(guia.siguiente, valor);
        }
        else
        {
            return guia;
        }

    }

    public int Insertar(Pivote piv, string valor, string jugador, string fila, string columna, Byte estado)
    {
        NodoMatriz a = Existe(piv.columnas, fila, columna);
        if (a == null)
        {
            InsertarU(piv, valor, jugador, fila, columna, estado);
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public void InsertarU(Pivote piv,string valor,string jugador, string fila, string columna,Byte estado)
    {
        InsertarHeaderColumnas(piv,columna);
        
        InsertarHeaderFilas(piv,fila);

        

        Header fil = Encabezados(piv.filas,fila);
        Header colum = Encabezados(piv.columnas,columna);


        string a = colum.valor;
        string b = fil.valor;

        string c = colum.anterior.valor;
        string d = fil.anterior.valor;

        NodoMatriz sd = new NodoMatriz(valor,jugador, fila, columna,estado);
        NodoMatriz aux= fil.primero;

        if (aux.siguiente != null)
        {
            aux = aux.siguiente;
            while (aux != null)
            {
                if (string.Compare(columna, aux.columna, true) < 0)
                {

                    NodoMatriz au = aux.anterior;

                    au.siguiente = sd;
                    sd.anterior = au;

                    sd.siguiente = aux;
                    aux.anterior = sd;
                    ++count;
                    break;

                }
                else if (string.Compare(columna, aux.columna, true) > 0)
                {
                    if (aux.siguiente != null)
                    {
                        aux = aux.siguiente;
                    }
                    else
                    {

                        aux.siguiente = sd;
                        sd.anterior = aux;
                        ++count;
                        break;
                    }
                }
                else 
                {
                    
                    break;

                }
                //else if (aux.siguiente == null)
                {

                    //aux.siguiente = sd;
                    //sd.anterior = aux;
                    //break;
                }
                //aux = aux.siguiente;
            }
        }
        else
        {

            fil.primero.siguiente = sd;
            sd.anterior = fil.primero;
            ++count;
        }

        
        aux = colum.primero;

        if (aux.abajo != null)
        {
            aux = aux.abajo;
            while (aux != null)
            {
                if (string.Compare(fila, aux.fila, true) < 0)
                {

                    NodoMatriz au = aux.arriba;

                    au.abajo = sd;
                    sd.arriba = au;

                    sd.abajo = aux;
                    aux.arriba = sd;
                    
                    break;

                }
                else if (string.Compare(fila, aux.fila, true) > 0)
                {
                    if (aux.abajo != null)
                    {
                        aux = aux.abajo;
                    }
                    else
                    {
                        
                        aux.abajo = sd;
                        sd.arriba = aux;
                        
                        break;
                    }
                }
                else 
                {

                    
                    break;

                }
                //else if (aux.abajo == null)
                {

                    //aux.abajo = sd;
                    //sd.arriba = aux;
                    //break;
                }
                //aux = aux.abajo;
            }
        }
        else
        {

            colum.primero.abajo = sd;
            sd.arriba = colum.primero;
        }

        
        NodoMatriz nivelS;
        NodoMatriz nivelA;
        if (piv.nivel == 0)
        {
            nivelS = Existe(piv.adelante.columnas, fila, columna);
            if (nivelS != null)
            {
                nivelS.atras = sd;
                sd.adelante = nivelS;
            }
            else
            {
                nivelS = Existe(piv.adelante.adelante.columnas, fila, columna);
                if (nivelS != null)
                {
                    nivelS.atras = sd;
                    sd.adelante = nivelS;
                }
                else
                {
                    nivelS = Existe(piv.adelante.adelante.adelante.columnas, fila, columna);
                    if (nivelS != null)
                    {
                        nivelS.atras = sd;
                        sd.adelante = nivelS;
                    }
                }
            }
        }
        else if (piv.nivel == 1)
        {
            nivelS = Existe(piv.adelante.columnas, fila, columna);
            if (nivelS != null)
            {
                nivelS.atras = sd;
                sd.adelante = nivelS;
            }
            else
            {
                nivelS = Existe(piv.adelante.adelante.columnas, fila, columna);
                if (nivelS != null)
                {
                    nivelS.atras = sd;
                    sd.adelante = nivelS;
                }
            }

            nivelA = Existe(piv.atras.columnas, fila, columna);
            if (nivelA != null)
            {
                nivelA.adelante = sd;
                sd.atras = nivelA;
            }

        }
        else if (piv.nivel == 2)
        {
            nivelS = Existe(piv.adelante.columnas, fila, columna);
            if (nivelS != null)
            {
                nivelS.atras = sd;
                sd.adelante = nivelS;
            }

            nivelA = Existe(piv.atras.columnas, fila, columna);
            if (nivelA != null)
            {
                nivelA.adelante = sd;
                sd.atras = nivelA;
            }
            else
            {
                nivelA = Existe(piv.atras.atras.columnas, fila, columna);
                if (nivelA != null)
                {
                    nivelA.adelante = sd;
                    sd.atras = nivelA;
                }
            }
        }
        else if (piv.nivel == 3)
        {
            nivelA = Existe(piv.atras.columnas, fila, columna);
            if (nivelA != null)
            {
                nivelA.adelante = sd;
                sd.atras = nivelA;
            }
            else
            {
                nivelA = Existe(piv.atras.atras.columnas, fila, columna);
                if (nivelA != null)
                {
                    nivelA.adelante = sd;
                    sd.atras = nivelA;
                }
                else
                {
                    nivelA = Existe(piv.atras.atras.atras.columnas, fila, columna);
                    if (nivelA != null)
                    {
                        nivelA.adelante = sd;
                        sd.atras = nivelA;
                    }
                }
            }
        }
        


    }

    public NodoMatriz Existe(Header guia,string fila, string columna)
    {
        Header colum = Encabezados(guia, columna);
        NodoMatriz no;
        if (colum != null)
        {
            no = colum.primero.abajo;
        }else
        {
            no = null;
        }
        
        if (no != null)
        {

            while (no != null)
            {
                if (Convert.ToInt32(fila) == Convert.ToInt32(no.fila))
                {
                    break;

                }
                no = no.abajo;
            }
        }
        else
        {
            no = null;
        }
        
        return no;
        
    }

    public void EliminarOtrosNiveles(NodoMatriz guia,int nivel )
    {
        NodoMatriz nivelS;
        NodoMatriz nivelA;

        if (nivel == 0)
        {
            nivelS = guia.adelante;
            if (nivelS != null)
            {
                nivelS.atras = null;
                guia.adelante = null;
            }
        }
        else if (nivel == 1)
        {
            nivelS = guia.adelante;
            nivelA = guia.atras;
            if (nivelS != null && nivelA == null)
            {
                nivelS.atras = null;
                guia.adelante = null;
            }
            else if (nivelS == null && nivelA != null)
            {
                nivelA.adelante = null;
                guia.atras = null;
            }
            else if (nivelS != null && nivelA != null)
            {
                nivelA.adelante = nivelS;
                nivelS.atras = nivelA;
                guia.adelante = null;
                guia.atras = null;
            }



        }
        else if (nivel == 2)
        {
            nivelS = guia.adelante;
            nivelA = guia.atras;
            if (nivelS != null && nivelA == null)
            {
                nivelS.atras = null;
                guia.adelante = null;
            }
            else if (nivelS == null && nivelA != null)
            {
                nivelA.adelante = null;
                guia.atras = null;
            }
            else if (nivelS != null && nivelA != null)
            {
                nivelA.adelante = nivelS;
                nivelS.atras = nivelA;
                guia.adelante = null;
                guia.atras = null;
            }
        }
        else if (nivel == 3)
        {
            
            nivelA = guia.atras;
            if (nivelA != null)
            {
                nivelA.adelante = null;
                guia.atras = null;
            }
            
        }

    }

    public void EliminarA(Pivote piv ,string unidad)
    {
        

        Header filas = piv.filas;
        NodoMatriz aux = new NodoMatriz("", "", "", "", 0);
        if (filas.siguiente != null)
        {
            filas = filas.siguiente;
            while (filas != null)
            {
                aux = filas.primero;
                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                    while (aux != null)
                    {
                        if (string.Compare(unidad, aux.nombre) == 0)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux != null && string.Compare(unidad, aux.nombre) == 0)
                    {
                        break;
                    }
                }

                filas = filas.siguiente;
            }

        }
        if (aux.fila != "" && aux.columna != "")
        {


            Eliminar(piv, aux.fila, aux.columna);

        }
        
    }


    public void Eliminar(Pivote piv,string fila, string columna)
    {
        Header aux = piv.columnas;
        while (aux != null)
        {

            if (string.Compare(columna, aux.valor) == 0)
            {
                break;
            }
            aux = aux.siguiente;
        }
        NodoMatriz ae;
        if (aux != null)
        {
            ae = aux.primero;
        }
        else
        {
            ae = null;
        }

        while (ae != null)
        {

            if (string.Compare(fila, ae.fila, true) == 0)
            {
                break;
            }
            ae = ae.abajo;
        }
        if (ae != null)
        {
            if (ae.siguiente == null && ae.abajo == null)
            {
                EliminarOtrosNiveles(ae, piv.nivel);

                NodoMatriz ant1 = ae.anterior;
                NodoMatriz ant2 = ae.arriba;
                ae.arriba = null;
                ae.anterior = null;
                ant1.siguiente = null;
                ant2.abajo = null;

                

            }
            else if (ae.siguiente != null && ae.abajo == null)
            {
                EliminarOtrosNiveles(ae, piv.nivel);
                NodoMatriz ant1 = ae.anterior;
                NodoMatriz ant2 = ae.arriba;
                NodoMatriz sig = ae.siguiente;
                ae.arriba = null;
                ae.anterior = null;
                ae.siguiente = null;
                ant1.siguiente = sig;
                sig.anterior = ant1;
                ant2.abajo = null;

            }
            else if (ae.siguiente == null && ae.abajo != null)
            {
                EliminarOtrosNiveles(ae, piv.nivel);
                NodoMatriz ant1 = ae.anterior;
                NodoMatriz ant2 = ae.arriba;
                NodoMatriz sig = ae.abajo;
                ae.arriba = null;
                ae.anterior = null;
                ae.abajo = null;
                ant1.siguiente = null;
                sig.arriba = ant2;
                ant2.abajo = sig;

            }
            else if (ae.siguiente != null && ae.abajo != null)
            {
                EliminarOtrosNiveles(ae, piv.nivel);
                NodoMatriz ant1 = ae.anterior;
                NodoMatriz ant2 = ae.arriba;
                NodoMatriz sig = ae.siguiente;
                NodoMatriz sig2 = ae.abajo;
                ae.arriba = null;
                ae.anterior = null;
                ae.siguiente = null;
                ae.abajo = null;
                ant1.siguiente = sig;
                sig.anterior = ant1;
                ant2.abajo = sig2;
                sig2.arriba = ant2;

            }
        }

        aux = piv.columnas;
        if (aux.siguiente != null)
        {
            aux = aux.siguiente;
            while (aux != null)
            {
                if (aux.primero.abajo == null)
                {
                    if (aux.siguiente == null)
                    {
                        Header n = aux.anterior;
                        aux.anterior = null;
                        n.siguiente = null;
                    }
                    else if (aux.siguiente != null)
                    {
                        Header n = aux.anterior;
                        Header m = aux.siguiente;
                        n.siguiente = m;
                        m.anterior = n;
                        aux.anterior = null;
                        aux.siguiente = null;

                    }
                }
                aux = aux.siguiente;
            }
        }

        aux = piv.filas;
        if (aux.siguiente != null)
        {
            aux = aux.siguiente;
            while (aux != null)
            {
                if (aux.primero.siguiente == null)
                {
                    if (aux.siguiente == null)
                    {
                        Header n = aux.anterior;
                        aux.anterior = null;
                        n.siguiente = null;
                    }
                    else
                    {
                        Header n = aux.anterior;
                        Header m = aux.siguiente;
                        aux.anterior = null;
                        aux.siguiente = null;
                        n.siguiente = m;
                        m.anterior = n;
                    }
                }
                aux = aux.siguiente;
            }
        }



    }

    public int CambiarPosicion(Pivote piv, string valor,string filaA,string colA, string fila, string columna)
    {
        NodoMatriz a = Existe(piv.columnas, filaA, colA);
        if (a != null)
        {
            NodoMatriz s = Existe(piv.columnas, fila, columna);
            if (s == null)
            {
                NodoMatriz n = new NodoMatriz(a.nombre, a.jugador, fila, columna, a.estado);
                Eliminar(piv, filaA, colA);
                Insertar(piv, n.nombre, n.jugador, n.fila, n.columna, n.estado);
                return 0;
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

    public int Atacar(Pivote piv, string unidad, string fila, string columna,Pivote pivA)
    {
        Header filas = piv.filas;
        NodoMatriz aux = new NodoMatriz("", "", "", "", 0);
        if (filas.siguiente != null)
        {
            filas = filas.siguiente;
            while (filas != null)
            {
                aux = filas.primero;
                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                    while (aux != null)
                    {
                        if (string.Compare(unidad, aux.nombre) == 0)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux != null && string.Compare(unidad, aux.nombre) == 0)
                    {
                        break;
                    }
                }

                filas = filas.siguiente;
            }

        }
        if (aux.fila != "" && aux.columna != "")
        {


            NodoMatriz b = Existe(pivA.columnas, fila, columna);
            if (b != null)
            {
                b.vida -= aux.daño;
                nombreD = b.nombre;
                if (b.daño <= 0)
                {
                    nombreD = b.nombre;
                    EliminarA(pivA, b.nombre);
                    return 3;
                }
                return 0;
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

    


    public int CambiarPosicion(Pivote piv, string unidad, string fila, string columna)
    {
        InsertarHeaderColumnas(piv,columna);
        InsertarHeaderFilas(piv,fila);

        Header filas = piv.filas;
        NodoMatriz aux = new NodoMatriz("", "", "","",0);
        if (filas.siguiente != null)
        {
            filas = filas.siguiente;
            while (filas != null)
            {
                aux = filas.primero;
                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                    while (aux != null)
                    {
                        if (string.Compare(unidad,aux.nombre) == 0)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux != null && string.Compare(unidad, aux.nombre) == 0)
                    {
                        break;
                    }
                }

                filas = filas.siguiente;
            }

        }
        if (aux.fila != "" && aux.columna != "")
        {
            NodoMatriz d = Existe(piv.columnas, fila, columna);
            if (d == null)
            {
                NodoMatriz asd = new NodoMatriz(aux.nombre, aux.jugador, aux.fila, aux.columna, aux.estado);
                Eliminar(piv, aux.fila, aux.columna);
                asd.fila = fila;
                asd.columna = columna;
                Insertar(piv, asd.nombre, asd.jugador, fila, columna, asd.estado);
                return 0;
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
        //return false;


    }

    public int EsBase(string fila,string columna)
    {
        NodoMatriz a = Existe(primero.columnas, fila, columna);
        if (a != null)
        {
            if (a.nombre.Equals("Base"))
            {
                return 0;
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

    

    public int VerificarUnidades(string jugador1,string jugador2)
    {
        int count1 = -1, count2 = -1;
        Recorrer(primero.atras, jugador1, jugador2, count1, count2);
        Recorrer(primero, jugador1, jugador2, count1, count2);
        Recorrer(primero.adelante, jugador1, jugador2, count1, count2);
        Recorrer(primero.adelante.adelante, jugador1, jugador2, count1, count2);
        if (count1 > count2 && count2 == 0)
        {
            return 1;
        }
        else if (count2 > count1 && count1 == 0)
        {
            return 2;
        }
        else if (count1 != -1 && count2 != -1 && count1 == count2)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    

    public void Recorrer(Pivote piv, string jugador1, string jugador2, int count1, int count2)
    {
        Header filas = piv.filas;
        NodoMatriz aux = new NodoMatriz("", "", "", "", 0);
        if (filas.siguiente != null)
        {
            filas = filas.siguiente;
            while (filas != null)
            {
                aux = filas.primero;
                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                    while (aux != null)
                    {
                        if (string.Compare(jugador1, aux.jugador) == 0)
                        {
                            ++count1;
                        }
                        else if (string.Compare(jugador1, aux.jugador) == 0)
                        {
                            ++count2;
                        }
                        aux = aux.siguiente;
                    }
                    
                }

                filas = filas.siguiente;
            }

        }
        
        //return false;
    }



    //int cou;
    public void GenerarGrafo(Header guia, int x, int y,string nombrearchi,string opcion)
    {
        //cou = 0;
        string texto = "";

        texto += "digraph{" + Environment.NewLine;


        texto += MatrizGrafo(guia, x, y,opcion);
        





        texto += "}";

        string nombreArchivo = @"C:\EDD";
        string archivoN = nombrearchi+".dot";

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
            psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg C:\\EDD\\"+nombrearchi+".dot -o C:\\EDD\\"+nombrearchi+".jpg ");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            psi.CreateNoWindow = false;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();

        }





    }

    public string MatrizGrafo(Header guia, int x, int y, string opcion)
    {
        string txt = "";
        int countx = 1;
        int county = 64;
        Header aux = guia.siguiente;
        NodoMatriz us;
        int final = y+65;
        
        string cadena = "A";
        int primerContador = 65;
        int segundoContador = 65;
        
        string cad2 = "";
        Boolean coincidencia = false;
        //if (guia != null)
        {
            txt += "node[shape= plaintext label=<<table border=" + '"' + 0 + '"' + " cellborder=" + '"' + 1 + '"' + " cellspacing=" + '"' + 0 + '"' + ">" + Environment.NewLine;
            txt += "<tr>" + Environment.NewLine;
            for (int j = 64; j < final; j++)
            {
                if (j != 64)
                {
                    if (j>= 91)
                    {
                        
                        
                        txt += "<td><b> " + cadena + Convert.ToChar(segundoContador) + " </b></td>" + Environment.NewLine;
                        segundoContador++;
                        if (segundoContador >= 91)
                        {
                            cad2 = "";
                            segundoContador = 65;
                            primerContador++;
                            for (int d = 0; d < cadena.Length-1; d++)
                            {
                                cad2 += cadena[d];
                            }
                            cad2 += Convert.ToChar(primerContador);
                            cadena = cad2;
                        }
                        if (primerContador >= 91)
                        {
                            cad2 = "";
                            for (int d = 0; d < cadena.Length; d++)
                            {
                                cad2 += "A";
                            }
                            cad2 += "A";
                            cadena = cad2;
                            primerContador = 65;
                        }

                    }
                    else if (j < 91)
                    {
                        txt += "<td><b> " + Convert.ToChar(j) + " </b></td>" + Environment.NewLine;
                        
                    }
                    
                }
                else
                {
                    txt += "<td><b> </b></td>" + Environment.NewLine;
                }

            }
            txt += "</tr>" + Environment.NewLine;
            while (countx <= x)
            {
                txt += "<tr>" + Environment.NewLine;
                if (aux != null)
                {
                    us = aux.primero.siguiente;
                }
                else
                {
                    us = null;
                }
                while (county < y + 65)
                {
                    if (county == 64)
                    {
                        txt += "<td>" + countx + "</td>" + Environment.NewLine;
                    }
                    else
                    {
                        if (us != null)
                        {
                            
                            
                            if (string.Compare("" + Convert.ToChar(county), us.columna, true) == 0 && string.Compare(""+countx,aux.valor,true) == 0 )
                            {
                                if (opcion.Equals(""))
                                {
                                    txt += "<td> Tipo: " + us.nombre + "<br/>Movimiento: " + us.movimiento + "<br/>Alcance: "
                                    + us.alcance + "<br/>Daño: " + us.daño + "<br/>Vida: " + us.vida + "<br/>Jugador: " + us.jugador + " </td>" + Environment.NewLine;
                                }
                                else
                                {
                                    if (us.jugador.Equals(opcion) && us.nombre.Contains("Submarino"))
                                    {
                                        txt += "<td> Tipo: " + us.nombre + "<br/>Movimiento: " + us.movimiento + "<br/>Alcance: "
                                    + us.alcance + "<br/>Daño: " + us.daño + "<br/>Vida: " + us.vida + "<br/>Jugador: " + us.jugador + " </td>" + Environment.NewLine;
                                    }
                                    else if (us.nombre.Contains("Submarino") == false)
                                    {
                                        txt += "<td> Tipo: " + us.nombre + "<br/>Movimiento: " + us.movimiento + "<br/>Alcance: "
                                    + us.alcance + "<br/>Daño: " + us.daño + "<br/>Vida: " + us.vida + "<br/>Jugador: " + us.jugador + " </td>" + Environment.NewLine;
                                    }
                                }
                                
                                us = us.siguiente;
                                if (us != null)
                                {
                                    string a = us.nombre;
                                }
                                
                                if (aux.siguiente != null)
                                {
                                    string c = aux.siguiente.valor;
                                }
                                
                                coincidencia = true;
                            }
                            else
                            {
                                //string a = us.columna;
                                //string b = us.fila;
                                txt += "<td>  </td>" + Environment.NewLine;
                            }
                        }
                        else
                        {
                            txt += "<td>  </td>" + Environment.NewLine;
                        }
                    }


                    county++;
                }
                if (coincidencia == true)
                {
                    aux = aux.siguiente;
                    coincidencia = false;
                }
                





                county = 64;
                txt += "</tr>" + Environment.NewLine;
                countx++;
            }

            txt += "</table>>] a; ";
        }
        return txt;
    }

    public void Vaciar()
    {
        count = 0;
        neosatelite = 1;
        bombardero = 1;
        caza = 1;
        helicoptero = 1;
        fragata = 1;
        crucero = 1;
        submarino = 1;
        if (primero.columnas.siguiente != null)
        {
            Header a = primero.columnas.siguiente;
            primero.columnas.siguiente = null;
            a.anterior = null;
        }
        if(primero.filas.siguiente != null)
        {
            Header a = primero.filas.siguiente;
            primero.filas.siguiente = null;
            a.anterior = null;
        }


        if (primero.atras.columnas.siguiente != null)
        {
            Header a = primero.atras.columnas.siguiente;
            primero.atras.columnas.siguiente = null;
            a.anterior = null;
        }
        if (primero.atras.filas.siguiente != null)
        {
            Header a = primero.atras.filas.siguiente;
            primero.atras.filas.siguiente = null;
            a.anterior = null;
        }



        if (primero.adelante.columnas.siguiente != null)
        {
            Header a = primero.adelante.columnas.siguiente;
            primero.adelante.columnas.siguiente = null;
            a.anterior = null;
        }
        if (primero.adelante.filas.siguiente != null)
        {
            Header a = primero.adelante.filas.siguiente;
            primero.adelante.filas.siguiente = null;
            a.anterior = null;
        }



        if (primero.adelante.adelante.columnas.siguiente != null)
        {
            Header a = primero.adelante.adelante.columnas.siguiente;
            primero.adelante.adelante.columnas.siguiente = null;
            a.anterior = null;
        }
        if (primero.adelante.adelante.filas.siguiente != null)
        {
            Header a = primero.adelante.adelante.filas.siguiente;
            primero.adelante.adelante.filas.siguiente = null;
            a.anterior = null;
        }

    }
    
}
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


    public Matriz()
    {
        primero = new Pivote(1);
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

    public void Insertar(Pivote piv,string valor,string jugador, string fila, string columna,Byte estado)
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
        }
        else if (piv.nivel == 1)
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
        }
        else if (piv.nivel == 3)
        {
            nivelA = Existe(piv.atras.columnas, fila, columna);
            if (nivelA != null)
            {
                nivelA.adelante = sd;
                sd.atras = nivelA;
            }
        }
        


    }

    public NodoMatriz Existe(Header guia,string fila, string columna)
    {
        Header colum = Encabezados(guia, columna);
        NodoMatriz no;
        if (colum != null)
        {
            no = colum.primero.siguiente;
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


    public void Eliminar(string fila, string columna)
    {
        Header aux = primero.columnas;
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
                NodoMatriz ant1 = ae.anterior;
                NodoMatriz ant2 = ae.arriba;
                ae.arriba = null;
                ae.anterior = null;
                ant1.siguiente = null;
                ant2.abajo = null;
            }
            else if (ae.siguiente != null && ae.abajo == null)
            {
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

        aux = primero.columnas;
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

        aux = primero.filas;
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


    /*public Boolean CambiarPosicion(string valor, string fila, string columna)
    {
        InsertarHeaderColumnas(columna);
        InsertarHeaderFilas(fila);

        Header filas = primero.filas;
        NodoMatriz aux = new NodoMatriz("", "", "");
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
                        if (string.Compare(valor, aux.valor) == 0)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux != null && string.Compare(valor, aux.valor) == 0)
                    {
                        break;
                    }
                }

                filas = filas.siguiente;
            }

        }
        if (aux.fila != "" && aux.columna != "")
        {
            Eliminar(aux.fila, aux.columna);
            aux.fila = fila;
            aux.columna = columna;
            Insertar(aux.valor, aux.fila, aux.columna);
            return true;
        }
        return false;


    }*/
    //int cou;
    public void GenerarGrafo(Header guia, int x, int y,string nombrearchi)
    {
        //cou = 0;
        string texto = "";

        texto += "digraph{" + Environment.NewLine;

        texto += MatrizGrafo(guia, x, y);





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

    public string MatrizGrafo(Header guia, int x, int y)
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
                                txt += "<td> Tipo: " + us.nombre + "<br/>Movimiento: " + us.movimiento + "<br/>Alcance: "
                                    + us.alcance + "<br/>Daño: " + us.daño + "<br/>Vida: " + us.vida + "<br/>Jugador: " + us.jugador + " </td>" + Environment.NewLine;
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
    
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TablaHash
/// </summary>
class TablaHash
{
    public Nodo[] arreglo;
    public int size;
    public int ocupados;
    public double porcentajeOcupacion;

    public TablaHash(int tam)
    {
        arreglo = new Nodo[tam];
        porcentajeOcupacion = 0.00;
        ocupados = 0;
        size = tam;
        IniciarMatriz();

    }

    public int FuncionHash(string clave)
    {
        int num = 0;
        for (int i = 0; i < clave.Length; i++)
        {
            num += clave[i] % size;
        }

        //Console.WriteLine(num % size);
        return num % size;
    }

    public Boolean Existe(int clave)
    {
        if (arreglo[clave].Nickname != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ReHash(int clave)
    {
        int aux = clave;
        int count = 1;
        Boolean reinicio = false;
        Boolean coincidencia = false;
        while (arreglo[aux].Nickname != "")
        {

            aux = aux + Convert.ToInt32(Math.Pow(count, 2));
            ++count;
            if (aux >= size)
            {
                aux = 0;
                count = 1;
                reinicio = true;
            }
            if (aux >= clave && reinicio == true)
            {
                coincidencia = true;
                break;
            }
        }

        if (aux >= clave && coincidencia == true)
        {
            return -1;
        }
        else
        {
            return aux;
        }
    }

    public void IniciarMatriz()
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            arreglo[i] = new Nodo("", "","",0);
        }
    }

    public void AumentarSize()
    {
        Nodo[] aux = arreglo;
        arreglo = new Nodo[(2 * size)];
        size = (2 * size);
        ocupados = 0;
        CalcularPorcentajeOcupacion();

        IniciarMatriz();

        for (int i = 0; i < aux.Length; i++)
        {
            if (aux[i].Nickname != "")
            {
                Insertar(aux[i]);
            }

        }
    }

    public void DisminuirSize()
    {
        Nodo[] aux = arreglo;
        arreglo = new Nodo[(size / 2)];
        size = (size / 2);
        ocupados = 0;
        CalcularPorcentajeOcupacion();

        IniciarMatriz();

        for (int i = 0; i < aux.Length; i++)
        {
            if (aux[i].Nickname != "")
            {
                Insertar(aux[i]);
            }

        }
    }
    public int Buscar(string n)
    {
        int clave = FuncionHash(n);
        int aux = clave;
        int count = 1;
        Boolean reinicio = false, coincidencia = false;
        if (arreglo[clave].Nickname != n)
        {
            while (arreglo[aux].Nickname != n)
            {

                aux = aux + Convert.ToInt32(Math.Pow(count, 2));
                ++count;

                if (aux >= size)
                {
                    aux = 0;
                    reinicio = true;
                }
                if (aux >= clave && reinicio == true)
                {
                    coincidencia = true;
                    break;
                }
            }

            if (aux >= clave && coincidencia == true)
            {
                return -1;
            }
            else
            {
                return aux;
            }
        }
        else
        {
            return clave;
        }
    }
    public Boolean Eliminar(string n)
    {
        int clave = Buscar(n);
        if (clave != -1)
        {
            arreglo[clave] = new Nodo("", "","",0);
            --ocupados;
            CalcularPorcentajeOcupacion();
            if (porcentajeOcupacion <= 30)
            {
                DisminuirSize();
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean Modificar(Nodo n)
    {
        int clave = Buscar(n.Nickname);
        if (clave != -1)
        {
            if (n.Nickname != "")
            {
                arreglo[clave].Nickname = n.Nickname;
            }

            if (n.Contraseña != "")
            {
                arreglo[clave].Contraseña = n.Contraseña;
            }

            if (n.Correo != "")
            {
                arreglo[clave].Correo = n.Correo;
            }

            arreglo[clave].Conectado = n.Conectado;
            

            return true;
        }
        else
        {
            return false;
        }
    }

    public void CalcularPorcentajeOcupacion()
    {
        porcentajeOcupacion = ((double)ocupados / (double)size) * 100;
    }

    public Boolean Insertar(Nodo insert)
    {
        int clave = FuncionHash(insert.Nickname);
        if (Existe(clave))
        {
            int cl = ReHash(clave);
            if (cl != -1)
            {
                arreglo[cl] = insert;
                ++ocupados;
                CalcularPorcentajeOcupacion();
                if (porcentajeOcupacion >= 50)
                {
                    AumentarSize();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            arreglo[clave] = insert;
            ++ocupados;
            CalcularPorcentajeOcupacion();
            if (porcentajeOcupacion >= 50)
            {
                AumentarSize();
            }
            return true;
        }

    }
    public void GenerarGrafo()
    {

        string texto = "";

        texto += "digraph{" + Environment.NewLine;
        texto += "nodesep=.05;" + Environment.NewLine;
        texto += "rankdir=LR;" + Environment.NewLine;
        texto += "node [shape=record,width=.1,height=.1];" + Environment.NewLine;

        texto += Grafo();





        texto += "}";

        GrabarArchivo(texto);

        System.Diagnostics.ProcessStartInfo psi;


        {
            psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg C:\\EDD\\tablas\\grafomatriz.dot -o C:\\EDD\\tablas\\grafomatriz.jpg ");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            psi.CreateNoWindow = false;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();

        }





    }

    public string Grafo()
    {
        string txt = "";
        txt += "node0[label=" + '"' + Environment.NewLine;
        for (int i = 0; i < arreglo.Length; i++)
        {
            txt += i + ". " + arreglo[i].Nickname;
            txt += "\\n" + arreglo[i].Contraseña + " | " + Environment.NewLine;
        }
        txt += '"' + ", height=2.5];" + Environment.NewLine;

        return txt;

    }

    public void GrabarArchivo(string dato)
    {
        string nombreArchivo = @"C:\EDD\tablas";
        string archivoN = "grafomatriz.dot";

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
}
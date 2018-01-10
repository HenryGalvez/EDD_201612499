using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolB
{
    class NodoArbolB
    {
        public int valor;
        public Pagina izquiera;
        public Pagina derecha;

        public NodoArbolB(int val)
        {
            valor = val;
            izquiera = null;
            derecha = null;
        }
    }
    class Pagina
    {
        public NodoArbolB[] valores;
        public int espaciosO;
        public int id;
        public Pagina(int tamaño)
        {
            valores = new NodoArbolB[tamaño];
            id = 0;
            for (int i = 0; i < tamaño; i++)
            {
                valores[i] = new NodoArbolB(1000000000);
            }
        }
    }

    class ArbolB
    {
        public Pagina primera;
        public int tam;
        public int nodos;

        public ArbolB(int tam)
        {
            nodos = 0;
            this.tam = tam;
            primera = null;
        }

        public void Ordenar(NodoArbolB[] orden)
        {
            NodoArbolB temp;

            for (int i = 0; i < orden.Length; i++)
            {
                for (int j = 0; j < orden.Length - 1; j++)
                {
                    if ((orden[j].valor) > (orden[j + 1].valor))
                    {
                        temp = orden[j + 1];
                        orden[j + 1] = orden[j];
                        orden[j] = temp;
                    }
                }
            }
        }

        public void InsertarNodo(Pagina guia,NodoArbolB insert)
        {
            if (guia != null)
            {
                for (int i = 0; i < guia.valores.Length; i++)
                {
                    if (guia.valores[i].valor == 1000000000)
                    {
                        if (insert.valor != 1000000000)
                        {
                            guia.valores[i] = insert;
                            try
                            {
                                guia.valores[(i + 1)].izquiera = insert.derecha;
                            }
                            catch (Exception we)
                            {

                            }
                            guia.espaciosO = guia.espaciosO + 1;
                        }
                        else
                        {
                            guia.valores[i] = insert;

                            guia.espaciosO = guia.espaciosO + 1;
                        }
                        


                        break;
                    }
                }
                Ordenar(guia.valores);
            }
        }

        NodoArbolB ret = null;
        Pagina izq = null;
        Pagina derc = null;

        public void Insertar(int val)
        {
            if (primera == null)
            {
                primera = new Pagina(tam);
                primera.id = nodos;
                ++nodos;
                InsertarNodo(primera, new NodoArbolB(val));
            }
            else
            {
                RecurrisionInsertar(primera, val);
                if (ret != null)
                {
                    //int d = tam / 2;
                    
                    //Pagina iz = new Pagina(tam), der = new Pagina(tam);
                    //for (int m = 0; m < d - 1; m++)
                    //{
                    //    InsertarNodo(iz, primera.valores[m]);
                    //}
                    //for (int m = d; m < tam; m++)
                    //{
                    //    InsertarNodo(der, primera.valores[m]);
                    //}
                    //ret = primera.valores[d - 1];
                    //izq = iz;
                    //derc = der;


                    Pagina aux = new Pagina(tam);
                    aux.id = nodos;
                    ++nodos;
                    InsertarNodo(aux, ret);
                    for (int k = 0; k < aux.valores.Length; k++)
                    {
                        if (aux.valores[k].valor == ret.valor)
                        {
                            if (k != 0)
                            {
                                //guia.valores[h].izquiera = new Pagina(tam);
                                //guia.valores[(h - 1)].derecha = new Pagina(tam);
                                aux.valores[k].izquiera = izq;
                                aux.valores[(k - 1)].derecha = izq;
                            }
                            else
                            {
                                //guia.valores[h].izquiera = new Pagina(tam);
                                aux.valores[k].izquiera = izq;
                            }
                            //guia.valores[h].derecha = new Pagina(tam);
                            aux.valores[k].derecha = derc;

                            //if ((k + 1) <= tam-1)
                            try
                            {
                                aux.valores[(k + 1)].izquiera = derc;
                            }
                            catch (Exception we)
                            {
                            }



                            //aux.valores[k].izquiera = izq;
                            //aux.valores[k].derecha = derc;
                            //try
                            //{
                            //    aux.valores[k + 1].izquiera = derc;
                            //}
                            //catch (Exception ewe)
                            //{

                            //}

                        }
                    }

                    primera = aux;
                    izq = null;
                    derc = null;
                    ret = null;
                }
                else
                {
                    ret = null;
                }
                
            }
        }
        
        public void RecurrisionInsertar(Pagina guia, int val)
        {
            if (guia != null)
            {
                for (int i = 0; i < guia.valores.Length; i++)
                {
                    if (guia.valores[i].valor > val && guia.valores[i].izquiera != null)
                    {
                        
                        RecurrisionInsertar(guia.valores[i].izquiera, val);
                        if (ret != null)
                        {
                            //if (guia != primera)
                            {
                                InsertarNodo(guia, ret);
                                for (int h = 0; h < guia.valores.Length; h++)
                                {
                                    if (ret != null && guia.valores[h].valor == ret.valor)
                                    {
                                        if (h != 0)
                                        {
                                            //guia.valores[h].izquiera = new Pagina(tam);
                                            //guia.valores[(h - 1)].derecha = new Pagina(tam);
                                            guia.valores[h].izquiera = izq;
                                            guia.valores[(h - 1)].derecha = izq;
                                        }
                                        else
                                        {
                                            //guia.valores[h].izquiera = new Pagina(tam);
                                            guia.valores[h].izquiera = izq;
                                        }
                                        //guia.valores[h].derecha = new Pagina(tam);
                                        guia.valores[h].derecha = derc;

                                        //if ((h + 1) <= tam)
                                        try
                                        {
                                            guia.valores[(h + 1)].izquiera = derc;
                                        }
                                        catch (Exception ewe)
                                        {

                                        }

                                        izq = null;
                                        derc = null;
                                        ret = null;
                                    }
                                }
                            }
                            //else
                            //{
                            //    Pagina aux = new Pagina(tam);
                            //    InsertarNodo(aux, ret);
                            //    for (int k = 0; k < aux.valores.Length; k++)
                            //    {
                            //        if (aux.valores[k].valor == ret)
                            //        {
                            //            aux.valores[k].izquiera = izq;
                            //            aux.valores[k].derecha = derc;
                            //            try
                            //            {
                            //                aux.valores[k + 1].izquiera = derc;
                            //            }
                            //            catch (Exception ewe)
                            //            {

                            //            }
                            //        }
                            //    }

                            //    primera = aux;
                            //    ret = 1000000000;
                            //}


                        }
                        if (guia.espaciosO == tam)
                        {
                            int d = tam / 2;
                            Pagina iz = new Pagina(tam), der = new Pagina(tam);
                            iz.id = nodos;
                            ++nodos;
                            der.id = nodos;
                            ++nodos;
                            for (int m = 0; m < d - 1; m++)
                            {
                                InsertarNodo(iz, guia.valores[m]);
                            }
                            for (int m = d; m < tam; m++)
                            {
                                InsertarNodo(der, guia.valores[m]);
                            }
                            ret = guia.valores[d-1];
                            izq = iz;
                            derc = der;
                        }
                        else
                        {
                            ret = null;
                        }
                        return;
                    }
                    else if (guia.valores[i].valor > val && guia.valores[i].izquiera == null)
                    {
                        InsertarNodo(guia, new NodoArbolB(val));
                        //Console.WriteLine(guia.espaciosO);
                        if (guia.espaciosO == tam)
                        {
                            int d = tam / 2;
                            //Console.WriteLine("  " + d);
                            Pagina iz = new Pagina(tam), der = new Pagina(tam);
                            iz.id = nodos;
                            ++nodos;
                            der.id = nodos;
                            ++nodos;
                            for (int m = 0; m < d - 1; m++)
                            {
                                InsertarNodo(iz, guia.valores[m]);
                            }
                            
                            for (int m = d; m < tam; m++)
                            {
                                InsertarNodo(der, guia.valores[m]);
                            }
                            ret = guia.valores[d-1];
                            izq = iz;
                            derc = der;
                        }
                        else
                        {
                            ret = null;
                        }
                        
                        if (guia == primera && guia.espaciosO == tam)
                        {
                            Pagina aux = new Pagina(tam);
                            aux.id = nodos;
                            ++nodos;
                            InsertarNodo(aux, ret);
                            for (int k = 0; k < aux.valores.Length; k++)
                            {
                                if (aux.valores[k].valor == ret.valor)
                                {
                                    aux.valores[k].izquiera = izq;
                                    aux.valores[k].derecha = derc;
                                    try
                                    {
                                        aux.valores[k + 1].izquiera = derc;
                                    }
                                    catch (Exception ewe)
                                    {

                                    }
                                    
                                }
                            }
                            
                            primera = aux;
                            izq = null;
                            derc = null;
                            ret= null;
                        }
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }


        


        public void GenerarGrafo()
        {
            
            string texto = "";

            texto += "digraph{" + Environment.NewLine;

            texto += ArbolGrafo(primera);





            texto += "}";

            GrabarArchivo(texto);

            System.Diagnostics.ProcessStartInfo psi;


            {
                psi = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + " dot -Tjpg " + @"C:\EDD\grafoprueba\grafoavl.dot" + " -o " + @"C:\EDD\grafoprueba\grafoavl.jpg ");
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;

                psi.CreateNoWindow = false;

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = psi;
                p.Start();

            }





        }

        //int count = 0;
        //int nof = 0;

        public string ArbolGrafo(Pagina guia)
        {
            string txt = "";
            
            if (guia != null)
            {
                
                txt += "node[shape = record, height = .1]"+Environment.NewLine;
                txt += "node"+guia.id+"[label = " + '"';
                
                for (int i = 0; i < tam; i++)
                {
                    if (guia.valores[i].valor != 1000000000)
                    {
                        txt += "<f" + i + "> " + guia.valores[i].valor + "| ";
                    }
                    else
                    {
                        txt += "<f" + i + ">  | ";
                    }
                    
                    
                }
                txt += '"' + "]"+Environment.NewLine;
                
                for (int i = 0; i < tam ; i++)
                {
                    if (guia.valores[i].izquiera != null)
                    {
                        
                        txt += ArbolGrafo(guia.valores[i].izquiera);
                        txt += '"' + "node" + guia.id + '"' + ":f" + i + "->" + '"' + "node" + guia.valores[i].izquiera.id + '"' + ":f0" + Environment.NewLine;
                    }
                    if (i == tam-1 && guia.valores[i].derecha != null)
                    {
                        txt += ArbolGrafo(guia.valores[i].derecha);
                        txt += '"' + "node" + guia.id + '"' + ":f" + i + "->" + '"' + "node" + guia.valores[i].derecha.id + '"' + ":f0" + Environment.NewLine;
                    }

                }
                



            }
            return txt;

        }


        public void GrabarArchivo(string dato)
        {
            string nombreArchivo = @"C:\EDD\grafoprueba";
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ArbolB a = new ArbolB(4);
            //a.Insertar(10);
            //a.Insertar(34);
            //a.Insertar(56);
            //a.Insertar(78);
            //a.Insertar(84);
            //a.Insertar(97);
            //a.Insertar(110);
            //a.Insertar(150);
            //a.Insertar(200);
            //a.Insertar(180);

            //a.GenerarGrafo();

            Console.WriteLine("Seleccione un Tamaño de Pagina: ");
            ArbolB a = new ArbolB(Convert.ToInt32(Console.ReadLine()));
            a.GenerarGrafo();
            string hola = Console.ReadLine();

            while (hola != "exit")
            {
                //if (hola.Equals("modificar"))
                //{
                //    string la = "";
                //    Console.WriteLine("Dato a Modificar");
                //    la = Console.ReadLine();
                //    Console.WriteLine("Dato nuevo");
                //    hola = Console.ReadLine();
                //    int cla = a.Buscar(la);
                //    if (cla != -1)
                //    {
                //        a.arreglo[cla].Nickname = hola;
                //    }
                //}
                //else if (hola.Equals("eliminar"))
                //{
                //    Console.WriteLine("Dato a Eliminar");
                //    hola = Console.ReadLine();
                //    a.Eliminar(hola);
                //}
                //else
                //{
                //    a.Insertar(new Nodo(hola, ""));

                //}
                a.Insertar(Convert.ToInt32(hola));
                a.GenerarGrafo();
                hola = Console.ReadLine();


            }
            Console.ReadLine();
        }

    }
}

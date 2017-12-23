using System;
using System.IO;


namespace ConsoleApp1
{

    class Nodo
    {
        public string nombre;
        public Nodo izquiero;
        public Nodo derecho;

        public Nodo(string nombre_)
        {
            nombre = nombre_;
            izquiero = null;
            derecho = null;
        }
    }

    class Lista
    {
        public Nodo primero;
        
        public Lista()
        {
            primero = null;

        }


        public void PreOrden(Nodo guia)
        {
            if (guia != null)
            {
                Console.WriteLine(guia.nombre);
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
                Console.WriteLine(guia.nombre);
            }
        }


        public void EnOrden(Nodo guia)
        {
            if (guia != null)
            {
                EnOrden(guia.izquiero);
                Console.WriteLine(guia.nombre);
                EnOrden(guia.derecho);
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

        public void Insertar(Nodo guia,string nom)
        {
            if(primero != null)
            {
                if (EsMenorNick(nom,guia.nombre)== 0)
                {
                    if (guia.izquiero != null)
                    {
                        Insertar(guia.izquiero, nom);
                    }
                    else
                    {
                        guia.izquiero = new Nodo(nom);
                    }
                }
                else
                {
                    if (guia.derecho != null)
                    {
                        Insertar(guia.derecho, nom);
                    }
                    else
                    {
                        guia.derecho = new Nodo(nom);
                    }
                }
            }
            else
            {
                primero = new Nodo(nom);
            }
        }
        
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            string num = "";
            Lista a = new Lista();
            while (num != "exit")
            {
                Console.WriteLine("Ingresa un Caracter\nIngrese mostrar para mostrar los elementos\nIngrese exit para salir");
                num = Console.ReadLine();
                if (num.Equals("mostrar"))
                {
                    
                    Console.WriteLine("***************EnOrden\n");
                    a.EnOrden(a.primero);
                    Console.WriteLine("***************PreOrden\n");
                    a.PreOrden(a.primero);
                    Console.WriteLine("***************PostOrden\n");
                    a.PostOrden(a.primero);
                } else if (num.Equals("exit"))
                {
                    
                }
                else
                {

                    a.Insertar(a.primero,num);
                }

                
                
            }
            
        }


        



        
    }
}

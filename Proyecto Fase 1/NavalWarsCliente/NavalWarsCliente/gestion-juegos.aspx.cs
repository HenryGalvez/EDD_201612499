using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gestion_juegos : System.Web.UI.Page
{
    static int neosatelite = 1;
    static int bombardero = 1;
    static int caza = 1;
    static int helicoptero = 1;
    static int fragata = 1;
    static int crucero = 1;
    static int submarino = 1;

    ServiceNavalWars.ServiceSoapClient a = new ServiceNavalWars.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            a.MostrarTableros("");
            LabelNivel1.Text = "Unidades en el Nivel 1: "+a.ObtenerUnivel0();
            LabelNivel2.Text = "Unidades en el Nivel 2: " + a.ObtenerUnivel1();
            LabelNivel3.Text = "Unidades en el Nivel 3: " + a.ObtenerUnivel2();
            LabelNivel4.Text = "Unidades en el Nivel 4: " + a.ObtenerUnivel3();
            LabelTamx.Text = "Cantidad de Filas: " + a.ObtenerTamX();
            LabelTamy.Text = "Cantidad de Columnas: " + a.ObtenerTamY();
            LabelTiempo.Text = "Tiempo de Cada Partida: " + a.ObtenerTiempo();
        }



    }

    protected void BCrear_Click(object sender, EventArgs e)
    {
        string tipo = ""+IDLTipo.SelectedItem;
        int nivel = 0;
        if (tipo.Equals("Neosatelite"))
        {
            tipo = tipo + neosatelite;
            nivel = 3;
            ++neosatelite;
        }
        else if (tipo.Equals("Bombardero"))
        {
            tipo = tipo + bombardero;
            nivel = 2;
            ++bombardero;
        }
        else if (tipo.Equals("Caza"))
        {
            tipo = tipo + caza;
            nivel = 2;
            ++caza;
        }
        else if (tipo.Equals("Helicoptero"))
        {
            tipo = tipo + helicoptero;
            nivel = 2;
            ++helicoptero;
        }
        else if (tipo.Equals("Fragata"))
        {
            tipo = tipo + fragata;
            nivel = 1;
            ++fragata;
        }
        else if (tipo.Equals("Crucero"))
        {
            tipo = tipo + crucero;
            nivel = 1;
            ++crucero;
        }
        else if (tipo.Equals("Submarino"))
        {
            tipo = tipo + submarino;
            nivel = 0;
            ++submarino;
        }
        a.InsertarUnidadesMatriz("" + Session["usuario"], tipo, IFila.Text.Trim(), IColumna.Text.Trim(), 1, nivel);
        IColumna.Text = tipo;
        Response.Redirect("gestion-juegos.aspx");
    }

    
    

    protected void BSU_Click(object sender, EventArgs e)
    {
        if (FileUploadCSVUnidades.FileName != "")
        {

            string line;
            string dir = FileUploadCSVUnidades.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadCSVUnidades.PostedFile.InputStream;

            string jugador = "";
            string tipo = "";
            string columna = "";
            string fila = "";
            int nivel=0;
            Boolean pri = true;
            Byte estado = 0;
            

            string aux = "";


            //try
            {
                StreamReader file = new StreamReader(asd);



                while ((line = file.ReadLine()) != null)
                {
                    jugador = "";
                    tipo = "";
                    columna = "";
                    fila = "";
                    nivel = 0;
                    estado = 0;
                    if (pri == true)
                    {
                        pri = false;
                        continue;
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ',')
                        {

                            aux += line[i];
                        }
                        if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 0)
                        {
                            jugador = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            columna = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            fila = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            if (aux.Contains("Neosatelite"))
                            {
                                nivel = 3;
                            }
                            else if (aux.Contains("Bombardero"))
                            {
                                
                                nivel = 2;
                            }
                            else if (aux.Contains("Caza"))
                            {
                                
                                nivel = 2;
                            }
                            else if (aux.Contains("Helicoptero"))
                            {
                                
                                nivel = 2;
                            }
                            else if (aux.Contains("Fragata"))
                            {
                                
                                nivel = 1;
                            }
                            else if (aux.Contains("Crucero"))
                            {
                                
                                nivel = 1;
                            }
                            else if (aux.Contains("Submarino"))
                            {
                                
                                nivel = 0;
                            }
                            tipo = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 4)
                        {
                            estado = Convert.ToByte(aux);
                            aux = "";
                            posicion = 0;
                            
                        }


                    }


                    if (estado == 1)
                    {
                        a.InsertarUnidadesMatriz(jugador, tipo, (fila.Trim()), (columna.Trim()), estado, nivel);
                    }
                    else
                    {
                        a.InsertarUnidadesMatrizDestruido(jugador, tipo, (fila.Trim()), (columna.Trim()), estado, nivel);
                    }
                    
                
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }

        a.MostrarTableros("");
        //Response.Redirect("gestion-juegos.aspx");
    }

    protected void BSP_Click(object sender, EventArgs e)
    {
        if (FileUploadParametros.FileName != "")
        {

            string line;
            string dir = FileUploadParametros.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadParametros.PostedFile.InputStream;

            string nick1 = "";
            string nick2 = "";
            int Un0 = 0;
            int Un1 = 0;
            int Un2 = 0;
            int Un3 = 0;
            int tamx = 0;
            int tamy = 0;
            int tiempo = 0;
            Boolean pri = true;
            

            string aux = "";


            //try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(asd);



                while ((line = file.ReadLine()) != null)
                {
                    if (pri == true)
                    {
                        pri = false;
                        continue;
                    }
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ',')
                        {

                            aux += line[i];
                        }
                        if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 0)
                        {
                            nick1 = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            nick2 = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            Un0 = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            Un1 = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 4)
                        {
                            Un2 = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 5)
                        {
                            Un3 = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 6)
                        {
                            tamx = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 7)
                        {
                            tamy = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',' || line[i + 1] == ':') && posicion == 8)
                        {
                            tiempo = Convert.ToInt32(aux.Trim());
                            aux = "";
                            posicion = 0;
                        }

                    }

                    a.ConfigurarParametros(Un0, Un1, Un2, Un3, tiempo, tamx, tamy);
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }
        Response.Redirect("gestion-juegos.aspx");
    }

    

    protected void Bbuscar_Click(object sender, EventArgs e)
    {

        a.MostrarTableros("");

    }

    protected void BEliminar_Click(object sender, EventArgs e)
    {
        string tipo = (""+DLElimiar.SelectedItem).Trim();
        int nivel = 0;
        if (tipo.Equals("Neosatelite"))
        {
            
            nivel = 3;
            
        }
        else if (tipo.Equals("Bombardero"))
        {
            
            nivel = 2;
            
        }
        else if (tipo.Equals("Caza"))
        {
            
            nivel = 2;
            
        }
        else if (tipo.Equals("Helicoptero"))
        {
            
            nivel = 2;
            
        }
        else if (tipo.Equals("Fragata"))
        {
            
            nivel = 1;
            
        }
        else if (tipo.Equals("Crucero"))
        {
            
            nivel = 1;
            
        }
        else if (tipo.Equals("Submarino"))
        {
            
            nivel = 0;
            
        }
        a.EliminarUnidades(EUFila.Text, EUColumna.Text, nivel);
        Response.Redirect("gestion-juegos.aspx");

    }

    protected void BModificarP_Click(object sender, EventArgs e)
    {
        string un0 = IUN0.Text;
        string un1 = IUN1.Text;
        string un2 = IUN2.Text;
        string un3 = IUN3.Text;
        string cf = ICF.Text;
        string cc = ICC.Text;
        string tiem = ITJ.Text;

        int u0 = 0;
        int u1 = 0;
        int u2 = 0;
        int u3 = 0;
        int tf = 0;
        int tc = 0;
        int tt = 0;
        
        if (un0 != "")
        {
            u0 = Convert.ToInt32(un0);
        }
        else
        {
            u0 = -1;
        }

        if (un1 != "")
        {
            u1 = Convert.ToInt32(un1);
        }
        else
        {
            u1 = -1;
        }
        if (un2 != "")
        {
            u2 = Convert.ToInt32(un2);
        }
        else
        {
            u2 = -1;
        }
        if (un3 != "")
        {
            u3 = Convert.ToInt32(un3);
        }
        else
        {
            u3 = -1;
        }
        if (cf != "")
        {
            tf = Convert.ToInt32(cf);
        }
        else
        {
            tf = -1;
        }
        if (cc != "")
        {
            tc = Convert.ToInt32(cc);
        }
        else
        {
            tc = -1;
        }
        if (tiem != "")
        {
            tt = Convert.ToInt32(tiem);
        }
        else
        {
            tt = -1;
        }

        a.ConfigurarParametros(u0, u1, u2, u3, tt, tf, tc);
        Response.Redirect("gestion-juegos.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }
}
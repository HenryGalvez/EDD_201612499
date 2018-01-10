using System;
using System.IO;


public partial class gestion_usuario : System.Web.UI.Page
{
    ServiceNavalWars.ServiceSoapClient a = new ServiceNavalWars.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            a.Mostrar();
            
        }
        
        

    }

    protected void BCrear_Click(object sender, EventArgs e)
    {
        a.Agregar(INick.Text,IPass.Text,ICorreo.Text,0);
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BCrearContacto_Click(object sender, EventArgs e)
    {
        
        a.InsertarContacto(ICUsuarioP.Text,ICNick.Text, ICPass.Text, ICCorreo.Text);
        
        Response.Redirect("gestion-usuario.aspx");
    }
    static Boolean most = false;
    static int count = 0;
    protected void BMCAvl_Click(object sender, EventArgs e)
    {

        a.MostrarAvl(MCUsuarioP.Text);
        most = true;
        //Response.Redirect("gestion-usuario.aspx");
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (most == true && count >= 2)
        {
            try
            {
                //Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\avl\grafoavl.jpg");
                //string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
                Avl.ImageUrl = a.RetornarCandena("C:\\EDD\\avl\\grafoavl.jpg");
                most = false;
            }
            catch (Exception re)
            {

            }
        }
        else if(most == true && count <3)
        {
            count++;
        }
        
    }

    protected void BImportar_Click(object sender, EventArgs e)
    {
        a.ImportarUsuariosHash();
        a.MostrarTablaHash();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BIjuegos_Click(object sender, EventArgs e)
    {
        a.AgregarJuego(INickBase.Text, INickOponente.Text, Convert.ToInt32(IUD.Text), Convert.ToInt32(IUS.Text), Convert.ToInt32(IUDes.Text),Convert.ToByte(IG.Text),0);
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");

    }


    protected void BSContactos_Click(object sender, EventArgs e)
    {
        if (FileUploadCSVContactos.FileName != "")
        {

            string line;
            string dir = FileUploadCSVContactos.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadCSVContactos.PostedFile.InputStream;

            string nickp = "";
            string nick = "";
            string pass = "";
            string correo = "";
            
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
                            nickp = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            nick = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            pass = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            correo = aux;
                            aux = "";
                            posicion = 0;
                        }
                        


                    }

                    a.InsertarContacto(nickp,nick, pass, correo);
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }
        
        Response.Redirect("gestion-usuario.aspx");
    }



    protected void BSU_Click(object sender, EventArgs e)
    {
        if (FileUploadCSVUsuarios.FileName != "")
        {

            string line;
            string dir = FileUploadCSVUsuarios.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadCSVUsuarios.PostedFile.InputStream;

            string nick = "";
            string pass = "";
            string correo = "";
            Byte estado = 0;
            Boolean pri = true;
            string aux="";
            

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
                            nick = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            pass = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            correo = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            estado = Convert.ToByte(aux);
                            aux = "";
                            posicion = 0;
                        }
                        

                    }
                    
                    a.Agregar(nick, pass, correo, estado);
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BSH_Click(object sender, EventArgs e)
    {
        if (FileUploadArbolB.FileName != "")
        {

            string line;
            string dir = FileUploadArbolB.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadArbolB.PostedFile.InputStream;

             int ataque = 1;
            
             string fila ="";
             string columna ="";
             string unidadAtacante ="";
             int resultado = 0; ;
             string unidadAtacada = "";
             string emisor = "";
             string receptor ="";
             string fecha =  "";
             string tiempoR = "";
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
                            columna = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            fila = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            unidadAtacante = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            resultado = Convert.ToInt32(aux);
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 4)
                        {
                            unidadAtacada = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 5)
                        {
                            emisor = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 6)
                        {
                            receptor = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 7)
                        {
                            fecha = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 8)
                        {
                            tiempoR = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 9)
                        {
                            ataque = Convert.ToInt32(aux);
                            aux = "";
                            posicion = 0;
                        }


                    }

                    a.InsertarArbolB(ataque, fila, columna, unidadAtacante, resultado, unidadAtacada, emisor, receptor, fecha, tiempoR);
                    a.MostrarArbolB();
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }


    protected void BSJ_Click(object sender, EventArgs e)
    {
        if (FileUploadCSVJuegos.FileName != "")
        {

            string line;
            string dir = FileUploadCSVJuegos.PostedFile.FileName;

            int posicion = 0;

            Stream asd = FileUploadCSVJuegos.PostedFile.InputStream;

            string nickBase = "";
            string nickOponente = "";
            int UDesplegadas=0;
            int USobre=0;
            int UDestru=0;
            Byte gano = 0;
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
                            nickBase = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 1)
                        {
                            nickOponente = aux;
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 2)
                        {
                            UDesplegadas = Convert.ToInt32(aux);
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 3)
                        {
                            USobre = Convert.ToInt32(aux);
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 4)
                        {
                            UDestru = Convert.ToInt32(aux);
                            aux = "";
                            posicion++;
                        }
                        else if ((i + 1 == line.Length || line[i + 1] == ',') && posicion == 5)
                        {
                            gano = Convert.ToByte(aux);
                            aux = "";
                            posicion = 0;
                        }

                    }

                    a.AgregarJuego(nickBase,nickOponente,UDesplegadas,USobre,UDestru,gano,0);
                }

                file.Close();
            }
            //catch (Exception weq)
            {
                //Console.WriteLine("" + weq);
            }
        }
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void Bbuscar_Click(object sender, EventArgs e)
    {
        string line ="";
        
        int posicion =0;
        if (TxtBuscar.Text != "")
        {
            line = a.MostrarDatosUsuario(TxtBuscar.Text);
            StringReader f = new StringReader(line);
            while ((line = f.ReadLine()) != null)
            {
                if (posicion == 0)
                {
                    Mnick.Text = line;

                    posicion++;
                }
                else if (posicion == 1)
                {
                    Mpass.Text = line;
                    

                    posicion++;
                }
                else if (posicion == 2)
                {
                    Mcorreo.Text = line;

                    posicion++;
                }
                else if (posicion == 3)
                {
                    Estado.Text = line;

                    posicion = 0;
                }
            }
        }
        //a.Mostrar();
        
    }

    protected void BEliminar_Click(object sender, EventArgs e)
    {
        if (TxtBuscar.Text != "")
        {
            a.EliminarUsuario(TxtBuscar.Text);
        }
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BBContacto_Click(object sender, EventArgs e)
    {
        string line = "";

        int posicion = 0;
        if (TBContactoB.Text != "")
        {
            line = a.RetornarDatosContacto(TBContactoB.Text,TBContactoM.Text);
            StringReader f = new StringReader(line);
            while ((line = f.ReadLine()) != null)
            {
                if (posicion == 0)
                {
                    ICNick.Text = line;

                    posicion++;
                }
                else if (posicion == 1)
                {
                    ICPass.Text = line;


                    posicion++;
                }
                else if (posicion == 2)
                {
                    ICCorreo.Text = line;

                    posicion = 0;
                }
                
            }
        }
        
    }

    protected void BEContacto_Click(object sender, EventArgs e)
    {
        a.EliminarAvl(TBContactoB.Text, TBContactoM.Text);
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BMContacto_Click(object sender, EventArgs e)
    {
        a.ModificarAvl(TBContactoB.Text, TBContactoM.Text, ICNick.Text, ICPass.Text, ICCorreo.Text);
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void BModificar_Click(object sender, EventArgs e)
    {


        a.Modificar(TxtBuscar.Text, Mnick.Text, Mpass.Text, Mcorreo.Text,Convert.ToByte(Estado.Text));
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");

    }

    protected void BMjuegos_Click(object sender, EventArgs e)
    {
        int desple = -1;
        int sobre = -1;
        int destru = -1;
        
        if (MLJUdesplegadas.Text != "")
        {
            desple = Convert.ToInt32(MLJUdesplegadas.Text);
        }

        if (MLJUSobre.Text != "")
        {
            sobre = Convert.ToInt32(MLJUSobre.Text);

        }

        if (MLJUdestru.Text != "")
        {
            destru = Convert.ToInt32(MLJUdestru.Text);
        }
        a.ModificarListaJuegos(MLJUsuario.Text, Convert.ToInt32(MLJId.Text)
            , MLJNickOponente.Text, desple, sobre, destru, Convert.ToByte(MLJGano.Text));
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }
    protected void BEjuegos_Click(object sender, EventArgs e)
    {
        a.EliminarListaJuegos(MLJUsuario.Text, Convert.ToInt32(MLJId.Text));
        a.Mostrar();
        Response.Redirect("gestion-usuario.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }
}
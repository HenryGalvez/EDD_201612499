using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static int neosatelite = 1;
    static int bombardero = 1;
    static int caza = 1;
    static int helicoptero = 1;
    static int fragata = 1;
    static int crucero = 1;
    static int submarino = 1;
    static int Un0 = 1;
    static int Un1 = 1;
    static int Un2 = 1;
    static int Un3 = 1;

    static int uni0 = 1;
    static int uni1 = 1;
    static int uni2 = 1;
    static int uni3 = 1;

    static int Tamy = 1;
    static int Tamx = 1;
    static int player = 0;
    static Boolean primer = false;


    ServiceNavalWars.ServiceSoapClient a = new ServiceNavalWars.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            
        }
    }

    protected void BCrear_Click(object sender, EventArgs e)
    {
        string tipo = "" + IDLTipo.SelectedValue;
        int nivel = 0;
        if (tipo.Equals("Neosatelite") )
        {
            tipo = tipo + neosatelite;
            nivel = 3;
            ++neosatelite;
            ++uni3;
        }
        else if (tipo.Equals("Bombardero") )
        {
            tipo = tipo + bombardero;
            nivel = 2;
            ++bombardero;
            ++uni2;
        }
        else if (tipo.Equals("Caza") )
        {
            tipo = tipo + caza;
            nivel = 2;
            ++caza;
            ++uni2;
        }
        else if (tipo.Equals("Helicoptero") )
        {
            tipo = tipo + helicoptero;
            nivel = 2;
            ++helicoptero;
            ++uni2;
        }
        else if (tipo.Equals("Fragata") )
        {
            tipo = tipo + fragata;
            nivel = 1;
            ++fragata;
            ++uni1;
        }
        else if (tipo.Equals("Crucero") )
        {
            tipo = tipo + crucero;
            nivel = 1;
            ++crucero;
            ++uni1;
        }
        else if (tipo.Equals("Submarino") )
        {
            tipo = tipo + submarino;
            nivel = 0;
            ++submarino;
            ++uni0;
        }

        if (uni0 > Un0 || uni1 > Un1 || uni2 > Un2 || uni3 > Un3)
        {
            nivel = -1;
        }

        if (nivel != -1)
        {
            a.InsertarUnidadesMatriz("" + Session["usuario"], tipo, IFila.Text.Trim(), IColumna.Text.Trim(), 1, nivel);
        }
        
        


    }
    protected void BIniciar_Click(object sender, EventArgs e)
    {

        Un0 = Convert.ToInt32(a.ObtenerUnivel0());
        Un1 = Convert.ToInt32(a.ObtenerUnivel1());
        Un2 = Convert.ToInt32(a.ObtenerUnivel2());
        Un3 = Convert.ToInt32(a.ObtenerUnivel3());
        Tamx = Convert.ToInt32(a.ObtenerTamX());
        Tamy = Convert.ToInt32(a.ObtenerTamY());
        player = a.ConfigurarJugadores("" + Session["usuario"]);
    }

    protected void BComenzar_Click(object sender, EventArgs e)
    {

        a.SetReady("" + Session["usuario"]);
        primer = false;
    }

    protected void BBuscar_Click(object sender, EventArgs e)
    {


    }
    protected void BModificarU_Click(object sender, EventArgs e)
    {


    }

    protected void BEliminar_Click(object sender, EventArgs e)
    {
        string tipo = ("" + DLEliminar.SelectedItem).Trim();
        int nivel = 0;
        if (tipo.Equals("Neosatelite"))
        {

            nivel = 3;
            --uni3;
        }
        else if (tipo.Equals("Bombardero"))
        {

            nivel = 2;
            --uni2;
        }
        else if (tipo.Equals("Caza"))
        {

            nivel = 2;
            --uni2;
        }
        else if (tipo.Equals("Helicoptero"))
        {

            nivel = 2;
            --uni2;
        }
        else if (tipo.Equals("Fragata"))
        {

            nivel = 1;
            --uni1;
        }
        else if (tipo.Equals("Crucero"))
        {

            nivel = 1;
            --uni1;
        }
        else if (tipo.Equals("Submarino"))
        {

            nivel = 0;
            --uni0;
        }
        a.EliminarUnidades(EUFila.Text, EUColumna.Text, nivel);
        primer = false;
        Response.Redirect("gestion-juegos.aspx");

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (a.ComenzarJuego() == true)
        {
            string em = "" + Session["usuario"];
            if (primer == false )
            {
                a.MostrarTableros(em);
                primer = true;
            }
            ++player;
            if (player == 5)
            {
                primer = false;
            }
            
            
            //Response.Redirect("cliente-juegos.aspx");
            //if (primer == false)
            {
                try
                {
                    Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel0" + em + ".jpg");
                    TAN1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims);
                    Byte[] ims1 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel1" + em + ".jpg");
                    TAN2.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims1);
                    Byte[] ims2 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel2" + em + ".jpg");
                    TAN3.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims2);
                    Byte[] ims3 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel3" + em + ".jpg");
                    TAN4.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims3);
                    
                }
                catch (Exception m)
                {

                }
                

            }
        }
    }

    public string Matriz(string nombre)
    {

        {
            Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\" + nombre + ".jpg");
            string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
            return imgbase;
        }



    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }
}
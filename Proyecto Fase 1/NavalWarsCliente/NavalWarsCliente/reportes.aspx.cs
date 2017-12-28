using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;

public partial class reportes : System.Web.UI.Page
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
            ArbolBinarioEspejo();
            ArbolBinarioNormal();

            a.MostrarTableros();

            labelHojas.Text = "Numero de Hojas:   " + a.NodosHojas();
            labelRamas.Text = "Numero de Nodos Ramas:   " + a.NodosRama();
            labelAltura.Text ="La Altura es:   " + a.Altura();
            labelTop10Usuarios.Text = "Top 10 Usuarios Con Mas Juegos Ganados"+Environment.NewLine+ a.Top10Usuarios();
            labelTop10Porcentaje.Text = "Top 10 con Mayor Porcentaje de Unidades Destruidas"+Environment.NewLine+ a.Top10Porcentaje();
            

            TAN1.ImageUrl = Matriz("matrizNivel0");
            TAN2.ImageUrl = Matriz("matrizNivel1");
            TAN3.ImageUrl = Matriz("matrizNivel2");
            TAN4.ImageUrl = Matriz("matrizNivel3");

            TDN1.ImageUrl = Matriz("matrizNivel0Destruidas");
            TDN2.ImageUrl = Matriz("matrizNivel1Destruidas");
            TDN3.ImageUrl = Matriz("matrizNivel2Destruidas");
            TDN4.ImageUrl = Matriz("matrizNivel3Destruidas");

        }
    }
    public void ArbolBinarioNormal()
    {
        Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\grafo.jpg");
        string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
        binario.ImageUrl = imgbase;

    }

    public void ArbolBinarioEspejo()
    {
        Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\grafoespejo.jpg");
        string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
        binarioespejo.ImageUrl = imgbase;

    }

    public string Matriz(string nombre)
    {
        Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\"+nombre+".jpg");
        string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
        return imgbase;

    }


    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }
}
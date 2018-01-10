using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void log_Click(object sender, EventArgs e)
    {
        string nom = nick.Text;
        string con = pass.Text;

        if (nom.Equals(""))
        {
            errorCorreo.Text = "   El Correo es un campo Obligatorio";

        }
        else if (con.Equals(""))
        {
            errorContraseña.Text = "  La Contraseña es un campo Obligatorio";

        }
        else if (nick.Text != "" && pass.Text != "")
        {
            ServiceNavalWars.ServiceSoapClient servicio = new ServiceNavalWars.ServiceSoapClient();

            if (servicio.LoginAdmin(nom, con))
            {
                Session.Add("usuario", nom);
                Response.Redirect("gestion-usuario.aspx");
            }
            else
            {
                string aux = servicio.MostrarDatosUsuario(nom);
                if (aux != "")
                {
                    Session.Add("usuario", nom);
                    Response.Redirect("cliente-juegos.aspx");
                }
            }


        }
    }
}
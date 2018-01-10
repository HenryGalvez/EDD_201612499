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
    static int modo = 0;
    static int player = 0;
    static int tiempo=0;

    static int uT = 0;
    static int uS = 0;
    static int uD = 0;
    static Boolean win = false;
    

    static Boolean estacion = false,temporizador = false,normal = false;
    


    ServiceNavalWars.ServiceSoapClient a = new ServiceNavalWars.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            user.Text = "" + Session["usuario"];
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
        else if (tipo.Equals("Base"))
        {
            
            nivel = 1;
            IDLTipo.Items.Remove("Base");
        }

        if (uni0 > Un0 || uni1 > Un1 || uni2 > Un2 || uni3 > Un3)
        {
            nivel = -1;
        }

        if (nivel != -1)
        {
            int s = a.InsertarUnidadesMatriz("" + Session["usuario"], tipo, IFila.SelectedValue.Trim(), IColumna.SelectedValue.Trim(), 1, nivel);
            ++uT;
            if (s == -1)
            {
                labelMsjC.Text = "*******Coordenada Con Obstaculo";
            }
            else if (s == 0)
            {
                labelMsjC.Text = "*******Unidad Ingresada Con Exito";
            }
            else if (s == 1)
            {
                labelMsjC.Text = "*******Limite de Unidad Alcanzado";
            }

            DLMove.Items.Add(tipo);
            DLEliminar.Items.Add(tipo);
            DLAtacar.Items.Add(tipo);
        }

        a.MostrarTableros("" + Session["usuario"]);


    }
    protected void BIniciar_Click(object sender, EventArgs e)
    {

        Un0 = Convert.ToInt32(a.ObtenerUnivel0());
        Un1 = Convert.ToInt32(a.ObtenerUnivel1());
        Un2 = Convert.ToInt32(a.ObtenerUnivel2());
        Un3 = Convert.ToInt32(a.ObtenerUnivel3());
        Tamx = Convert.ToInt32(a.ObtenerTamX());
        Tamy = Convert.ToInt32(a.ObtenerTamY());
        tiempo = Convert.ToInt32(a.ObtenerTiempo());
        modo = a.ObtenerModo();
        if (modo == 1)
        {
            normal = true;
        }
        else if (modo == 3)
        {
            estacion = true;
            IDLTipo.Items.Add("Base");
        }
        else if(modo == 2)
        {
            temporizador = true; 
            
        }
        player = a.ConfigurarJugadores("" + Session["usuario"]);
        BCrear.Enabled = true;
        Comenzar.Enabled = true;
        Iniciar.Enabled = false;
        int inicio = 65, final = Tamy+65;
        string cadena = "A";
        int primerContador = 65;
        int segundoContador = 65;
        int t = 0;

        string cad2 = "";
        

        for (int j = inicio; j < final; j++)
        {
            
            if (j >= 91)
            {


                if (player == 1 && t <= (Tamy / 2))
                {
                    IColumna.Items.Add(cadena + Convert.ToChar(segundoContador));
                    EUColumna.Items.Add(cadena + Convert.ToChar(segundoContador));
                }
                else if(player == 2 && t > (Tamy/2))
                {
                    IColumna.Items.Add(cadena + Convert.ToChar(segundoContador));
                    EUColumna.Items.Add(cadena + Convert.ToChar(segundoContador));
                }
                segundoContador++;
                if (segundoContador >= 91)
                {
                    cad2 = "";
                    segundoContador = 65;
                    primerContador++;
                    for (int d = 0; d < cadena.Length - 1; d++)
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
                if (player == 1 && t <= (Tamy / 2))
                {
                    IColumna.Items.Add(""+Convert.ToChar(j));
                    EUColumna.Items.Add("" + Convert.ToChar(j));
                }
                else if (player == 2 && t > (Tamy / 2))
                {
                    IColumna.Items.Add(""+Convert.ToChar(j));
                    EUColumna.Items.Add("" + Convert.ToChar(j));
                }

            }
            t++;
        }

        for (int i = 1; i <= Tamx; i++)
        {
            IFila.Items.Add("" + i);
            EUFila.Items.Add("" + i);
        }
    }

    protected void BComenzar_Click(object sender, EventArgs e)
    {

        a.SetReady("" + Session["usuario"]);
        a.setActualizar(true);
        BCrear.Enabled = false;
        BtnEliminarU.Enabled = false;
        //BMover.Enabled = true;
        //BAtacar.Enabled = true;
        //BFinalizar.Enabled = true;
        Comenzar.Enabled = false;
        //ac = true;
        uS = uT;
        int inicio = 65, final = Tamy + 65;
        string cadena = "A";
        int primerContador = 65;
        int segundoContador = 65;
        int t = 0;

        string cad2 = "";


        for (int j = inicio; j < final; j++)
        {

            if (j >= 91)
            {


                
                IColNue.Items.Add(cadena + Convert.ToChar(segundoContador));
                IColA.Items.Add(cadena + Convert.ToChar(segundoContador));
                segundoContador++;
                if (segundoContador >= 91)
                {
                    cad2 = "";
                    segundoContador = 65;
                    primerContador++;
                    for (int d = 0; d < cadena.Length - 1; d++)
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
                
                IColNue.Items.Add("" + Convert.ToChar(j));
                IColA.Items.Add("" + Convert.ToChar(j));


            }
            t++;
        }

        for (int i = 1; i <= Tamx; i++)
        {
            IFilNue.Items.Add("" + i);
            IFilAm.Items.Add("" + i);
        }

        a.MostrarTableros("" + Session["usuario"]);
    }

    protected void BBuscar_Click(object sender, EventArgs e)
    {


    }
    protected void BModificarU_Click(object sender, EventArgs e)
    {


    }

    protected void BMover_Click(object sender, EventArgs e)
    {

        string tipo = DLMove.SelectedValue;
        int nivel = -1;
        if (tipo.Contains("Neosatelite"))
        {

            nivel = 3;

        }
        else if (tipo.Contains("Bombardero"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Caza"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Helicoptero"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Fragata"))
        {

            nivel = 1;

        }
        else if (tipo.Contains("Crucero"))
        {

            nivel = 1;

        }
        else if (tipo.Contains("Submarino"))
        {

            nivel = 0;

        }
        int s = a.Mover(nivel, DLMove.SelectedValue, "", "", IFilNue.Text, IColNue.Text);
        if (s == -1)
        {
            labelMsj.Text = " *********Unidad No Valida";
            DLAtacar.Items.Remove(DLMove.SelectedValue);
            DLMove.Items.Remove(DLMove.SelectedValue);
            --uS;
        }
        else if (s == 0)
        {
            labelMsj.Text = " *********Unidad Insertada con Exito";
            a.MansarMensaje("usuario: " + Session["usuario"] + " Movio a la la Posicion (" + IFilNue.Text + "," + IColNue.Text +","+nivel+ ")" +
                " Exitosamente una Unidad "+ DLMove.SelectedValue + Environment.NewLine + labelConsola.Text);


        }
        else if (s == 1)
        {
            labelMsj.Text = " *********Movimiento No valido Posicion Con Obstaculo";
        }
        if (a.EsBase(IFilNue.Text, IColNue.Text))
        {
            BMover.Enabled = false;
            BAtacar.Enabled = false;
            BFinalizar.Enabled = false;
            a.setFinalizar(true);
            a.MansarMensaje("usuario: " + Session["usuario"] + " Movio a la la Posicion (" + IFilNue.Text + "," + IColNue.Text + "," + nivel + ")" +
                " Capturo la Base Enemiga " + Environment.NewLine + labelConsola.Text);
            a.setMsjFinal("El Usuario " + Session["usuario"] + " Capturo la Bandera Enemiga" + Environment.NewLine + "PARTIDA TERMINADA");
            win = true;
        }


        a.MostrarTableros("" + Session["usuario"]);
    }

    protected void BFinalizar_Click(object sender, EventArgs e)
    {
        a.MostrarTableros("" + Session["usuario"]);
        a.FinTurno(player);
        a.setActualizar(true);
        //BMover.Enabled = false;
        //BAtacar.Enabled = false;
        //BFinalizar.Enabled = false;
    }

    protected void BAtacar_Click(object sender, EventArgs e)
    {

        string tipo = DLAtacar.SelectedValue;
        int nivel = -1;
        if (tipo.Contains("Neosatelite"))
        {

            nivel = 3;

        }
        else if (tipo.Contains("Bombardero"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Caza"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Helicoptero"))
        {

            nivel = 2;

        }
        else if (tipo.Contains("Fragata"))
        {

            nivel = 1;

        }
        else if (tipo.Contains("Crucero"))
        {

            nivel = 1;

        }
        else if (tipo.Contains("Submarino"))
        {

            nivel = 0;

        }
        int resultado = 0;
        if (DLNivel.SelectedIndex == 1 && a.EsBase(IFilAm.SelectedValue, IColA.SelectedValue) == true)
        {
            BMover.Enabled = false;
            BAtacar.Enabled = false;
            BFinalizar.Enabled = false;
            a.setFinalizar(true);
            a.MansarMensaje("usuario: " + Session["usuario"] + " Ataco a la la Posicion (" + IFilAm.SelectedValue + "," + IColA.SelectedValue + "," + nivel + ")" +
                " Capturo la Base Enemiga " + Environment.NewLine + labelConsola.Text);
            a.setMsjFinal("El Usuario " + Session["usuario"] + " Capturo la Bandera Enemiga" + Environment.NewLine + "PARTIDA TERMINADA");
        }
        else
        {
            int s = a.Atacar(nivel, DLAtacar.SelectedValue, IFilAm.SelectedValue, IColA.SelectedValue, DLNivel.SelectedIndex);
            if (s == -1)
            {
                labelMsjA.Text = " *********Unidad No Valida";

            }
            else if (s == 0)
            {
                labelMsjA.Text = " *********Disparo acertado";
                resultado = 0;
            }
            else if (s == 1)
            {
                labelMsjA.Text = " *********Disparo sin Exito";
                
            } else if (s == 3)
            {
                labelMsjA.Text = " *********Disparo con Exito Unidad destruida";
                resultado = 1;
                ++uD;
            }
            try
            {
                a.InsertarArbolB(a.getAtaque(), IFilAm.SelectedValue, IColA.SelectedValue, DLAtacar.SelectedValue, resultado, a.unidadAtacada(), "" + Session["usuario"], a.Receptor(player), DateTime.Now.ToString(), labelTiempo.Text);
                a.MostrarArbolB();
            }
            catch (Exception ed)
            {

            }
            
        }
        
        

        a.MostrarTableros("" + Session["usuario"]);
    }

    protected void BEliminar_Click(object sender, EventArgs e)
    {
        string tipo = ("" + DLEliminar.SelectedItem).Trim();
        int nivel = 0;
        if (tipo.Contains("Neosatelite"))
        {

            nivel = 3;
            --uni3;
        }
        else if (tipo.Contains("Bombardero"))
        {

            nivel = 2;
            --uni2;
        }
        else if (tipo.Contains("Caza"))
        {

            nivel = 2;
            --uni2;
        }
        else if (tipo.Contains("Helicoptero"))
        {

            nivel = 2;

            --uni2;
        }
        else if (tipo.Contains("Fragata"))
        {

            nivel = 1;
            --uni1;
        }
        else if (tipo.Contains("Crucero"))
        {

            nivel = 1;
            --uni1;
        }
        else if (tipo.Contains("Submarino"))
        {

            nivel = 0;
            --uni0;
        }
        a.EliminarUnidades(DLEliminar.SelectedValue, nivel);
        --uT;
        //a.setActualizar(true);
        DLMove.Items.Remove(tipo);
        DLEliminar.Items.Remove(tipo);
        DLAtacar.Items.Remove(tipo);
        //a.MostrarTableros("" + Session["usuario"]);
        //Response.Redirect("gestion-juegos.aspx");
        a.MostrarTableros("" + Session["usuario"]);
    }
    static int segundos = 0;
    static Boolean de = false;
    static Boolean finPri = false;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        a.VerificarUnidades();
        if (a.Turno() == player)
        {
            BMover.Enabled = true;
            BAtacar.Enabled = true;
            BFinalizar.Enabled = true;
        }
        labelConsola.Text = a.ObtenerMensaje();
        if (temporizador == true && a.ComenzarJuego() == true && a.getFinalizar() == false)
        {
            if (de == false)
            {
                if (a.ComenzarJuego() == true)
                {
                    de = true;
                }
            }
            else
            {
                if (segundos > 9)
                {

                    --segundos;
                }
                else if (segundos > 0 && segundos < 10)
                {

                    --segundos;
                }
                else if (segundos == 0 && tiempo != 0)
                {

                    segundos = 60;
                    --tiempo;
                }
                if (segundos > 9)
                {
                    labelTiempo.Text = "Tiempo Restante: " + tiempo + ":" + segundos;
                }
                else
                {
                    labelTiempo.Text = "Tiempo Restante: " + tiempo + ":0" + segundos;
                }
            }

            if (segundos == 0 && tiempo == 0)
            {
                a.setFinalizar(true);
                a.VerificarUnidades();
                a.VerificarEmpate();
                BMover.Enabled = false;
                BAtacar.Enabled = false;
                BFinalizar.Enabled = false;
                a.setFinalizar(true);
                a.MansarMensaje("Partida Finalizada Tiempo Terminado" + Environment.NewLine + labelConsola.Text);
                a.setMsjFinal("El Tiempo Se Acabo " + Environment.NewLine + "PARTIDA TERMINADA");

            }
        }

        if (a.getFinalizar() == true)
        {
            BMover.Enabled = false;
            BAtacar.Enabled = false;
            BFinalizar.Enabled = false;
            if (finPri == false && a.getWin() == player)
            {
                a.AgregarJuego("" + Session["usuario"], a.Receptor(player), uT, uS, (uT - uS), 1, a.getAtaque());
                finPri = true;
            }
            else if (finPri == false && a.getWin() != player)
            {
                a.AgregarJuego("" + Session["usuario"], a.Receptor(player), uT, uS, (uT - uS), 0, a.getAtaque());
                finPri = true;
            }
            

        }

                
        labelMensajeFinal.Text = a.getMsjFinal();

        string em = "" + Session["usuario"];
        try
        {
            //Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel0" + em + ".jpg");
            //TAN1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims);
            //Byte[] ims1 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel1" + em + ".jpg");
            //TAN2.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims1);
            //Byte[] ims2 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel2" + em + ".jpg");
            //TAN3.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims2);
            //Byte[] ims3 = System.IO.File.ReadAllBytes(@"C:\EDD\" + "matrizNivel3" + em + ".jpg");
            //TAN4.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ims3);

            TAN1.ImageUrl = a.RetornarCandena("C:\\EDD\\" + "matrizNivel0" + em + ".jpg");
            TAN2.ImageUrl = a.RetornarCandena("C:\\EDD\\" + "matrizNivel1" + em + ".jpg");
            TAN3.ImageUrl = a.RetornarCandena("C:\\EDD\\" + "matrizNivel2" + em + ".jpg");
            TAN4.ImageUrl = a.RetornarCandena("C:\\EDD\\" + "matrizNivel3" + em + ".jpg");



        }
        catch (Exception m)
        {

        }
        a.setActualizar(false);
    }

    public string Matriz(string nombre)
    {

        {
            //Byte[] ims = System.IO.File.ReadAllBytes(@"C:\EDD\" + nombre + ".jpg");
            //string imgbase = "data:image/jpg;base64," + Convert.ToBase64String(ims);
            return a.RetornarCandena("C:\\EDD\\" + nombre + ".jpg");
        }



    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }
}
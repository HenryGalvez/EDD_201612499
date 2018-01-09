<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportes.aspx.cs" Inherits="reportes" %>

<!DOCTYPE html>

<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>NavalWars</title>
  <!-- Bootstrap core CSS-->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">
</head>

<body class="fixed-nav sticky-footer bg-dark" id="page-top">
  
    <!-- Navigation-->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
    <asp:HyperLink ID="recuperarpass" runat="server" class="navbar-brand" NavigateUrl="inicio.aspx" >NavalWars</asp:HyperLink>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
      <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="gest" visible ="false">
            <asp:HyperLink ID="gestionU" runat="server" class="nav-link" NavigateUrl="gestion-usuario.aspx" >
          
            <i class="fa fa-fw fa-gear"></i>
            <span class="nav-link-text">Gestionar Usuarios</span>
          </asp:HyperLink>
        </li>
          <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
            <asp:HyperLink ID="HyperLink1" runat="server" class="nav-link" NavigateUrl="gestion-juegos.aspx" >
          
            <i class="fa fa-fw fa-gear"></i>
            <span class="nav-link-text">Gestionar Juegos</span>
          </asp:HyperLink>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
            <asp:HyperLink ID="repo" runat="server" class="nav-link" NavigateUrl="reportes.aspx" >
          
            <i class="fa fa-fw fa-gear"></i>
            <span class="nav-link-text">Reportes</span>
          </asp:HyperLink>
        </li>
        
      </ul>
      <ul class="navbar-nav sidenav-toggler">
        <li class="nav-item">
          <a class="nav-link text-center" id="sidenavToggler">
            <i class="fa fa-fw fa-angle-left"></i>
          </a>
        </li>
      </ul>
      <ul class="navbar-nav ml-auto">
        
		<li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle mr-lg-2" id="opcionesUsuario" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <i class="fa fa-fw fa-bell"></i>
            <span class="d-lg-none">Alerts
              <span class="badge badge-pill badge-warning">6 New</span>
            </span>
            
          </a>
          <div class="dropdown-menu" aria-labelledby="alertsDropdown">
            <h6 class="dropdown-header">Cuenta:</h6>
            
            <div class="dropdown-divider"></div>
            <a class="dropdown-item"  data-toggle="modal" data-target="#exampleModal">
              <span class="text-success">
                <strong>
                  <i class="fa fa-sign-out fa-fw"></i>Logout</strong>
              </span>
              
            </a>
            
          </div>
        </li>
		
		
        <li class="nav-item">
          <form class="form-inline my-2 my-lg-0 mr-lg-2">
            <div class="input-group">
              <input class="form-control" type="text" placeholder="Buscar...">
              <span class="input-group-btn">
                <button class="btn btn-primary" type="button">
                  <i class="fa fa-search"></i>
                </button>
              </span>
            </div>
          </form>
        </li>
        
		
      </ul>
    </div>
  </nav>
  <form id="formr" runat="server">
    <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="#">Cuenta</a>
        </li>
        <li class="breadcrumb-item active">Configuraciones</li>
          <li></li>
      </ol>
     

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="10000">
            </asp:Timer>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>


        <!--mostrar binario-->
        <div class="card mb-3" runat="server" id="mostrar" >
        <div class="card-header">
          <i class="fa fa-table"></i>Arbol Binario de Busqueda</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <asp:Image ID="binario" runat="server" width="1000" />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>


        <!--mostrar binarioEspejo-->
        <div class="card mb-3" runat="server" id="Div1" >
        <div class="card-header">
          <i class="fa fa-table"></i> Arbol Binario Espejo</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <asp:Image ID="binarioespejo" runat="server" width="1000" />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>

        <!--mostrar Tabla Hash-->
        <div class="card mb-3" runat="server" id="Div5" >
        <div class="card-header">
          <i class="fa fa-table"></i> Arbol Binario Espejo</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <asp:Image ID="tablaHash" runat="server" width="300" Height="1000" />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>



        <!--mostrar numeros hojas-->
        <div class="card mb-3" runat="server" id="Div2" >
        <div class="card-header">
          <i class="fa fa-table"></i> Arbol Binario Espejo</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <asp:Label ID="labelHojas" runat="server" />
              <br />
              <asp:Label ID="labelRamas" runat="server" />
              <br />
              <asp:Label ID="labelAltura" runat="server" />
              <br />
              <asp:Label ID="labelNivel" runat="server" />
              <br />
              <asp:TextBox ID="labelTop10Usuarios" runat="server" Height="179px" ReadOnly="True" TextMode="MultiLine" Width="1050px"></asp:TextBox>
            
              <br />
              <br />
              <asp:TextBox ID="labelTop10Porcentaje" runat="server" Height="179px" ReadOnly="True" TextMode="MultiLine" Width="1050px"></asp:TextBox>

              <br />
              <br />
              <asp:TextBox ID="labelTop10Contactos" runat="server" Height="179px" ReadOnly="True" TextMode="MultiLine" Width="1050px"></asp:TextBox>
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>


        <!--mostrar Tablero Actual-->
        <div class="card mb-3" runat="server" id="Div3" >
        <div class="card-header">
          <i class="fa fa-table"></i>Tablero Sobrevivientes</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <label for="exampleInputPassword1">Tablero en nivel 1</label>
              <br />
              <asp:Image ID="TAN1" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 2</label>
              <br />
              <asp:Image ID="TAN2" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 3</label>
              <br />
              <asp:Image ID="TAN3" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 4</label>
              <br />
              <asp:Image ID="TAN4" runat="server" width="1000" />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>

        <!--mostrar Tablero Destruidos-->
        <div class="card mb-3" runat="server" id="Div4" >
        <div class="card-header">
          <i class="fa fa-table"></i>Unidades Destruidas</div>
        <div class="card-body">
            
          <div class="table-responsive">
              <label for="exampleInputPassword1">Tablero en nivel 1</label>
              <br />
              <asp:Image ID="TDN1" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 2</label>
              <br />
              <asp:Image ID="TDN2" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 3</label>
              <br />
              <asp:Image ID="TDN3" runat="server" width="1000" />
              <br />
              <label for="exampleInputPassword1">Tablero en nivel 4</label>
              <br />
              <asp:Image ID="TDN4" runat="server" width="1000" />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>

                </ContentTemplate>
        </asp:UpdatePanel>


    </div>
    <!-- /.container-fluid-->
    <!-- /.content-wrapper-->
    <footer class="sticky-footer">
      <div class="container">
        <div class="text-center">
          <small>Copyright © NavalWars 2017</small>
        </div>
      </div>
    </footer>
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fa fa-angle-up"></i>
    </a>
    <!-- Logout Modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Salir</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">¿Esta seguro que desea Salir?</div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
            <asp:Button ID="Logout"  Text="Logout" Width="25%" class="btn btn-primary btn-block" OnClick="Logout_Click" runat="server" />
          </div>
        </div>
      </div>
    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/popper/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Page level plugin JavaScript-->
    <script src="vendor/chart.js/Chart.min.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin.min.js"></script>
    <!-- Custom scripts for this page-->
    <script src="js/sb-admin-charts.min.js"></script>
  </div>
</form>
</body>

</html>


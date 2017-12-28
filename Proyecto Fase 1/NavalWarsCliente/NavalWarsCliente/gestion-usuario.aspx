﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gestion-usuario.aspx.cs" Inherits="gestion_usuario" %>

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
      
      <div class="row">
        <div class="col-lg-8">
          <!-- Ingresar usuario-->
          
            <div class="card mb-3">
            <div class="card-header">
              <i class="fa fa-wrench"></i> Insertar Usuario</div>
            <div class="card-body">


                
         
             <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">NickName</label>
                <asp:TextBox ID="INick" runat="server" class="form-control" type="text" placeholder="NickName" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Correo</label><asp:Label ID="erroremail" runat="server" class="text-danger" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="ICorreo" runat="server" class="form-control" type="email" placeholder="Ingrese su Correo" ></asp:TextBox>
              </div>
            </div>
          </div>
          
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Contraseña</label>
                <asp:TextBox ID="IPass" runat="server" class="form-control" type="text" placeholder="Contraseña" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>
          <asp:Button ID="BCrear" runat="server" Text="Crear Cuenta" Width="100%" class="btn btn-primary btn-block" OnClick="BCrear_Click"  />
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Archivo CSV Usuarios</label>
                  <asp:FileUpload ID="FileUploadCSVUsuarios" accept =".csv" runat="server" />
                
              </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">Subir</label>
               <asp:Button ID="BSubirUsuarios" runat="server" Text="Cargar" Width="100%" class="btn btn-primary btn-block" OnClick="BSU_Click"  />
              </div>
                
            </div>

              


            
          </div>
          


            </div>
            <div class="card-footer small text-muted"></div>
          </div>

		 
            

		  
		  
        </div>
        <div class="col-lg-4">
          <!-- Example Pie Chart Card-->
          
           


        </div>
      </div>


        



        


        <!--mostrar usuarios-->
        <div class="card mb-3" runat="server" id="mostrar" >
        <div class="card-header">
          <i class="fa fa-table"></i> Resultador de la Busqueda</div>
        <div class="card-body">
            
          <div class="table-responsive">
                
            <asp:GridView runat="server" class="table table-bordered" ID="TableUsuarios"  AutoGenerateColumns="false">
              <columns>
                  <asp:BoundField HeaderText="Nick" />
                  
                  
              </columns>
            </asp:GridView>
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>




         





       



         <!-- Modificar-->
      <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-search"></i> Modificar Usuario</div>
        <div class="card-body">
           
            
            
            
            
            
              
                
                  <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                


                  <asp:DropDownList runat="server" ID="txtCorreoq"  class="btn btn-group-vertical dropdown-toggle" >

                  </asp:DropDownList>
                  <asp:TextBox ID="TxtBuscar" runat="server" class="form-control" type="name" placeholder="NickName" ></asp:TextBox>

              </div>
              <div class="col-md-6">
                
                <asp:Button ID="Bbuscar" runat="server" class="btn-primary btn btn-block" Text="Buscar" OnClick="Bbuscar_Click"></asp:Button>
              </div>
            </div>


                      <div class="form-group">
            <label for="exampleInputEmail1">Eliminar usuario</label>
              <asp:Button ID="BEliminar" runat="server" class="btn-primary btn btn-block" Text="Eliminar" OnClick="BEliminar_Click"></asp:Button>
                
          </div>
          </div>




              
            
          

            
              
                
                <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">NickName</label>
                <asp:TextBox ID="Mnick" runat="server" class="form-control" type="name" placeholder="NickName" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Correo</label><asp:Label ID="Label1" runat="server" class="text-danger" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="Mcorreo" runat="server" class="form-control" type="email" placeholder="Ingrese su Correo" ></asp:TextBox>
              </div>
            </div>
          </div>
          
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Contraseña</label>
                <asp:TextBox ID="Mpass" runat="server" class="form-control" type="text" placeholder="Contraseña" ></asp:TextBox>
              </div>
                <div class="col-md-6">
                <label for="exampleInputPassword1">Estado</label>
                <asp:TextBox ID="Estado" runat="server" class="form-control" type="number" placeholder="Estado" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>
          <asp:Button ID="modificar" runat="server" Text="Modificar" Width="100%" class="btn btn-primary btn-block" OnClick="BModificar_Click"  />
          



          
        
        
        </div>
        <div class="card-footer small text-muted"></div>
      </div>




        <div class="row">
        <div class="col-lg-8">
          <!-- Ingresar usuario juego-->
          
            <div class="card mb-3">
            <div class="card-header">
              <i class="fa fa-wrench"></i> Insertar Juegos de Usuario</div>
            <div class="card-body">


                
         
             <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">NickName</label>
                <asp:TextBox ID="INickBase" runat="server" class="form-control" type="text" placeholder="NickName Usuario" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">NickName Oponente</label><asp:Label ID="Label2" runat="server" class="text-danger" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="INickOponente" runat="server" class="form-control" type="text" placeholder="Ingrese el NickName del oponente" ></asp:TextBox>
              </div>
            </div>
          </div>
          
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades desplegadas</label>
                <asp:TextBox ID="IUD" runat="server" class="form-control" type="number" placeholder="" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades sobrevivientes</label>
                  <asp:TextBox ID="IUS" runat="server" class="form-control" type="number" placeholder=""></asp:TextBox>
              </div>
                
            </div>

            
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades destruidas</label>
                <asp:TextBox ID="IUDes" runat="server" class="form-control" type="number" placeholder="" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputPassword1">gano</label>
                  <asp:TextBox ID="IG" runat="server" class="form-control" type="number" placeholder=""></asp:TextBox>
              </div>
                
            </div>

            
          </div>
          <asp:Button ID="IJuegos" runat="server" Text="Ingresar a la Lista de Juegos" Width="100%" class="btn btn-primary btn-block" OnClick="BIjuegos_Click"  />
          <div class="form-group">
            

              <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Archivo CSV Juegos</label>
                  <asp:FileUpload ID="FileUploadCSVJuegos" accept=".csv" runat="server" />
                
              </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">Subir</label>
               <asp:Button ID="BSubirJuegos" runat="server" Text="Cargar" Width="100%" class="btn btn-primary btn-block" OnClick="BSJ_Click"  />
              </div>
                
            </div>


            
          </div>
          


            </div>
            <div class="card-footer small text-muted"></div>
          </div>

		 
            

		  
		  
        </div>
        <div class="col-lg-4">
          <!-- Example Pie Chart Card-->
          
           


        </div>
      </div>


       



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


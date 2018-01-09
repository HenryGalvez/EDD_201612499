<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gestion-juegos.aspx.cs" Inherits="gestion_juegos" %>

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
            <asp:HyperLink ID="gestionjuegos" runat="server" class="nav-link" NavigateUrl="gestion-juegos.aspx" >
          
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
          <!-- Ingresar unidad-->
          
            <div class="card mb-3">
            <div class="card-header">
              <i class="fa fa-wrench"></i> Insertar Unidad</div>
            <div class="card-body">


                
         
             <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">NickName del Jugador</label>
                <asp:TextBox ID="INick" runat="server" class="form-control" type="text" placeholder="NickName" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Fila</label>
                <asp:TextBox ID="IFila" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
            </div>
          </div>
          
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Columna</label>
                <asp:TextBox ID="IColumna" runat="server" class="form-control" type="letter" placeholder="Solo Letras" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputPassword1">Tipo</label>
                  <asp:DropDownList ID="IDLTipo" runat="server">
                      <asp:ListItem>Submarino</asp:ListItem>
                      <asp:ListItem>Crucero</asp:ListItem>
                      <asp:ListItem>Fragata</asp:ListItem>
                      <asp:ListItem>Helicoptero</asp:ListItem>
                      <asp:ListItem>Caza</asp:ListItem>
                      <asp:ListItem>Bombardero</asp:ListItem>
                      <asp:ListItem>Neosatelite</asp:ListItem>
                  </asp:DropDownList>
                
              </div>
                
            </div>

            
          </div>
          <asp:Button ID="BCrear" runat="server" Text="Crear Unidad" Width="100%" class="btn btn-primary btn-block" OnClick="BCrear_Click"  />
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Archivo CSV Unidades</label>
                  <asp:FileUpload ID="FileUploadCSVUnidades" accept =".csv" runat="server" />
                
              </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">Subir</label>
               <asp:Button ID="BSubirUnidades" runat="server" Text="Cargar" Width="100%" class="btn btn-primary btn-block" OnClick="BSU_Click"  />
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



        <!--Mover-->
        <div class="card mb-3" runat="server" id="Div2" >
        <div class="card-header">
          <i class="fa fa-table"></i> Mover Unidad</div>
        <div class="card-body">
            
          <div class="table-responsive">
                
            
              
              

              <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Columna Nueva</label>
                <asp:TextBox ID="IColNue" runat="server" class="form-control" type="letter" placeholder="Solo Letras Columna Nueva" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Fila Nueva</label>
                <asp:TextBox ID="IFilNue" runat="server" class="form-control" type="number" min="0" placeholder="Fila Nueva" ></asp:TextBox>
              </div>
            </div>
          </div>
                <asp:TextBox ID="DLMove" runat="server" class="form-control" type="text" placeholder="Fila Nueva" ></asp:TextBox>
              <asp:label runat="server" ID="labelMsj" Font-Bold="True"></asp:label>
              <asp:Button ID="BMover"  runat="server" Text="Mover Unidad" Width="100%" class="btn btn-primary btn-block" OnClick="BMover_Click"  />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>




        <!--Atacar-->
        <div class="card mb-3" runat="server" id="Div3">
            <div class="card-header">
                <i class="fa fa-table"></i>Mover Unidad
            </div>
            <div class="card-body">

                <div class="table-responsive">


                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputPassword1">Columna A Atacar</label>
                                <asp:TextBox ID="IColAc" runat="server" class="form-control" type="letter" placeholder="Solo Letras Columna Actual"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="exampleInputLastName">Fila A Atacar</label>
                                <asp:TextBox ID="IFilAc" runat="server" class="form-control" type="number" min="0" placeholder="Fila Actual"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <label for="exampleInputLastName">Unidad</label>
                    <asp:TextBox ID="DLAtacar" runat="server" class="form-control" type="text" placeholder="Atacar"></asp:TextBox>
                    <label for="exampleInputLastName">Nivel</label>
                    <asp:DropDownList ID="DLNivel" runat="server">
                      <asp:ListItem>1</asp:ListItem>
                      <asp:ListItem>2</asp:ListItem>
                      <asp:ListItem>3</asp:ListItem>
                      <asp:ListItem>4</asp:ListItem>
                  </asp:DropDownList>-->
                    <asp:label runat="server" ID="labelMsjA">Fila A Atacar</asp:label>
                    <asp:Label runat="server" ID="label1" Font-Bold="True"></asp:Label>
                    <asp:Button ID="BAtacar" runat="server" Text="Mover Unidad" Width="100%" class="btn btn-primary btn-block" OnClick="BAtacar_Click" />

                </div>
            </div>
            <div class="card-footer small text-muted">Updated</div>
        </div>




        
        <!--Eliminar-->
        <div class="card mb-3" runat="server" id="Div1" >
        <div class="card-header">
          <i class="fa fa-table"></i> Eliminar Unidad</div>
        <div class="card-body">
            
          <div class="table-responsive">
                
            <!--
              <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Columna</label>
                <asp:TextBox ID="EUColumna" runat="server" class="form-control" type="letter" placeholder="Solo Letras" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Fila</label>
                <asp:TextBox ID="EUFila" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
            </div>
          </div> 
                <asp:DropDownList ID="DLElimiar" runat="server">
                      <asp:ListItem>Submarino</asp:ListItem>
                      <asp:ListItem>Crucero</asp:ListItem>
                      <asp:ListItem>Fragata</asp:ListItem>
                      <asp:ListItem>Helicoptero</asp:ListItem>
                      <asp:ListItem>Caza</asp:ListItem>
                      <asp:ListItem>Bombardero</asp:ListItem>
                      <asp:ListItem>Neosatelite</asp:ListItem>
                  </asp:DropDownList>-->
              <asp:TextBox ID="DLEliminar" runat="server" class="form-control" type="letter" placeholder="Solo Letras" ></asp:TextBox>
              <asp:Button ID="BtnEliminarU" runat="server" Text="Eliminar Unidad" Width="100%" class="btn btn-primary btn-block" OnClick="BEliminar_Click"  />
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>

        


        <!--mostrar usuarios-->
        <div class="card mb-3" runat="server" id="mostrar" >
        <div class="card-header">
          <i class="fa fa-table"></i> Parametros Actuales</div>
        <div class="card-body">
            
          <div class="table-responsive">
                
            
              <asp:Label ID="LabelNivel1" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelNivel2" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelNivel3" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelNivel4" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelTamx" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelTamy" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelTiempo" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelNick1" runat="server" Text=""></asp:Label>
              <br />
              <asp:Label ID="LabelNick2" runat="server" Text=""></asp:Label>
                
            
          </div>
        </div>
        <div class="card-footer small text-muted">Updated</div>
      </div>




         





       



         <!-- Modificar parametros-->
      <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-search"></i> Modificar Parametros</div>
        <div class="card-body">
           
            
            
            <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades en el Nivel 1</label>
                <asp:TextBox ID="IUN0" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
                <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades en el Nivel 2</label>
                <asp:TextBox ID="IUN1" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>

                
          
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Unidades en el Nivel 3</label>
                <asp:TextBox ID="IUN2" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
                <div class="col-md-6">
                <label for="exampleInputPassword1">Unidaes en el Nivel 4</label>
                <asp:TextBox ID="IUN3" runat="server" class="form-control" type="number" min="0" placeholder="" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>

            <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Cantidad de Filas</label>
                <asp:TextBox ID="ICF" runat="server" class="form-control" type="number" min="1" placeholder="" ></asp:TextBox>
              </div>
                <div class="col-md-6">
                <label for="exampleInputPassword1">Cantidad de Columnas</label>
                <asp:TextBox ID="ICC" runat="server" class="form-control" type="number" min="1" placeholder="" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>
            <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">NickName 1</label>
                <asp:TextBox ID="INN1" runat="server" class="form-control" type="text" placeholder="" ></asp:TextBox>
              </div>
                <div class="col-md-6">
                <label for="exampleInputPassword1">NickName 2</label>
                <asp:TextBox ID="INN2" runat="server" class="form-control" type="text" placeholder="" ></asp:TextBox>
              </div>
              
                
            </div>

            
          </div>
            
            <div class="form-group">
            

              <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">Archivo CSV Juegos</label>
                  <asp:FileUpload ID="FileUploadParametros" accept=".csv" runat="server" />
                
              </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">Subir</label>
               <asp:Button ID="CParametros" runat="server" Text="Cargar" Width="100%" class="btn btn-primary btn-block" OnClick="BSP_Click"  />
              </div>
                
            </div>


            
          </div>

            <div class="form-group">
            <div class="form-row">
              
                <div class="col-md-6">
                <label for="exampleInputPassword1">Tiempo de cada Juego (minutos)</label>
                <asp:TextBox ID="ITJ" runat="server" class="form-control" type="number" min="1" placeholder="" ></asp:TextBox>
              </div>
              

                <div class="col-md-6">
                <label for="exampleInputPassword1">Tipo de Juego</label>
                <asp:DropDownList ID="DLModo" runat="server">
                      <asp:ListItem>Seleccione un Tipo de Juego</asp:ListItem>
                      <asp:ListItem>Normal</asp:ListItem>
                      <asp:ListItem>Tiempo</asp:ListItem>
                      <asp:ListItem>Base</asp:ListItem>
                      <asp:ListItem></asp:ListItem>
                  </asp:DropDownList>
              </div>
                
                
            </div>

            
          </div>

          <asp:Button ID="modificar" runat="server" Text="Modificar Parametros" Width="100%" class="btn btn-primary btn-block" OnClick="BModificarP_Click"  />
          



          
        
        
        </div>
        <div class="card-footer small text-muted"></div>
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

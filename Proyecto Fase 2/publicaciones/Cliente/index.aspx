<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>



<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>ReviewSoft</title>
  <!-- Bootstrap core CSS-->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">
</head>

<body class="bg-dark">
  <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Login</div>
      <div class="card-body">
          <form id="form1" runat="server">
          <div class="form-group">
            <label for="exampleInputEmail1">NickName</label><asp:Label ID="errorCorreo" runat="server"></asp:Label>
&nbsp;<asp:TextBox ID="nick" runat="server" class="form-control" type="text" placeholder="Ingrese su Correo"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="exampleInputPassword1">Contraseña</label><asp:Label ID="errorContraseña" runat="server"></asp:Label>
&nbsp;<asp:TextBox ID="pass" runat="server" class="form-control" type="password" placeholder="Ingrese su Contraseña"></asp:TextBox>
          </div>
          <div class="form-group">
            <div class="form-check">
              
            </div>
          </div>
            <asp:Button ID="log" runat="server" Text="Login" Width="100%" class="btn btn-primary btn-block" OnClick="log_Click"  />
          </form>
        <div class="text-center">
            
        &nbsp;</div>
      </div>
    </div>
  </div>
  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/popper/popper.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
</body>

</html>


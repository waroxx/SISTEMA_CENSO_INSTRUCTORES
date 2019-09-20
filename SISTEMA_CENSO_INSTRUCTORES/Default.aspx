<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SISTEMA_CENSO_INSTRUCTORES.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"
            crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/js/bootstrap-select.min.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"
            crossorigin="anonymous">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/css/bootstrap-select.min.css">
        <link rel="stylesheet" href="assets/css/tabla-inec.css">
        <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" />




    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="bootstrap/js/bootstrap.js"></script>
    <%--<script src="jqueryUI/jquery-ui.js"></script>--%>
    <script src="Scripts/bootstrap-select.js"></script>
    <script src="scripts.js"></script>

    <link rel="stylesheet" href="bootstrap/css/bootstrap.css"/>
     <link rel="icon" href="assets/img/favicon.ico">
    <link rel="stylesheet" type="text/css" href="~/estilos.css">
   <%-- <link href="me.json" type="text/json" rel="json" />
    <link href="you.json" type="text/json" rel="json" />--%>
    <%--<link rel="stylesheet" href="jqueryUI\jquery-ui.css" />--%>
    <link rel="stylesheet" href="Content/bootstrap-select.css"/>
</head>
<body style="background-image:url('img/fondo05.jpg');">
    <br /><br /><br /><br /><br />
<div class="container" style="width: 400px;margin: 50px auto; background-color: #F3EDED; border: 1px solid #ECE8E8; height: 475px; border-radius:8px;">
    <br />
    
<br />
    <div class ="row text-center">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <img class="text-center" src="img/Logo-Censo2020-2.png" width="140" height="110"/>
            </div>
            <div class="col-lg-2"></div>
        </div><br /><br />
    <div class ="row text-center">
            <%--<div class="col-lg-1"></div>--%>
            <div class="col-lg-12">
                <span class="caja-titulo-text" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-weight:700;font-size:16px; color:#049475">SISTEMA </span>
            </div>
            <%--<div class="col-lg-1"></div>--%>
        </div><br /><br />
                 
   <form action="" method="post" name="FormEntrar">
		 		<div class="input-group input-group-lg">
				  <%--<label class="form-control col-md-3 col-lg-3" id="" >CGR\</label>--%>
                     <span class="input-group-addon" id="sizing-addon1">CGR</span>
				  <input type="text" class="form-control col-lg-9" name="Usuario" data-toggle="login" data-placement="right" title="EJ: MQUINTERO" data-position placeholder="Usuario de red" id="usuario" aria-describedby="sizing-addon1" required>
				</div>
				<br/>
				<div class="input-group input-group-lg">
				  <span class="input-group-addon" id="sizing-addon1"><i class="glyphicon glyphicon-lock"></i></span>
				  <input type="password" name="contra" class="form-control" placeholder="Contraseña" aria-describedby="sizing-addon1" id="password" required>
				</div>
       <div class="row col-lg-12 text-center">
           <div class="col-lg-2"></div>
           <div class="col-lg-10 text-center">
               <img src="img/ajax_loading.gif" width="20px" height ="20px" id="loadimg" style="margin:10px;"/>
               <span class="col-lg-10" id="error" style=color:red;font-size:12px;>Usuario o Contraseña invalida</span>
           </div>
           <div class="col-lg-1"></div>
       </div>
				<br/>
				<button class="btn btn-lg  btn-block btn-signin" id="IngresoLog" type="Button" style="background-color:#049475; color:#ffffff">Entrar</button>
		 	</form>
</div>
    <script>
       $(document).ready(function () {
           $.ajax({
               type: "POST",
               url: "Default.aspx/currentUser",
               contentType: "application/JSON",
               success: function (resp) {
                   if (resp.d.indexOf("CGR\\") == -1) {
                       $("#usuario").attr("data-original-title", "Ejemplo:  EBECKFORD");
                       console.log(resp.d);
                   } else {
                       $("#usuario").attr("data-original-title", "Ejemplo:  " + resp.d.replace("CGR\\", ""));
                   }
               },
               error: function (xhr, status, error) {
                   alert(xhr.responseText);
               }
           });
           $('[data-toggle="login"]').tooltip();
           $("#usuario, #password").keypress(function (e) {
               var k = e.keyCode || e.which;
               if (k == 13) {
                   $("#IngresoLog").trigger("click");
               }
           });
           $("#error").hide();
           $("#loadimg").hide();
           $("#IngresoLog").click(function () {
               $("#error").hide();
               $("#loadimg").show();
               $.ajax({
                   type: "POST",
                   url: "Default.aspx/login",
                   contentType: "application/JSON",
                   data: '{ "user":"' + $('#usuario').val().toUpperCase()  + '", "password":"' + $('#password').val() + '"}',
                   success: function (resp) {
                       $("#loadimg").hide();
                       if (!resp.d) {
                           $("#error").show();
                       } else {
                           window.location.replace("Formulario.aspx");
                       }
                       //alert(resp.d);
                   },
                   error: function (xhr, status, error) {
                       $("#loadimg").hide();
                       alert(xhr.responseText);
                   }
               });
           });
       });
   </script>
</body>
</html>
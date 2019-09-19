<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="SISTEMA_CENSO_INSTRUCTORES.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <title></title>
</head>
<body>
<div class="container-fluid ">

<div class="panel panel-primary col-md-10 col-md-offset-1"  style="margin-top:20px">
<div class="panel-heading"><h2 class="panel-title" style="text-align:center; font-weight:bold; font-size:20px">Formulario de Inscripción para Instructores</h2></div>
<div class="panel-body">
	<br /><br />
    <div class="row">
    <div class="col-md-4" style="border:solid;border-width:2px;border-radius:5px; height:150px;"></div></div>	
    <br /><br /><br /><br />
    <div class="row" style="border:solid;border-radius:6px;border-width:1px;">
        <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Tipo de Actividad</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Descripción</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Tema</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Año</label>
        </div>
    </div>					
</div>
</div>
</div>
</body>
</html>

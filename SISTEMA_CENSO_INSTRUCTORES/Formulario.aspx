﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="SISTEMA_CENSO_INSTRUCTORES.WebForm2" %>

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
    <link rel="stylesheet" type="text/css" href="~/estilos.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title></title>
</head>
<body>
<div class="container-fluid ">

<div class="panel panel-primary col-md-10 col-md-offset-1"  style="margin-top:20px">
<div class="panel-heading"><h2 class="panel-title" style="text-align:center; font-weight:bold; font-size:20px">Formulario de Inscripción para Instructores</h2></div>
<br /><div class="row">
<div class="col-md-10"></div>
 <div class="col-md-2" style="text-align:right">
    <a class="btn btn-basic" href="javascript:CerrarSession();" id="salir" style="background-color:#e5007f" >
                <b style="font-size:18px; color:white;">Salir</b>&nbsp;&nbsp;<i class="fa fa-share" aria-hidden="true" style="font-size:24px; color:white;"></i>
            </a>
</div></div>
<div class="panel-body">
	<br /><br />
    <div class="row">
    <div id="datos-generales" class="col-md-4" style="border:solid;border-width:2px;border-radius:5px;border-color:#126bb4;padding-left:50px;padding-right:50px;">
        <span>Cargando...</span>
    </div></div>	
    <br /><br /><br /><br />
    <div class="row" >
        <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Tipo de Actividad</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Descripción</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px;">Tema</label>
        </div>
         <div class="col-md-2" style="text-align:center">
            <label style="font-size:16px;">Año</label>
        </div>
    </div>
    <br />	
<div id="experiencias">
    <div class="row" >
        <div class=" form-group col-md-3" style="text-align:center" >
            <select class="selectpicker seltipo" id="seltipo">
                <option selected="selected">Seleccione</option>
               <option value="1">Censo</option>
               <option value="2">Encuesta</option>
               <option value="3">Investigación Especial</option>
               <option value="4">Otros(Especifique)</option>
            </select>
            <br /><br />
            <div class="form-group otrotipo" id="otrotipo" style="display:none;"><input type="text" class="form-control otrotipo" style=" width:220px; margin-left:35px"/></div>
        </div>
         <div class="col-md-3" style="text-align:center">
            <input type="text" class="form-control descripcion" id="desc"/>
        </div>
         <div class="col-md-3" style="text-align:center">
           <select class="selectpicker seltema">
                <option selected="selected" value="0">Seleccione</option>
               <option value="1">Metodología</option>
               <option value="2">Cartografía</option>
               <option value="3">Administrativo y Presupuesto</option>
               <option value="4">Tecnología</option>

            </select>
        </div>
         <div class="col-md-2" style="text-align:center">
            <input type="text" class="form-control year" id="year"/>
        </div>
         <div class="col-md-1" style="text-align:center">
             <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete" >
                <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i>
            </a>
        </div>
         <div class="col-md-12"><hr  style=" height: 1px;background-color: #126bb4; margin-top:0px"  /></div>
    </div>
    
</div>
    	<br />
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-2" >
        <a class="btn btn-success" href="javascript:void(0);" id="agregar" >
                <i class="fa fa-plus " aria-hidden="true" style="font-size:24px;"></i>&nbsp;&nbsp;<b style="font-size:16px">Agregar</b>
            </a>
         </div>
        <div class="col-md-6"></div>
        <div class="col-md-2" >
        <a class="btn btn-primary" href="javascript:Enviar();" id="enviar" >
                <b style="font-size:16px">Enviar</b>&nbsp;&nbsp;<i class="fa fa-send " aria-hidden="true" style="font-size:24px;"></i>
            </a>
         </div>
    </div>			
</div>
</div>
</div>
    <script>
        
        $(document).ready(function () {
            getDatosGenerales()
            prepararSeltipo()
            prepararEliminar()
      
            $("#agregar").click(function () {
                $('#experiencias').append(` <div class="row" >
        <div class=" form-group col-md-3" style="text-align:center" >
            <select class="selectpicker seltipo" id="seltipo">
                <option selected="selected">Seleccione</option>
               <option value="1">Censo</option>
               <option value="2">Encuesta</option>
               <option value="3">Investigación Especial</option>
               <option value="4">Otros(Especifique)</option>
            </select>
            <br /><br />
            <div class ="form-group otrotipo" id="otrotipo" style="display:none"><input type="text" class ="form-control otrotipo" style=" width:220px; margin-left:35px"  /></div>
        </div>
         <div class="col-md-3" style="text-align:center">
            <input type="text" class="form-control descripcion" id="desc"/>
        </div>
         <div class="col-md-3" style="text-align:center">
           <select class="selectpicker seltema">
                <option selected="selected " value="0">Seleccione</option>
               <option value="1">Metodología</option>
               <option value="2">Cartografía</option>
               <option value="3">Administrativo y Presupuesto</option>
               <option value="4">Tecnología</option>

            </select>
        </div>
         <div class="col-md-2" style="text-align:center">
            <input type="text" class="form-control year" id="year"/>
        </div>
         <div class="col-md-1" style="text-align:center">
             <a class ="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete">
                <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i>
            </a>
        </div>
          <div class ="col-md-12"><hr  style=" height: 1px;background-color: #126bb4; margin-top:0px"  /></div>
    </div>`);
                $(".selectpicker").selectpicker();
                prepararSeltipo();
                prepararEliminar();
                revisarHijos();
            });
        });


        function prepararSeltipo() {
            let seltipo = $(".selectpicker.seltipo");
            $(seltipo).each(function () {
                $(this).change(function () {
                    let padre = $(this).closest('.row');
                    let tipo = $(this).val();
                    let otipo = $(padre).find(".otrotipo");

                    if (tipo == '4') {
                        $(otipo).css('display', 'block');
                    }
                    else {
                        $(otipo).css('display', 'none');
                    }

                });

            });
        }



        function prepararEliminar() {
            let btnEliminar = $(".eliminar");
            $(btnEliminar).each(function () {
                $(this).click(function () {
                    let padre = $(this).closest('.row');
                    let rows = $(padre).closest("#experiencias");
                    if ($(rows).children().length > 1) {
                        $(padre).remove();
                        revisarHijos();
                    }
                });

            });
        }

        function revisarHijos() {
            if ($('#experiencias').children().length >= 5) {
                $("#experiencias").attr('style','overflow-y:auto;overflow-x:hidden; height:455px');
            }
            else {
                $("#experiencias").removeAttr('style');
            }

        }


        function getDatosGenerales() {
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/datosBuscarDatosGenerales",
                contentType: "application/JSON",
                success: function (resp) {
                    $("#datos-generales").html(resp.d);
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }
        function CerrarSession() {
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/cerrarSession",
                contentType: "application/JSON",
                success: function (resp) {
                    if (resp.d) {
                        window.location.replace("Default.aspx");
                    }
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        function LeerHijos() {
            let hijos = $("#experiencias").children();
            let arrhijo = [];
            hijos.each(function (key,el) {
                let stipo = $(el).find(".selectpicker.seltipo");
                let otipo = $(el).find(".form-control.otrotipo");
                let desc=$(el).find(".descripcion")
                let stema = $(el).find(".selectpicker.seltema");
                let year = $(el).find(".year");

                let obj = {
                    INDICE:key,
                    TIPO_ACTIVIDAD: $(stipo[0]).val(),
                    TIPO_ACTIVIDAD_ESP: $(otipo[0]).val(),
                    DESCRIPCION: $(desc[0]).val(),
                    TEMA: $(stema[0]).val(),
                    YEAR:$(year[0]).val()
                }
                arrhijo.push(obj);
            });
            return arrhijo;
        }

        function Enviar() {
            let d = JSON.stringify(LeerHijos());
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/postExperiencias",
                contentType: "application/JSON",
                data:"{'experiencias':'"+d+"'}",
                success: function (resp) {
                    if (resp.d === "True") {
                        alert("Datos Guadados con Éxito");
                    }
                   else if (resp.d === "False") {
                        alert("Error: datos no guardados");
                    }
                    else {
                        alert(resp.d);
                    }
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }
        
        

    </script>
</body>
</html>

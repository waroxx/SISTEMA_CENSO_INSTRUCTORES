<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="SISTEMA_CENSO_INSTRUCTORES.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
    
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/otroScript/popper.min.js"></script>
    <%--<script src="Scripts/popper.min.js"></script>--%>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <%--<script src="jqueryUI/jquery-ui.js"></script>--%>
    <script src="Scripts/bootstrap-select.js"></script>
    <%--<link rel="stylesheet" type="text/css" href="~/estilos.css">--%>
    <%--<link href="Content/font-awesome.min.css" rel="stylesheet" />--%>
    <link href="Content/bootstrap-select.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Instructores</title>
</head>
<body>
<div class="container-fluid">

<div class="card border-primary col-md-10 offset-1"  style="margin-top:20px">
<div class="card-header text-light bg-primary"><h2 class="card-title" style="text-align:center; font-weight:bold; font-size:20px">Formulario de Inscripción para Instructores</h2></div>
<br /><div class="row">
<div class="col-md-10"></div>
 <div class="col-md-2" style="text-align:right">
    <a class="btn btn-basic btn-sm" href="javascript:CerrarSession();" id="salir" style="background-color:#e5007f" >
                <b style="font-size:18px; color:white;">Salir</b>&nbsp;&nbsp;<i class="fa fa-share" aria-hidden="true" style="font-size:24px; color:white;"></i>
            </a>
</div></div>
<div class="card-body">
	<br />
    <div class="row">
    <div id="buscador-cedula" class="col-md-4" style="border:solid;border-width:2px;border-radius:5px;border-color:#126bb4;padding-left:50px;padding-right:50px;">
        <div class='row'><br /></div>
      <div class='row'>
        <div class='input-group mb-2'>
          <div class='input-group-prepend'>
            <div class='input-group-text'>Cédula</div>
          </div>
          <input
            type='text'
            class='form-control'
            id='inlineFormInputGroup'
            placeholder='8-888-8888'
            oninput='blockFields()'
          />
        </div>
      </div>
      <div class='row'>
        <a class='btn' style='background-color:#E5007F;color:#FFFFFF' id='btn-buscar-cedula' onclick="getDatosGenerales()">Buscar</a>
      </div>
      <div class='row'><br /></div>
      <div class='row' id='buscar-response'></div>
    </div>
        <div id="datos-generales" class="col-md-4" style="padding-left:50px;padding-right:50px;">
        ...
    </div>
    </div>	
    <br />
    <div class="row" >
        <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Tipo de Actividad</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Descripción</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Tema</label>
        </div>
         <div class="col-md-2" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Año</label>
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
            <input type="text" class="form-control" id="desc"/>
        </div>
         <div class="col-md-3" style="text-align:center">
           <select class="selectpicker">
                <option selected="selected" value="0">Seleccione</option>
               <option value="1">Metodología</option>
               <option value="2">Cartografía</option>
               <option value="3">Administrativo y Presupuesto</option>
               <option value="4">Tecnología</option>

            </select>
        </div>
         <div class="col-md-2" style="text-align:center">
            <input type="text" class="form-control" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)"/>
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
    <div class="row" id="exp-botones">
        <div class="col-md-10 offset-1 d-flex">
        <a class="btn btn-success mr-auto" href="javascript:void(0);" id="agregar" >
                <i class="fa fa-plus " aria-hidden="true" style="font-size:24px;"></i>&nbsp;&nbsp;<b style="font-size:16px">Agregar</b>
            </a>
             <a class="btn btn-primary" href="javascript:Enviar();" id="enviar" >
                <b style="font-size:16px">Enviar</b>&nbsp;&nbsp;<i class="fa fa-send " aria-hidden="true" style="font-size:24px;"></i>
            </a>
         </div>
        <%--<div class="col-md-2" >
        <a class="btn btn-primary" href="javascript:Enviar();" id="enviar" >
                <b style="font-size:16px">Enviar</b>&nbsp;&nbsp;<i class="fa fa-send " aria-hidden="true" style="font-size:24px;"></i>
            </a>
         </div>--%>
    </div>			
</div>
</div>
</div>
    <script>
        
        $(document).ready(function () {
            //getDatosGenerales()
            getCedulaRecomendada();
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
            <input type="text" class ="form-control year" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)"/>
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
            blockFields();
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
            if ($('#experiencias').children().length >= 3) {
                $("#experiencias").attr('style','overflow-y:auto;overflow-x:hidden; height:340px');
            }
            else {
                $("#experiencias").removeAttr('style');
            }

        }

        function getDatosGenerales() {
            let c = $("#inlineFormInputGroup").val();
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/BuscarDatosGenerales",
                contentType: "application/JSON",
                data:"{'cedula':'"+c+"'}",
                success: function (resp) {
                    let r = resp.d;
                    if (resp.d == "ERROR" || r.includes("su cedula es")) {
                        $("#experiencias :input, #experiencias a").attr("disabled", true);
                        $("#experiencias a").css("display", "none");
                        $("#exp-botones").css("display", "none");
                    } else {
                        $("#experiencias :input, #experiencias a").attr("disabled", false);
                        $("#experiencias a").css("display", "block");
                        $("#exp-botones").css("display", "block");
                    }
                    $("#datos-generales").html(resp.d);
                    getExp();
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        function getCedulaRecomendada() {

            $.ajax({
                type: "POST",
                url: "Formulario.aspx/getCedula",
                contentType: "application/JSON",
                success: function (resp) {
                    //if (resp.d === "ERROR") {
                    //    $("#experiencias :input, #experiencias a").attr("disabled", true);
                    //    $("#experiencias a").css("display", "none");
                    //    $("#exp-botones").css("display", "none");
                    //} else {
                    //    $("#experiencias :input, #experiencias a").attr("disabled", false);
                    //    $("#experiencias a").css("display", "block");
                    //    $("#exp-botones").css("display", "block");
                    //}
                    $("#inlineFormInputGroup").val(resp.d);
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
            hijos.each(function (key, el) {
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
            let ced = $("#ced-general").html();
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/postExperiencias",
                contentType: "application/JSON",
                data:"{'experiencias':'"+d+"', 'cedula':'"+ced+"'}",
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

        function getExp() {
            let ced = $("#ced-general").html();
            $.ajax({
                type: "POST",
                url: "Formulario.aspx/getExperiencias",
                contentType: "application/JSON",
                data: "{'cedula':'" + ced + "'}",
                success: function (resp) {
                    if (resp.d === "ERROR") {
                        Console.log(resp.d);
                        resetCampos();
                    }
                    else if (resp.d.includes("WARNING")) {
                        console.log(resp.d);
                        resetCampos();
                    }else if(resp.d==""){
                        resetCampos();
                    $(".selectpicker").selectpicker();
                    prepararSeltipo();
                    prepararEliminar();
                    revisarHijos();
                    }
                    else {
                        //alert(resp.d);
                        $('#experiencias').html(resp.d);
                        $(".selectpicker").selectpicker();
                        $(".selectpicker").selectpicker('refresh');
                        prepararSeltipo();
                        prepararEliminar();
                        revisarHijos();
                    }
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        function resetCampos() {
            $('#experiencias').html(` <div class="row" >
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
            <input type="text" class ="form-control year" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)"/>
        </div>
         <div class="col-md-1" style="text-align:center">
             <a class ="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete">
                <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i>
            </a>
        </div>
          <div class ="col-md-12"><hr  style=" height: 1px;background-color: #126bb4; margin-top:0px"  /></div>
    </div>`);
            $(".selectpicker").selectpicker();
        }


        function Numeros(string, sender) {//Solo numeros
            var out = '';
            var filtro = '1234567890';//Caracteres validos

            //Recorrer el texto y verificar si el caracter se encuentra en la lista de validos 
            for (var i = 0; i < string.length; i++)
                if (filtro.indexOf(string.charAt(i)) != -1)
                    //Se añaden a la salida los caracteres validos
                    out += string.charAt(i);
            return out;
        }

        function blockFields() {
            $("#experiencias :input, #experiencias a").attr("disabled", true);
            $("#experiencias a").css("display", "none");
            $("#exp-botones").css("display", "none");
        }
      
        

    </script>
</body>
</html>

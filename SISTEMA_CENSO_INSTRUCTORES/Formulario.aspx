﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="SISTEMA_CENSO_INSTRUCTORES.WebForm2" %>

<!DOCTYPE html>
<%--lol--%>
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
    <script src="Scripts/MyScripts/componentes.js"></script>
    <script src="Scripts/MyScripts/subcomponentes.js"></script>
    <title>Instructores</title>
    <style>
        .fieldRow:nth-child(even){
          background-color: #f0f0f0;
        }
        .fieldRow:nth-child(odd){
          background-color: #d4e9ff;
        }
    </style>
</head>
<body>
<div class="container-fluid">

<div class="card border-primary col-md-10 offset-1"  style="margin-top:20px">
<div class="card-header text-light bg-primary d-flex"><div class="col-md-10 m-auto "><h2 class="card-title" style="text-align:left; font-weight:bold; font-size:25px">Registro de facilitadores con experiencia del INEC</h2><h4  style="text-align:left; font-weight:bold; font-size:18px">Registro de Colaboradores con formación académica y/o experiencia en docencia.</h4></div>
<div class="col-md-2" style="text-align:right;"><a class="btn btn-light btn-sm" href="javascript:CerrarSession();" id="salir"   >
                <b style="font-size:18px;">Salir</b>&nbsp;&nbsp;<i class="fa fa-share" aria-hidden="true" style="font-size:24px; "></i>
</a></div>
</div>
<%--<div class="row">
<div class="col-md-10"></div>
 <div class="col-md-2" style="text-align:right">
    <a class="btn btn-basic btn-sm" href="javascript:CerrarSession();" id="salir" style="background-color:#e5007f" >
                <b style="font-size:18px; color:white;">Salir</b>&nbsp;&nbsp;<i class="fa fa-share" aria-hidden="true" style="font-size:24px; color:white;"></i>
            </a>
</div></div>--%>
<form>
<div class="card-body">

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
        <div id="datos-generales" class="col-md-4" style="padding-left:20px;padding-right:50px;color:#E5007F;">
        <b style="font-size:14px"><b style="color:#0000ff; font-size:18px; font-weight:700">*</b>Si usted tiene más de tres años dictando la misma capacitación o más de tres años de experiencia,por favor registre solo las tres últimas.</b><br /><b style="font-size:14px"><b style="color:#0000ff;font-size:18px; font-weight:700">*</b>Si tiene formación académica en docencia, por favor registre el grado más alto.</b>
    </div>
    </div>	
    <br />
    <div id="SiNo" class="row form-group" style="border:solid; border-color:#126bb4;border-width:2px;border-radius:5px">
        <label class="control-label col-md-11"  style="font-weight:bold;">¿Ha tenido experiencia como facilitador en Censos, encuestas o investigaciones especiales del INEC o de otras instituciones?</label><br />
        <label class="radio-inline" onclick="habilitar()" style="visibility:hidden"><input  type="radio" name="experiencia" id="expSi" value="1" disabled="disabled" style="visibility:hidden" />&nbsp;Sí </label>  &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline" onclick="habilitar()" style="visibility:hidden"><input  type="radio" id="expNo" name="experiencia" value="1" disabled="disabled" style="visibility:hidden"/>&nbsp;No </label> <br />
         <label class="control-label col-md-11"  style="font-weight:bold;">¿Tiene usted formación académica y/o experiencia en docencia?</label><br />
        <label class="radio-inline" onclick="habilitar()" style="visibility:hidden"><input  type="radio" name="formacion" id="formSi" value="1" disabled="disabled" style="visibility:hidden" />&nbsp;Sí </label>  &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline" onclick="habilitar()" style="visibility:hidden"><input  type="radio" id="formNo" name="formacion" value="1" disabled="disabled" style="visibility:hidden"/>&nbsp;No </label>
    </div>
    <br /><br />
    <div class="row" >
        <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Tipo de Actividad y/o Formación académica</label>
        </div>
         <div class="col-md-3" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Descripción</label>
        </div>
         <div class="col-md-3 tema" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Tema</label>
        </div>
         <div class="col-md-2" style="text-align:center">
            <label style="font-size:16px; font-weight:bold">Año</label>
        </div>
    </div>
    <br />	
<div id="experiencias">
    <div class="row fieldRow" >
        <div class=" form-group col-md-3" style="text-align:center" >
            <select class="form-control seltipo" id="seltipo" required="required">
               <option selected="selected" value="0">Seleccione</option>
               <option value="1">Censo</option>
               <option value="2">Encuesta</option>
               <option value="3">Investigación Especial</option>
               <option value="4">Formación Académica</option>
               <option value="5">Experiencia en Docencia</option>
               <option value="6">Otros(Especifique)</option>
            </select>
            <br /><br />
            <div class="form-group otrotipo" id="otrotipo"  style="display:none;"><input type="text"  class="form-control otrotipoI" required="" style=" width:220px; margin-left:35px"/></div>
        </div>
         <div class="col-md-3" style="text-align:center">
            <%--<input type="text" class="form-control descripcion" id="desc" required="required"/>--%>
             <select type="text" class="form-control descripcion" id="desc" required="required">
                <option selected="selected" value="0">Seleccione</option>
             </select>
        </div>
         <div class="col-md-3" style="text-align:center">
           <select class="form-control seltema" required="required">
                <option selected="selected" value="0">Seleccione</option>
               <option value="1">Metodología</option>
               <option value="2">Cartografía</option>
               <option value="3">Administrativo y Presupuesto</option>
               <option value="4">Tecnología</option>
            </select>
        </div>
         <div class="col-md-2" style="text-align:center">
            <input type="text" class="form-control year" id="year" maxlength="4" required="required" onkeyup="this.value=Numeros(this.value,this)"/>
        </div>
         <div class="col-md-1" style="text-align:center">
             <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete">
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
             <a class="btn btn-primary" href="javascript:Requeridos();" id="enviar" >
                <b style="font-size:16px">Enviar</b>&nbsp;&nbsp;<i class="fa fa-send " aria-hidden="true" style="font-size:24px;"></i>
            </a>
         </div>

        <%--<div class="col-md-2" >
        <a class="btn btn-primary" href="javascript:Enviar();" id="enviar" >
                <b style="font-size:16px">Enviar</b>&nbsp;&nbsp;<i class="fa fa-send " aria-hidden="true" style="font-size:24px;"></i>
            </a>
         </div>--%>
    </div>	
</div>	</form>	
</div>
</div>
    <script>
        
        $(document).ready(function () {
            descargarTemas();
            descargarDescripciones();
            descargarActividades();
            getCedulaRecomendada();
            prepararSeltipo();
            prepararEliminar();
      
            $("#agregar").click(function () {
                let objDiv = document.getElementById("experiencias");
                let objBody = document.getElementsByTagName("body");
                //$('#experiencias').append('<div class="row fieldRow" > <div class=" form-group col-md-3" style="text-align:center" > <select class="selectpicker seltipo" id="seltipo" required="required"> <option selected="selected" value="0">Seleccione</option> <option value="1">Censo</option> <option value="2">Encuesta</option> <option value="3">Investigación Especial</option> <option value="4">Formación Académica</option> <option value="5">Experiencia en Docencia</option> <option value="6">Otros(Especifique)</option> </select> <br/><br/> <div class="form-group otrotipo" id="otrotipo" style="display:none"><input type="text" class="form-control otrotipoI" style=" width:220px; margin-left:35px"/></div></div><div class="col-md-3" style="text-align:center"> <select type="text" class="form-control descripcion" id="desc" required="required"> <option selected="selected" value="0">Seleccione</option> </select> </div><div class="col-md-3 tema"  style="text-align:center; display:block;"> <select class="selectpicker seltema" required="required"> <option selected="selected " value="0">Seleccione</option> <option value="1">Metodología</option> <option value="2">Cartografía</option> <option value="3">Administrativo y Presupuesto</option> <option value="4">Tecnología</option> </select> </div><div class="col-md-2" style="text-align:center"> <input type="text" class="form-control year" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)" required="required"/></div><div class="col-md-1" style="text-align:center"> <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete"> <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i> </a></div><div class="col-md-12"> <hr style=" height: 1px;background-color: #126bb4; margin-top:0px"/> </div></div>');
                $('#experiencias').append(campos({ TIPO_ACTIVIDAD: 'def', TIENE_EXPERIENCIA_INEC: $("#expSi").prop('checked'), TIENE_EXPERIENCIA_DOCENTE: $("#formSi").prop('checked') }));
                objDiv.scrollTop = objDiv.scrollHeight;
                objDiv.scrollTop = objDiv.scrollHeight;
                $(".selectpicker").selectpicker();
                prepararSeltipo();
                prepararEliminar();
                revisarHijos();
            });
            blockFields();
        });


        function prepararSeltipo() {
            let seltipo = $(".form-control.seltipo");
            $(seltipo).each(function () {
                $(this).change(function () {
                    
                    let padre = $(this).closest('.row');
                    let tipo = $(this).val();
                    let otipo = $(padre).find(".otrotipo");
                    let otipoI = $(padre).find(".otrotipoI");
                    let desc = $(padre).find(".descripcion");
                    let tema = $(padre).find(".seltema");
                    let seltema = $(padre).find(".form-control.seltema");
                    

                    if (tipo == '04' || tipo == '05') {
                        $(otipo).css('display', 'none');
                        $(otipoI).removeAttr('required');
                        $(desc).replaceWith($(tipo=='05'
                            ?'<input type="text" class="form-control descripcion" id="desc" required="required"/>'
                            : '<select type="text" class="form-control descripcion" id="desc" required="required"><option selected="selected" value="0">Seleccione</option></select>'));
                        $(tema).css('visibility', 'hidden');
                        $(seltema).removeAttr('required');
                        //$(".tema").css('visibility', 'hidden');
                        getDescripcion(this);
                    }
                    else if (tipo == '06') {
                        $(otipo).css('display', 'block');
                        $(otipoI).attr('required', 'required');
                        $(desc).replaceWith($('<input type="text" class="form-control descripcion" id="desc" required="required"/>'));
                        $(tema).css('visibility', 'visible');
                        $(seltema).attr('required', 'required');
                        //$(".tema").css('visibility', 'visible');
                    }
                    else {
                        $(otipo).css('display', 'none');
                        $(otipoI).removeAttr('required');
                        $(desc).replaceWith($('<select type="text" class="form-control descripcion" id="desc" required="required"><option selected="selected" value="0">Seleccione</option></select>'));
                        $(tema).css('visibility', 'visible');
                       // $(".tema").css('visibility', 'visible');
                        getDescripcion(this);
                    }


                });

            });
            //cargarSeltipo();
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
                $("#experiencias").attr('style', 'overflow-y:auto;overflow-x:hidden; height:340px;box-shadow: 0px 4px 2px -2px gray;');
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
                    if (resp.d == "ERROR" || r.indexOf("su cedula es")!=-1) {
                        blockFields();
                    } else {
                        habilitar();
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
            let SiNo = $("#expSi").prop('checked') ? true : $("#expNo").prop('checked') ? false : null;
            let SiNoD = $("#formSi").prop('checked') ? true : $("#formNo").prop('checked') ? false : null;
            if((SiNo==null || SiNo==false)&&(SiNoD==null || SiNoD==false)){
                arrhijo.push({TIENE_EXPERIENCIA_INEC:SiNo,TIENE_EXPERIENCIA_DOCENTE:SiNoD});
                return arrhijo;
            }
            hijos.each(function (key, el) {
                let stipo = $(el).find(".form-control.seltipo");
                let otipo = $(el).find(".form-control.otrotipoI");
                let desc=$(el).find(".descripcion");
                let stema = $(el).find(".form-control.seltema");
                let year = $(el).find(".year");        
                let obj = {
                    TIENE_EXPERIENCIA_INEC: SiNo,
                    TIENE_EXPERIENCIA_DOCENTE: SiNoD,
                    INDICE:key,
                    TIPO_ACTIVIDAD: $(stipo[0]).val(),
                    TIPO_ACTIVIDAD_ESP: $(stipo[0]).val()== "06" ? $(otipo[0]).val() : null,
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
                        location.reload();
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
                    else if (resp.d.indexOf("WARNING")!=-1) {
                        console.log(resp.d);
                        resetCampos();
                        habilitar();
                    }else if(resp.d==""){
                        resetCampos();
                    $(".selectpicker").selectpicker();
                    prepararSeltipo();
                    prepararEliminar();
                    revisarHijos();
                    }
                    else if ($.parseJSON(resp.d).hasOwnProperty("Exp")) {
                        cargarExperiencias($.parseJSON(resp.d));
                        //if ($.parseJSON(resp.d).TieneExperiencia) {
                        //    $("#expNo").prop('checked',false);
                        //$("#expSi").prop('checked',true);
                        //}
                        //if (!$.parseJSON(resp.d).TieneExperiencia) {
                        //    $("#expSi").prop('checked',false);
                        //    $("#expNo").prop('checked',true);
                        //}
                       // $('#experiencias').html($.parseJSON(resp.d).Exp);
                       // $(".selectpicker").selectpicker();
                       // $(".selectpicker").selectpicker('refresh');
                        //prepararSeltipo();
                        //prepararEliminar();
                        //revisarHijos();
                        //habilitar(true);
                    }
                    
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }

        function resetCampos() {
            $('#experiencias').html('<div class="row fieldRow" > <div class=" form-group col-md-3" style="text-align:center" > <select class="selectpicker seltipo" id="seltipo" required="required"> <option selected="selected" value="0">Seleccione</option> <option value="1">Censo</option> <option value="2">Encuesta</option> <option value="3">Investigación Especial</option> <option value="4">Formación Académica</option> <option value="5">Experiencia en Docencia</option> <option value="6">Otros(Especifique)</option> </select> <br/><br/> <div class="form-group otrotipo" id="otrotipo" style="display:none"><input type="text" class="form-control otrotipoI" style=" width:220px; margin-left:35px"/></div></div><div class="col-md-3" style="text-align:center"> <select type="text" class="form-control descripcion" id="desc" required="required"> <option selected="selected" value="0">Seleccione</option> </select> </div><div class="col-md-3" style="text-align:center"> <select class="selectpicker seltema" required="required"> <option selected="selected " value="0">Seleccione</option> <option value="1">Metodología</option> <option value="2">Cartografía</option> <option value="3">Administrativo y Presupuesto</option> <option value="4">Tecnología</option> </select> </div><div class="col-md-2" style="text-align:center"> <input type="text" class="form-control year" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)" required="required"/></div><div class="col-md-1" style="text-align:center"> <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete"> <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i> </a></div><div class="col-md-12"> <hr style=" height: 1px;background-color: #126bb4; margin-top:0px"/> </div></div>');
            $('#experiencias').html(campos({ TIPO_ACTIVIDAD: 'def', TIENE_EXPERIENCIA_INEC: $("#expSi").prop('checked'), TIENE_EXPERIENCIA_DOCENTE: $("#formSi").prop('checked') }));
            $(".selectpicker").selectpicker();
            $("#expSi").prop('checked',false);
            $("#expNo").prop('checked', false);
            $("#formSi").prop('checked', false);
            $("#formNo").prop('checked', false);
            habilitar(false);
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
            $("#SiNo :input").attr("disabled", true);
            $("#experiencias :input, #experiencias a").attr("disabled", true);
            $("#experiencias a").css("display", "none");
            $("#agregar").css("visibility", "hidden");
            $("#enviar").css("display", "none");
            $("#SiNo :input").prop("disabled", true);
            $("#SiNo :input, #SiNo >.radio-inline").css("visibility", "hidden");
        }


        function habilitar(way,cargarST){
            way = way == undefined ? true : way
            cargarST=cargarST==undefined?true:cargarST
            blockFields();
            if(!way){
                return;
            }
            let dg = $("#datos-generales").text();
            if(dg=="ERROR"){
                return;
            }
            $("#SiNo :input").prop("disabled", false);
            $("#SiNo :input, #SiNo >.radio-inline").css("visibility", "visible");

            if ($("#expSi").prop('checked')|| $("#formSi").prop('checked')) {
                prepararSeltipo();
                if (cargarST) {
                    cargarSeltipo();
                }
                $("#experiencias :input, #experiencias a").attr("disabled", false);
                $("#experiencias a").css("display", "block");
                $("#agregar").css("visibility", "visible");
                $("#enviar").css("display", "block");
            } else if ($("#expNo").prop('checked') || $("#formNo").prop('checked')) {
                $("#enviar").css("display", "block");
            }

            //$(".selectpicker").selectpicker('refresh');
        }

            function Requeridos(){
                if ($("#expNo").prop("checked") && $("#formNo").prop("checked")) {
                    Enviar();
                    return;
                }
                var contador = 0;
                var contenido = "Todos los campos son requeridos, por favor llenar correctamente.";
                let a = $('[required="required"]');
                $('[required="required"]').each(function () {
                    if ($(this).val() == "" || $(this).val() == null || $(this).val() == "0") {
                        console.log($(this).val()+": error required");
                        contador++;
                    }
                });
                if(contador>=1){
                    alert(contenido);
                }
                else{
                    Enviar();
                }
            }

            function getDescripcion(element) {
                let id = $(element).val();
                let padre = $(element).closest('.row');
                let selDesc = $(padre).find(".descripcion");
                $.ajax({
                    type: "POST",
                    url: "Formulario.aspx/getDesc",
                    contentType: "application/JSON",
                    data: "{'id':'" + id + "'}",
                    success: function (resp) {
                        let obj = JSON.parse(resp.d);
                        $(selDesc).html('<option selected="selected" value="0">Seleccione</option>');
                        $.each(obj, function (key,value) {
                            $(selDesc).append('<option value="' + value.ID + '">' + value.DESCRIPCION + '</option>');
                        });    
                    },
                    error: function (xhr, status, error) {
                        alert(xhr.responseText);
                    }
                });
            }
            
            function descargarActividades() {
                $.ajax({
                    type: "POST",
                    url: "Formulario.aspx/getActividad",
                    contentType: "application/JSON",
                    success: function (resp) {
                        localStorage.setItem('selTipo', resp.d);
                        console.log("campos de tipo cargados");
                    },
                    error: function (xhr, status, error) {
                        alert(xhr.responseText);
                    }
                });
            }

                function descargarDescripciones() {
                    $.ajax({
                        type: "POST",
                        url: "Formulario.aspx/getDescFull",
                        contentType: "application/JSON",
                        success: function (resp) {
                            localStorage.setItem('selDesc', resp.d);
                            console.log("campos de descripcion");
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                }

                function descargarTemas() {
                    $.ajax({
                        type: "POST",
                        url: "Formulario.aspx/getTema",
                        contentType: "application/JSON",
                        success: function (resp) {
                            localStorage.setItem('selTema', resp.d);
                            console.log("campos de tema cargados");
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                    //localStorage.setItem('selTema', '[{"id":"01","tema":"Metodología"},{"id":"02","tema":"Cartograía"},{"id":"03","tema":"Administrativo y Presupuesto"},{"id":"04","tema":"Tecnología"}]');
                }

                function cargarExperiencias(exps) {
                    $("#expNo").prop('checked', !exps.TieneExperienciaInec);
                    $("#expSi").prop('checked', exps.TieneExperienciaInec);                      
                    $("#formNo").prop('checked', !exps.TieneExperienciaDoc);
                    $("#formSi").prop('checked', exps.TieneExperienciaDoc);
                    
                    //habilitar(true);
                    generateField(exps.Exp);
                    $(".selectpicker").selectpicker();
                    //$(".selectpicker").selectpicker('refresh');
                    prepararSeltipo();
                    prepararEliminar();
                    revisarHijos();
                    habilitar(true,false);
                }

                function cargarSeltipo() {
                    let opciones = seltipo($("#expSi").prop('checked'), $("#formSi").prop('checked'));
                    $(".form-control.seltipo").html('<option value="00">Seleccione</option>');
                    opciones.map(function (item) {
                        $(".form-control.seltipo").append('<option value="' + item.id + '">' + item.Actividad + '</option>');
                    });
                    //$(".selectpicker").selectpicker('refresh');
                }
                function modernizar() {
                    var isIE = /*@cc_on!@*/false || !!document.documentMode;
                    alert(isIE);
                }
    </script>
</body>
</html>

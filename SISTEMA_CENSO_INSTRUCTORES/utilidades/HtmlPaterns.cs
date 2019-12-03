using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISTEMA_CENSO_INSTRUCTORES.utilidades
{
    public static class HtmlPaterns
    {
        public static string BUSCADOR_CEDULA = @"<div class='row'><br /></div>
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
          />
        </div>
      </div>
      <div class='row'>
        <a class='btn' style='background-color:#E5007F;color:#FFFFFF' id='btn-buscar-cedula'>Buscar</a>
      </div>
      <div class='row'><br /></div>
      <div class='row' id='buscar-response'></div>";

        public static string MOSTRAR_DATOS= @"<div class='row'><br /></div>
      <div class='row'>
        <span 
          >Cédula: <b id='ced-general'>{{ cedula }}</b></span
        >
      </div>
      <div class='row'>
        <span
          >Nombres: <b>{{ nombres }}</b></span
        >
      </div>
      <div class='row'>
        <span
          >Apellidos: <b>{{ apellidos }}</b></span
        >
      </div>
        <div class='row'><br /></div>";

        public static string descSelect = @"
        <select type='text' class='form-control descripcion' id='desc' required='required'>
                <option  value='0'>Seleccione</option>
                 {{campos}}
             </select>";

        public static string descInput = @"
            <input type='text' class='form-control descripcion' id='desc' required='required' value='{{DESC}}'/>
        ";

        public static string campos = @"<div class='row' >
        <div class=' form-group col-md-3' style='text-align:center' >
            <select class='selectpicker seltipo' id='seltipo' required='required'>
                <option selected='selected' value='0'>Seleccione</option>
               <option {{tp}}value='1'>Censo</option>
               <option {{tp}}value='2'>Encuesta</option>
               <option {{tp}}value='3'>Investigación Especial</option>
               <option {{tp}}value='4'>Formación Académica</option>
               <option {{tp}}value = '5' > Experiencia en Docencia</option>
               <option {{tp}}value = '6' > Otros(Especifique) </ option >
    
                </select>
            <br /><br />
            <div class ='form-group otrotipo' id='otrotipo' style='{{DISPLAY}}'><input type='text' class ='form-control otrotipoI' style=' width:220px; margin-left:35px'  value='{{OTIPO}}' required=''  /></div>
        </div>
         <div class='col-md-3' style='text-align:center'>
            {{DESC}}
        </div>
         <div class='col-md-3 tema' style='text-align:center'>
           <select class='selectpicker seltema' required='required'>
                <option selected='selected ' value='0'>Seleccione</option>
               <option {{tm}}value='1'>Metodología</option>
               <option {{tm}}value='2'>Cartografía</option>
               <option {{tm}}value='3'>Administrativo y Presupuesto</option>
               <option {{tm}}value='4'>Tecnología</option>

            </select>
        </div>
         <div class='col-md-2' style='text-align:center'>
            <input type='text' class='form-control year' id='year' maxlength='4' onkeyup='this.value=Numeros(this.value, this)' value='{{YEAR}}' required='required'/>
        </div>
         <div class='col-md-1' style='text-align:center'>
             <a class ='btn btn-danger eliminar' href='javascript:void(0);' aria-label='Delete'>
                <i class='fa fa-trash-o ' aria-hidden='true' style='font-size:20px;'></i>
            </a>
        </div>
          <div class ='col-md-12'><hr  style=' height: 1px;background-color: #126bb4; margin-top:0px'  /></div>
    </div>";


    }
}
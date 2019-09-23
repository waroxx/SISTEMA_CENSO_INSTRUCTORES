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
          >Cédula: <b>{{ cedula }}</b></span
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


    }
}
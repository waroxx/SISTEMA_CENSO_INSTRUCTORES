



function generateField(exps) {
    $("#experiencias").html("");
    exps.map(function (exp) {
        let a = campos(exp);
        console.log(a);
        $("#experiencias").append(a);
    });
}

function campos(exp) {
    let catalogo = localStorage.getItem('selTipo')
    switch (exp.TIPO_ACTIVIDAD) {
        case '06':
            return cmps
      .replace("{{SELTIPO}}", TIPO_otroTipo(seltipo(exp.TIENE_EXPERIENCIA_INEC, exp.TIENE_EXPERIENCIA_DOCENTE), exp.TIPO_ACTIVIDAD_ESP))
      .replace("{{DESCRIPCION}}", DESC_campo(exp.DESCRIPCION))
      .replace("{{TEMA}}", TEMA_visible(selTema(), exp.TEMA)).replace("{{YEAR}}", exp.YEAR);
        case '04':
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(exp.TIENE_EXPERIENCIA_INEC, exp.TIENE_EXPERIENCIA_DOCENTE), "04"))
      .replace("{{DESCRIPCION}}", DESC_default(seldesc(exp.TIPO_ACTIVIDAD), exp.DESCRIPCION))
      .replace("{{TEMA}}", TEMA_invisible(selTema())).replace("{{YEAR}}", exp.YEAR);
        case '05':
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(exp.TIENE_EXPERIENCIA_INEC, exp.TIENE_EXPERIENCIA_DOCENTE), "05"))
      .replace("{{DESCRIPCION}}", DESC_campo(exp.DESCRIPCION))
      .replace("{{TEMA}}", TEMA_invisible(selTema())).replace("{{YEAR}}", exp.YEAR);
        case 'def':
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(exp.TIENE_EXPERIENCIA_INEC, exp.TIENE_EXPERIENCIA_DOCENTE), "00"))
      .replace("{{DESCRIPCION}}", DESC_default(seldesc(exp.TIPO_ACTIVIDAD), ""))
      .replace("{{TEMA}}", TEMA_visible(selTema(), exp.TEMA))
            .replace("{{YEAR}}", "");

        default:
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(exp.TIENE_EXPERIENCIA_INEC, exp.TIENE_EXPERIENCIA_DOCENTE), exp.TIPO_ACTIVIDAD))
      .replace("{{DESCRIPCION}}", DESC_default(seldesc(exp.TIPO_ACTIVIDAD), exp.DESCRIPCION))
      .replace("{{TEMA}}", TEMA_visible(selTema(), exp.TEMA))
      .replace("{{YEAR}}", exp.YEAR==null||exp.YEAR==undefined?"":exp.YEAR);
    }
    
}
const cmps =
  '<div class="row fieldRow" > {{SELTIPO}} {{DESCRIPCION}} {{TEMA}}<div class="col-md-2" style="text-align:center"> <input type="text" class="form-control year" value="{{YEAR}}" maxlength="4" onkeyup="this.value=Numeros(this.value,this)" required="required"/></div><div class="col-md-1" style="text-align:center"> <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete"> <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i> </a></div><div class="col-md-12"><hr style=" height: 1px;background-color: #126bb4; margin-top:0px"/></div></div>';

function seltipo(expINEC, expDOC) {
    try {
        return expINEC && expDOC ? JSON.parse(localStorage.getItem('selTipo'))
            : JSON.parse(localStorage.getItem('selTipo')).filter(function(item){ return (["04", "05"].indexOf(item.id)!==-1) === expDOC });
    }catch(e){
        return [];
    }
    
}

function seldesc(act) {
    //return JSON.parse(localStorage.getItem('selDesc'));
    try {
        return JSON.parse(localStorage.getItem('selDesc')).filter(function (item) { return item.ACTID == act });
    }catch(e){
        return [];
    }

}

function selTema() {
    return JSON.parse(localStorage.getItem('selTema'));
}






//const seltipo = [
//  { id: "01", actividad: "Censo" },
//  { id: "02", actividad: "Encuesta" },
//  { id: "03", actividad: "Investigación Especial" },
//  { id: "04", actividad: "Formación Académica" },
//  { id: "05", actividad: "Experiencia en Docencia" },
//  { id: "06", actividad: "Otros(Especifique)" }
//];

//const seldesc = [
//  { id: "03", actid: "01", descripcion: "Censo Nacional Económico" },
//  {
//      id: "14",
//      actid: "01",
//      descripcion: "Censos Nacionales de Población y Vivienda"
//  },
//  { id: "20", actid: "01", descripcion: "Censo Nacional Agropecuario" }
//];

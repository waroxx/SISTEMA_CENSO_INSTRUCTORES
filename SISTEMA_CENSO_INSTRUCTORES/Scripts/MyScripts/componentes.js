



function generateField(exps) {
    exps.map(function (exp) {
        $("#experiencias").append(campos(exp));
    });
}



function campos(exp) {
    switch(exp){
        case '1':
            return cmps
      .replace("{{SELTIPO}}", TIPO_otroTipo(seltipo(), "bomboclat"))
      .replace("{{DESCRIPCION}}", DESC_campo("league of legends"))
      .replace("{{TEMA}}", TEMA_visible([]));

        case '2':
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(), "02"))
      .replace("{{DESCRIPCION}}", DESC_campo("league of legends"))
      .replace("{{TEMA}}", TEMA_visible([]));
        case '3':
            return cmps
      .replace("{{SELTIPO}}", TIPO_default(seltipo(), "01"))
      .replace("{{DESCRIPCION}}", DESC_default(seldesc(), "01"))
      .replace("{{TEMA}}", TEMA_invisible([]));

        default:
            return cmps
      .replace("{{SELTIPO}}", TIPO_otroTipo(seltipo(), "bomboclat"))
      .replace("{{DESCRIPCION}}", DESC_campo("league of legends"))
      .replace("{{TEMA}}", TEMA_visible([]));
    }
    
}
const cmps =
  '<div class="row fieldRow" > {{SELTIPO}} {{DESCRIPCION}} {{TEMA}}<div class="col-md-2" style="text-align:center"> <input type="text" class="form-control year" id="year" maxlength="4" onkeyup="this.value=Numeros(this.value,this)" required="required"/></div><div class="col-md-1" style="text-align:center"> <a class="btn btn-danger eliminar" href="javascript:void(0);" aria-label="Delete"> <i class="fa fa-trash-o " aria-hidden="true" style="font-size:20px;"></i> </a></div><div class="col-md-12"><hr style=" height: 1px;background-color: #126bb4; margin-top:0px"/></div></div>';

function seltipo(expINEC, expDOC) {
    try {
        return expINEC && expDOC ? JSON.parse(localStorage.getItem('selTipo'))
            : JSON.parse(localStorage.getItem('selTipo')).filter(item=> { return (["04", "05"].indexOf(item.id)!==-1) === expDOC });
    }catch(e){
        return [];
    }
    
}

function seldesc() {
    return JSON.parse(localStorage.getItem('selDesc'));
    //try {

    //    return expINEC && expDOC ? JSON.parse(localStorage.getItem('selTipo'))
       //                         : JSON.parse(localStorage.getItem('selTipo')).filter(item=> { return (["04", "05"].indexOf(item.id) === -1) !== expDOC });
    //}catch(e){
    //    return [];
    //}

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

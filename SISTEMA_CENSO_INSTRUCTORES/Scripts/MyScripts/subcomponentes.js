function TIPO_otroTipo(campos, otro) {
    const tipo_otroTipo =
      '<div class=" form-group col-md-3" style="text-align:center" > <select class="form-control seltipo" id="seltipo" required="required"> {{OPTIONS}} </select> <br/><br/><div class="form-group otrotipo" id="otrotipo" style="display:block"><input type="text" value="' +
      otro +
      '" class="form-control otrotipoI" style=" width:220px; margin-left:35px"/></div></div>';
    let options = "";
    campos.map(function (item) {
        let op = '<option value="' + item.id + '">' + item.Actividad + "</option>";
        if (item.id === "06") {
            op =
              '<option selected="selected" value="' +
              item.id +
              '">' +
              item.Actividad +
              "</option>";
        }
        options += op;
    });
    return tipo_otroTipo.replace("{{OPTIONS}}", options);
}

function TIPO_default(campos, selected) {
    const tipo_default =
      '<div class="form-group col-md-3" style="text-align:center" > <select class="form-control seltipo" id="seltipo" required="required"><option value="00">Seleccione</option>{{OPTIONS}} </select> <br/><br/><div class="form-group otrotipo" id="otrotipo" style="display:none"><input type="text" class="form-control otrotipoI" style=" width:220px; margin-left:35px"/></div></div>';
    let options = "";
    campos.map(function (item) {
        let op = '<option value="' + item.id + '">' + item.Actividad + "</option>";
        if (item.id === selected) {
            op =
              '<option selected="selected" value="' +
              item.id +
              '">' +
              item.Actividad +
              "</option>";
        }
        options += op;
    });
    return tipo_default.replace("{{OPTIONS}}", options);
}

//DESCRIPCIONES

function DESC_default(campos, selected) {
    const desc_default =
      '<div class="col-md-3" style="text-align:center"> <select type="text" class="form-control descripcion" id="desc" required="required"><option value="00">Seleccione</option> {{OPTIONS}} </select></div>';
    let options = "";
    campos.map(function (item) {
        let op =
          '<option value="' + item.ID + '">' + item.DESCRIPCION + "</option>";
        if (item.ID === selected) {
            op =
              '<option selected="selected" value="' +
              item.ID +
              '">' +
              item.DESCRIPCION +
              "</option>";
        }
        options += op;
    });
    return desc_default.replace("{{OPTIONS}}", options);
}

function DESC_campo(desc) {
    const desc_campo =
      '<div class=" form-group col-md-3" style="text-align:center" ><input type="text" value="{{desc}}" class="form-control descripcion" id="desc" required="required"/></div>';
    return desc_campo.replace("{{desc}}", desc);
}
//TEMA
function TEMA_visible(campos, selected) {
    const tema_visible =
      '<div class="col-md-3" style="text-align:center"> <select class="form-control seltema" required="required"><option value="00">Seleccione</option> {{OPTIONS}} </select></div>';
    let options = "";
    campos.map(function (item) {
        let op = '<option value="' + item.id.toString() + '">' + item.tema + "</option>";
        if (item.id.toString() === selected) {
            op =
              '<option selected="selected" value="' +
              item.id +
              '">' +
              item.tema +
              "</option>";
        }
        options += op;
    });
    return tema_visible.replace("{{OPTIONS}}", options);
}

function TEMA_invisible(campos, selected) {
    const tema_invisible =
      '<div class="col-md-3" style="text-align:center;visibility:hidden"> <select class="form-control seltema"><option value="00">Seleccione</option> {{OPTIONS}} </select></div>';
    let options = "";
    campos.map(function (item) {
        let op = '<option value="' + item.id + '">' + item.tema + "</option>";
        if (item.id === selected) {
            op =
              '<option selected="selected" value="' +
              item.id +
              '">' +
              item.tema +
              "</option>";
        }
        options += op;
    });
    return tema_invisible.replace("{{OPTIONS}}", options);
}
